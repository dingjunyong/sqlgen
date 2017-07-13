using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;
using System.Collections;
using System.IO;

namespace SQLGen
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private ServerConnection serverConnection = null;
        private void btnGo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            lstTables.Items.Clear();
            SqlConnection objCn = new SqlConnection(sqlControl1.ConnectionString);
            serverConnection = new ServerConnection(objCn);
            Server server = new Server(serverConnection);
            TableCollection objTables = server.Databases[sqlControl1.DatabaseName].Tables;
            foreach (Table objTable in objTables)
            {
                lstTables.Items.Add(objTable.Name);
            }
            this.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection objCn = new SqlConnection(sqlControl1.ConnectionString);
            serverConnection = new ServerConnection(objCn);
            Server server = new Server(serverConnection);
            Char[] EnvArr = Environment.NewLine.ToCharArray();
            int keyCount = 0;
            for (int i = 0; i < lstTables.CheckedItems.Count; i++)
            {
                string strTableName = lstTables.CheckedItems[i].ToString();
                string strSQL = "";
                /***SELECT**/
                if (chkSelect.Checked)
                {
                    strSQL = "CREATE PROCEDURE [" + strTableName.ToLower() + "_get_all] " + Environment.NewLine;
                    strSQL += "As" + Environment.NewLine;
                    strSQL += " SELECT * FROM [" + strTableName + "]" + Environment.NewLine;
                    txtSQL.Text += strSQL + Environment.NewLine + Environment.NewLine;

                }
                strSQL = "";
                /***DELETE**/
                if (chkDelete.Checked)
                {
                    strSQL = "CREATE PROCEDURE [" + strTableName.ToLower() + "_delete_by_id] " + Environment.NewLine;

                    /***Now Declare Params**/
                    Hashtable objTable = (Hashtable)JSStaticClass.WhereColumns[strTableName];
                    if (objTable.Keys.Count > 0)
                    {
                        strSQL += "(";
                        keyCount = 0;
                        foreach (object KeyID in objTable.Keys)
                        {
                            keyCount++;
                            strSQL += "@" + KeyID.ToString().Replace(" ", "") + " " + server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns[KeyID.ToString()].DataType;//.SqlDataType;
                            if (server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns[KeyID.ToString()].DataType.SqlDataType == SqlDataType.NVarCharMax)
                            {
                                strSQL += "(MAX)";
                            }
                            if (server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns[KeyID.ToString()].DataType.SqlDataType == SqlDataType.VarCharMax)
                            {
                                strSQL += "(MAX)";
                            }

                            else if (server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns[KeyID.ToString()].DataType.Name.ToUpper().Contains("CHAR"))
                                strSQL += "(" + server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns[KeyID.ToString()].DataType.MaximumLength + ")";
                            if (keyCount < objTable.Keys.Count) strSQL += "," + Environment.NewLine;
                        }

                        strSQL += ")" + Environment.NewLine;
                    }
                    strSQL += " As Delete from [" + strTableName + "]" + Environment.NewLine;
                    if (objTable.Keys.Count > 0)
                    {
                        strSQL += " Where ";
                        keyCount = 0;
                        foreach (object KeyID in objTable.Keys)
                        {
                            keyCount++;
                            strSQL += KeyID.ToString().Replace(" ", "") + " =  " + "@" + KeyID.ToString().Replace(" ", "");
                            if (keyCount < objTable.Keys.Count) strSQL += " and " + Environment.NewLine;
                        }
                    }

                    txtSQL.Text += strSQL + Environment.NewLine + Environment.NewLine;
                }
                /***INSERT**/
                if (chkInsert.Checked)
                {
                    strSQL = "CREATE PROCEDURE [" + strTableName.ToLower() + "_add] " + Environment.NewLine;

                    /***Now Declare Params**/
                    Hashtable objTable = (Hashtable)JSStaticClass.WhereColumns[strTableName];
                    Hashtable objIDTable = (Hashtable)JSStaticClass.TableColumns[strTableName];
                    //if (objTable.Keys.Count > 0)
                    //{
                        strSQL += "(";
                        keyCount = 0;
                        foreach (Column item in server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns)
                        {
                            keyCount++;
                            if (objIDTable[item.Name] == null)
                            {
                                strSQL += "@" + item.Name.ToString().Replace(" ", "") + " " + item.DataType ;//.SqlDataType;
                                if (item.DataType.SqlDataType == SqlDataType.VarCharMax)
                                {
                                    strSQL += "(MAX)";
                                }
                                if (item.DataType.SqlDataType == SqlDataType.NVarCharMax)
                                {
                                    strSQL += "(MAX)";
                                }
                                else if (item.DataType.Name.ToUpper().Contains("CHAR"))
                                    strSQL += "(" + item.DataType.MaximumLength + ")";
                                if (keyCount < server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns.Count) strSQL += "," + Environment.NewLine;
                            }
                        }
                        strSQL += ")" + Environment.NewLine;
                    //}
                    strSQL += " As Insert Into [" + strTableName + "] (" + Environment.NewLine;
                    keyCount = 0;
                    foreach (Column item in server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns)
                    {
                        keyCount++;
                        if (objIDTable[item.Name] == null)
                        {
                            strSQL += item.Name.ToString().Replace(" ", "");
                            if (keyCount < server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns.Count) strSQL += "," + Environment.NewLine;
                        }
                    }
                    strSQL += ") Values (" + Environment.NewLine;
                    keyCount = 0;
                    foreach (Column item in server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns)
                    {
                        keyCount++;

                        if (objIDTable[item.Name] == null)
                        {
                            strSQL += "@" + item.Name.ToString().Replace(" ", "");
                            if (keyCount < server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns.Count) strSQL += "," + Environment.NewLine;
                        }
                    }
                    strSQL += ")" + Environment.NewLine;
                    strSQL += "select SCOPE_IDENTITY()";
                    txtSQL.Text += strSQL + Environment.NewLine + Environment.NewLine;
                }
                /***UPDATE**/
                if (chkUpdate.Checked)
                {
                    strSQL = "CREATE PROCEDURE [" + strTableName.ToLower() + "_update] " + Environment.NewLine;

                    /***Now Declare Params**/
                    Hashtable objTable = (Hashtable)JSStaticClass.WhereColumns[strTableName];
                    Hashtable objIDTable = (Hashtable)JSStaticClass.TableColumns[strTableName];
                    //if (objTable.Keys.Count > 0)
                    //{
                        strSQL += "(";
                        keyCount = 0;
                        foreach (Column item in server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns)
                        {
                            keyCount++;
                            //if (objIDTable[item.Name] == null)
                            //{
                                strSQL += "@" + item.Name.ToString().Replace(" ", "") + " " + item.DataType;//.SqlDataType;
                                if (item.DataType.SqlDataType == SqlDataType.VarCharMax)
                                {
                                    strSQL += "(MAX)";
                                }
                                if (item.DataType.SqlDataType == SqlDataType.NVarCharMax)
                                {
                                    strSQL += "(MAX)";
                                }
                                else if (item.DataType.Name.ToUpper().Contains("CHAR"))
                                    strSQL += "(" + item.DataType.MaximumLength + ")";
                                if (keyCount < server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns.Count) strSQL += "," + Environment.NewLine;
                            //}
                        }
                        strSQL += ")" + Environment.NewLine;
                    //}
                    strSQL += " As Update [" + strTableName + "] set " + Environment.NewLine;
                    keyCount = 0;
                    foreach (Column item in server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns)
                    {
                        keyCount++;
                        if (objIDTable[item.Name] == null && objTable[item.Name] == null)
                        {
                            strSQL += item.Name.ToString().Replace(" ", "") + " = @" + item.Name.ToString().Replace(" ", "");
                            if (keyCount < server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns.Count) strSQL += "," + Environment.NewLine;
                        }
                    }
                    strSQL += "";
                    if (objTable.Keys.Count > 0)
                    {
                        strSQL += Environment.NewLine + " Where ";
                        keyCount = 0;
                        foreach (object KeyID in objTable.Keys)
                        {
                            keyCount++;
                            strSQL += KeyID.ToString().Replace(" ", "") + " =  " + "@" + KeyID.ToString().Replace(" ", "");
                            if (keyCount < objTable.Keys.Count) strSQL += " and " + Environment.NewLine;
                        }
                    }
                    txtSQL.Text += strSQL + Environment.NewLine + Environment.NewLine;
                }
                /***UPDATE/INSERT**/
                if (chkInsUpd.Checked)
                {
                    strSQL = "CREATE PROCEDURE [" + strTableName + "_AddUpdate] " + Environment.NewLine;

                    /***Now Declare Params**/
                    Hashtable objTable = (Hashtable)JSStaticClass.WhereColumns[strTableName];
                    Hashtable objIDTable = (Hashtable)JSStaticClass.TableColumns[strTableName];
                    //if (objTable.Keys.Count > 0)
                    //{
                        strSQL += "(";
                        keyCount = 0;
                        foreach (Column item in server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns)
                        {
                            keyCount++;
                            //if (objIDTable[item.Name] == null)
                            //{
                                strSQL += "@" + item.Name.ToString().Replace(" ", "") + " " + item.DataType;//.SqlDataType;
                                if (item.DataType.SqlDataType == SqlDataType.VarCharMax)
                                {
                                    strSQL += "(MAX)";
                                }
                                else if (item.DataType.Name.ToUpper().Contains("CHAR"))
                                    strSQL += "(" + item.DataType.MaximumLength + ")";
                                if (keyCount < server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns.Count) strSQL += "," + Environment.NewLine;
                            //}
                        }
                        strSQL += ")" + Environment.NewLine;
                    //}
                    strSQL += " As Begin" + Environment.NewLine;

                    strSQL += "If (Select ";


                    if (objIDTable.Keys.Count > 0)
                    {

                        keyCount = 0;
                        foreach (object KeyID in objIDTable.Keys)
                        {
                            keyCount++;
                            strSQL += KeyID.ToString().Replace(" ", "");
                            if (keyCount < objIDTable.Keys.Count) strSQL += " , ";
                        }
                    }
                    strSQL += " from [" + strTableName + "]";
                    if (objTable.Keys.Count > 0)
                    {
                        strSQL += Environment.NewLine + " Where ";
                        keyCount = 0;
                        foreach (object KeyID in objTable.Keys)
                        {
                            keyCount++;
                            strSQL += KeyID.ToString().Replace(" ", "") + " =  " + "@" + KeyID.ToString().Replace(" ", "");
                            if (keyCount < objTable.Keys.Count) strSQL += " and " + Environment.NewLine;
                        }
                    }
                    strSQL += ") <> 0" + Environment.NewLine;
                    strSQL += "Begin" + Environment.NewLine;
                    strSQL += " Update [" + strTableName + "] set " + Environment.NewLine;
                    keyCount = 0;
                    foreach (Column item in server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns)
                    {
                        keyCount++;
                        if (objIDTable[item.Name] == null && objTable[item.Name] == null)
                        {
                            strSQL += item.Name.ToString().Replace(" ", "") + " = @" + item.Name.ToString().Replace(" ", "");
                            if (keyCount < server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns.Count) strSQL += "," + Environment.NewLine;
                        }
                    }
                    strSQL += "";
                    if (objTable.Keys.Count > 0)
                    {
                        strSQL += Environment.NewLine + " Where ";
                        keyCount = 0;
                        foreach (object KeyID in objTable.Keys)
                        {
                            keyCount++;
                            strSQL += KeyID.ToString().Replace(" ", "") + " =  " + "@" + KeyID.ToString().Replace(" ", "");
                            if (keyCount < objTable.Keys.Count) strSQL += " and " + Environment.NewLine;
                        }
                    }
                    strSQL +=  Environment.NewLine + "End" + Environment.NewLine;
                    strSQL += "Else" + Environment.NewLine;
                    strSQL += "Begin" + Environment.NewLine;

                    strSQL += " Insert Into [" + strTableName + "] (" + Environment.NewLine;
                    keyCount = 0;
                    foreach (Column item in server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns)
                    {
                        keyCount++;
                        if (objIDTable[item.Name] == null)
                        {
                            strSQL += item.Name.ToString().Replace(" ", "");
                            if (keyCount < server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns.Count) strSQL += "," + Environment.NewLine;
                        }
                    }
                    strSQL += ") Values (" + Environment.NewLine;
                    keyCount = 0;
                    foreach (Column item in server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns)
                    {
                        keyCount++;

                        if (objIDTable[item.Name] == null)
                        {
                            strSQL += "@" + item.Name.ToString().Replace(" ", "");
                            if (keyCount < server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns.Count) strSQL += "," + Environment.NewLine;
                        }
                    }
                    strSQL += ")" + Environment.NewLine;
                    strSQL += "select SCOPE_IDENTITY()" + Environment.NewLine;


                    strSQL += "End" + Environment.NewLine;
                    strSQL += "End" + Environment.NewLine;
                    txtSQL.Text += strSQL + Environment.NewLine + Environment.NewLine;
                }

            }
        }

        private void lstTables_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                this.Cursor = Cursors.WaitCursor;
                string strTable = lstTables.Items[e.Index].ToString();
                SqlConnection objCn = new SqlConnection(sqlControl1.ConnectionString);
                serverConnection = new ServerConnection(objCn);
                Server server = new Server(serverConnection);
                ColumnCollection objCols = server.Databases[sqlControl1.DatabaseName].Tables[strTable].Columns;
                frmCols objFCols = new frmCols();
                objFCols.TableName = strTable;
                objFCols.TableCols = objCols;
                objFCols.PopulateForm();
                objFCols.ShowDialog(this);

                frmCriteria objFCrit = new frmCriteria();
                objFCrit.TableName = strTable;
                objFCrit.TableCols = objCols;
                objFCrit.PopulateForm();


                objFCrit.ShowDialog(this);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string[] SplitItems = txtSQL.Text.Split(new string[] { "CREATE PROCEDURE" }, StringSplitOptions.RemoveEmptyEntries);
            FolderBrowserDialog objFB = new FolderBrowserDialog();
            objFB.Description = "Select folder to save scripts";
            objFB.ShowDialog(this);
            if (objFB.SelectedPath != "")
            {
                foreach (string objString in SplitItems)
                {

                    File.WriteAllText(objFB.SelectedPath +"\\" + objString.Split(new string[]{Environment.NewLine,""},StringSplitOptions.None).GetValue(0).ToString().Replace(" ","").Replace("[","").Replace("]","") +".sql","CREATE PROCEDURE " +objString);
                }
            }
            MessageBox.Show("Done", "All Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string[] SplitItems = txtSQL.Text.Split(new string[] { "CREATE PROCEDURE" }, StringSplitOptions.RemoveEmptyEntries);
            List<Exception> objExs = new List<Exception>();
            foreach (string objString in SplitItems)
            {
                using (SqlConnection objCnn = new SqlConnection(sqlControl1.ConnectionString))
                {
                    objCnn.Open();
                    using (SqlCommand objCmd = objCnn.CreateCommand())
                    {
                        objCmd.CommandType = CommandType.Text;
                        objCmd.CommandText = "CREATE PROCEDURE " + objString;
                        try
                        {
                            objCmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            objExs.Add(ex);
                        }

                    }
                }



            }
            foreach (Exception item in objExs)
            {
                File.AppendAllText(Application.StartupPath + "\\Log.txt", DateTime.Now.ToString() + Environment.NewLine + "*****************" + Environment.NewLine + "Error :" + Environment.NewLine + item.Message + Environment.NewLine + item.Source + Environment.NewLine + item.StackTrace);
            }
            if (objExs.Count == 0)
                MessageBox.Show("Done", "All Executed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Done - Please check log.txt in application directory as there were errors", "All Executed - With errors", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnClasses_Click(object sender, EventArgs e)
        {
            string[] SplitItems = txtSQL.Text.Split(new string[] { "CREATE PROCEDURE" }, StringSplitOptions.RemoveEmptyEntries);
            FolderBrowserDialog objFB = new FolderBrowserDialog();
            objFB.Description = "Select folder to save scripts";
            objFB.ShowDialog(this);
            if (objFB.SelectedPath != "")
            {
                SqlConnection objCn = new SqlConnection(sqlControl1.ConnectionString);
                serverConnection = new ServerConnection(objCn);
                Server server = new Server(serverConnection);
                Char[] EnvArr = Environment.NewLine.ToCharArray();
                int keyCount = 0;
                for (int i = 0; i < lstTables.CheckedItems.Count; i++)
                {
                    string strTableName = lstTables.CheckedItems[i].ToString();
                    string strClassStuff = "";
                    strClassStuff += AddTabbedText("using System;", 0);
                    strClassStuff += AddTabbedText("using System.Collections.Generic;", 0);
                    if (chkWeb.Checked)
                        strClassStuff += AddTabbedText("using System.Web;", 0);
                    if (chkWebMethods.Checked)
                        strClassStuff += AddTabbedText("using System.Web.Services;", 0);
                    strClassStuff += AddTabbedText("using System.Configuration;", 0);
  
                    strClassStuff += AddTabbedText("using System.Data;", 0);
                    strClassStuff += AddTabbedText("using Dapper;", 0);
                    
                    strClassStuff += Environment.NewLine;
                    strClassStuff += AddTabbedText("namespace " + txtNameSpace.Text, 0);
                    strClassStuff += AddTabbedText("{", 0);
                    if (chkWebMethods.Checked)
                    {
                        strClassStuff += AddTabbedText("[WebService(Namespace = \"http://tempuri.org/\")]", 1);
                        strClassStuff += AddTabbedText("[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]", 1);
                        strClassStuff += AddTabbedText("[System.ComponentModel.ToolboxItem(false)]", 1);
                        strClassStuff += AddTabbedText("public class " + strTableName.Replace(" ", "") + " : System.Web.Services.WebService", 1);
                    }
                    else
                        strClassStuff += AddTabbedText("public class " + strTableName.Replace(" ", "") + "Repository" + " : I" + strTableName.Replace(" ", "") + "Repository", 1);

                    strClassStuff += AddTabbedText("{", 1);

                    strClassStuff += AddTabbedText("private readonly ShopObjectContext _context;", 2);

                    strClassStuff += AddTabbedText("public " + strTableName.Replace(" ", "") + "Repository" + "(ShopObjectContext context)", 2);
                    strClassStuff += AddTabbedText("{", 2);
                    strClassStuff += AddTabbedText("this._context = context;", 3);
                    strClassStuff += AddTabbedText("}", 2);
                    //keyCount = 0;
                    //foreach (Column item in server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns)
                    //{
                    //    keyCount++;
                    //    if (keyCount == 1) continue;
                    //    strClassStuff += AddTabbedText("/// <summary>", 2);
                    //    strClassStuff += AddTabbedText("/// 获取或设置 " + item.Name.Replace(" ", ""), 2);
                    //    strClassStuff += AddTabbedText("/// <summary>", 2);
                    //    strClassStuff += AddTabbedText("public " + TranslateTypes(item.DataType.Name) + " " + item.Name.Replace(" ", "") + "{ get; set;}", 2);// item.Name.ToString().Replace(" ", "") + " " + item.DataType;//.SqlDataType;

                    //}
                    

                    /****SELECT***/
                    if (chkSelect.Checked)
                    {
                        if (chkWebMethods.Checked)
                        {
                            strClassStuff += AddTabbedText("[WebMethod]", 2);
                        }
                        strClassStuff += AddTabbedText("public IEnumerable<" + strTableName.Replace(" ", "") + "> Get" + strTableName.Replace(" ", "") + "s()", 2);
                        strClassStuff += AddTabbedText("{", 2);
                        strClassStuff += AddTabbedText("using (var conn = _context.OpenConnection())", 3);
                        strClassStuff += AddTabbedText("{", 3);
                        strClassStuff += AddTabbedText("var result = conn.Query<" + strTableName + ">(", 4);
                        strClassStuff += AddTabbedText("\"" + strTableName.ToLower() + "_get_all\",", 5);
                        strClassStuff += AddTabbedText("commandType: CommandType.StoredProcedure);", 5);
                        strClassStuff += AddTabbedText("return result;", 4);
                        strClassStuff += AddTabbedText("}", 3);
                        strClassStuff += AddTabbedText("}", 2);
                    }


                    /****INSERT***/
                    if (chkInsert.Checked)
                    {
                        if (chkWebMethods.Checked)
                        {
                            strClassStuff += AddTabbedText("[WebMethod]", 2);
                        }
                        strClassStuff += AddTabbedText("public int Insert" + strTableName.Replace(" ", "") + "(" + strTableName.Replace(" ", "")  + " objRecord)", 2);
                        strClassStuff += AddTabbedText("{", 2);
                        strClassStuff += AddTabbedText("using (var conn = _context.OpenConnection())", 3);
                        strClassStuff += AddTabbedText("{", 3);
                        strClassStuff += AddTabbedText("var param = new DynamicParameters();", 4);
                       
                        
                        foreach (Column item in server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns)
                        {
                            if (item.Name == "Id")
                                continue;

                            strClassStuff += AddTabbedText("param.Add(\"@" + item.Name + "\", objRecord." + item.Name + ");", 4);
                        }
                        strClassStuff += AddTabbedText("var result = conn.Execute(", 4);
                        strClassStuff += AddTabbedText("\"" + strTableName.ToLower() + "_add\",", 5);
                        strClassStuff += AddTabbedText("param: param,", 5);
                        strClassStuff += AddTabbedText("commandType: CommandType.StoredProcedure);", 5);
                        strClassStuff += AddTabbedText("return result;", 4);
                        strClassStuff += AddTabbedText("}", 3);
                        strClassStuff += AddTabbedText("}", 2);
                    }

                    /****UPDATE***/
                    if (chkUpdate.Checked)
                    {
                        if (chkWebMethods.Checked)
                        {
                            strClassStuff += AddTabbedText("[WebMethod]", 2);
                        }
                        strClassStuff += AddTabbedText("public int Update" + strTableName.Replace(" ", "") + "(" + strTableName.Replace(" ", "") + " objRecord)", 2);
                        strClassStuff += AddTabbedText("{", 2);
                        strClassStuff += AddTabbedText("using (var conn = _context.OpenConnection())", 3);
                        strClassStuff += AddTabbedText("{", 3);
                        strClassStuff += AddTabbedText("var param = new DynamicParameters();", 4);


                        foreach (Column item in server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns)
                        {
                            strClassStuff += AddTabbedText("param.Add(\"@" + item.Name + "\", objRecord." + item.Name + ");", 4);
                        }
                        strClassStuff += AddTabbedText("var result = conn.Execute(", 4);
                        strClassStuff += AddTabbedText("\"" + strTableName.ToLower() + "_update\",", 5);
                        strClassStuff += AddTabbedText("param: param,", 5);
                        strClassStuff += AddTabbedText("commandType: CommandType.StoredProcedure);", 5);
                        strClassStuff += AddTabbedText("return result;", 4);
                        strClassStuff += AddTabbedText("}", 3);
                        strClassStuff += AddTabbedText("}", 2);
                    }

                    /****DELETE***/
                    if (chkDelete.Checked)
                    {
                        if (chkWebMethods.Checked)
                        {
                            strClassStuff += AddTabbedText("[WebMethod]", 2);
                        }
                        strClassStuff += AddTabbedText("public int Delete" + strTableName.Replace(" ", "") + "(int id)", 2);
                        strClassStuff += AddTabbedText("{", 2);
                        strClassStuff += AddTabbedText("using (var conn = _context.OpenConnection())", 3);
                        strClassStuff += AddTabbedText("{", 3);
                        strClassStuff += AddTabbedText("var param = new DynamicParameters();", 4);


                        strClassStuff += AddTabbedText("param.Add(\"@" + "Id" + "\", " + "id" + ");", 4);
                        strClassStuff += AddTabbedText("var result = conn.Execute(", 4);
                        strClassStuff += AddTabbedText("\"" + strTableName + "_delete_by_id\",", 5);
                        strClassStuff += AddTabbedText("param: param,", 5);
                        strClassStuff += AddTabbedText("commandType: CommandType.StoredProcedure);", 5);
                        strClassStuff += AddTabbedText("return result;", 4);
                        strClassStuff += AddTabbedText("}", 3);
                        strClassStuff += AddTabbedText("}", 2);
                    }

                    /****UPSERT***/
                    if (chkInsUpd.Checked)
                    {
                        if (chkWebMethods.Checked)
                        {
                            strClassStuff += AddTabbedText("[WebMethod]", 2);
                        }
                        strClassStuff += AddTabbedText("public Int32 Upsert" + strTableName.Replace(" ", "") + "(" + strTableName.Replace(" ", "") + " objRecord)", 2);
                        strClassStuff += AddTabbedText("{", 2);
                        strClassStuff += AddTabbedText("Int32 objRet = 0;", 3);

                        strClassStuff += AddTabbedText("ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings[\"ProvString\"];", 3);
                        strClassStuff += AddTabbedText("using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))", 3);
                        strClassStuff += AddTabbedText("{", 3);
                        strClassStuff += AddTabbedText("objCnn.Open();", 4);
                        strClassStuff += AddTabbedText(" using (SqlCommand objCmd = objCnn.CreateCommand())", 4);
                        strClassStuff += AddTabbedText("{", 4);
                        strClassStuff += AddTabbedText("objCmd.CommandType = System.Data.CommandType.StoredProcedure;", 5);
                        strClassStuff += AddTabbedText("objCmd.CommandText = \"[AddUpdate" + strTableName + "]\";", 5);
                        foreach (Column item in server.Databases[sqlControl1.DatabaseName].Tables[strTableName].Columns)
                        {
                            strClassStuff += AddTabbedText("objCmd.Parameters.Add(new SqlParameter(\"@" + item.Name + "\", objRecord." + item.Name + "));", 5);
                        }
                        strClassStuff += AddTabbedText("object obj = objCmd.ExecuteScalar();", 5);
                        strClassStuff += AddTabbedText("if (obj != null)", 5);
                        strClassStuff += AddTabbedText("objRet = Convert.ToInt32(obj);", 6);
                        strClassStuff += AddTabbedText("}", 4);
                        strClassStuff += AddTabbedText("}", 3);
                        strClassStuff += AddTabbedText("return objRet;", 3);
                        strClassStuff += AddTabbedText("}", 2);
                    }
                    strClassStuff += AddTabbedText("}", 1);
                    strClassStuff += AddTabbedText("}", 0);
                    
                    if (chkWebMethods.Checked)
                    {
                        File.WriteAllText(objFB.SelectedPath + "\\" + strTableName.Replace(" ", "") + ".asmx.cs", strClassStuff);
                        File.WriteAllText(objFB.SelectedPath + "\\" + strTableName.Replace(" ", "") + ".asmx", "<%@ WebService Language=\"C#\" CodeBehind=\"" + strTableName.Replace(" ", "") + ".asmx.cs\" Class=\"" + txtNameSpace.Text + "." + strTableName.Replace(" ", "") + "\" %>");
                    }
                    else
                        File.WriteAllText(objFB.SelectedPath + "\\" + strTableName.Replace(" ", "") + ".cs", strClassStuff);
                }
            }
        }
        private string TranslateTypes(string strSqlType)
        {
            
            
            switch (strSqlType.ToUpper())
            {
                case "VARCHAR":
                    return "string";
                    break;
                case "CHAR":
                    return "string";
                    break;
                case "INT":
                    return "int";
                    break;
                case "SMALLINT":
                    return "Int16";
                    break;
                case "BIGINT":
                    return "Int64";
                    break;
                case "BIT":
                    return "Boolean";
                    break;
                case "DATE":
                    return "DateTime";
                    break;
                case "DATETIME":
                    return "DateTime";
                    break;
                case "FLOAT":
                    return "Decimal";
                    break;
                //case "FLOAT":
                //    return "Decimal";
                //    break;
                case "MONEY":
                    return "Decimal";
                    break;
                case "NCHAR":
                    return "String";
                    break;
                case "NVARCHAR":
                    return "String";
                    break;
                case "REAL":
                    return "Decimal";
                    break;
                case "TEXT":
                    return "String";
                    break;
                
                default:
                    return "String";
                    break;
            }
            
        }
        private string  AddTabbedText(string ToAdd,int TabCount)
        {
            string strRet = "";
            if (TabCount == 0)
                return ToAdd + Environment.NewLine;
            else
            {
                for (int i = 0; i < TabCount; i++)
			{
                    strRet +=   "   ";  
			}
            }
            return strRet + ToAdd + Environment.NewLine;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }

}
