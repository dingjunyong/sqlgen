using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using System.Collections;

namespace SQLGen
{
    public partial class frmCols : Form
    {
        public frmCols()
        {
            InitializeComponent();
        }
        public string TableName { get; set; }
        public ColumnCollection TableCols { get; set; }
        public void PopulateForm()
        {
            this.Text ="Select the autonumber fields for " + TableName;
            Hashtable objItems = new Hashtable();
            if (JSStaticClass.TableColumns[TableName] != null)
            {
                objItems = (Hashtable)JSStaticClass.TableColumns[TableName];
            }
            foreach (Column item in TableCols)
            {
                if (objItems[item.Name] != null)
                    lstCols.Items.Add(item.Name,true);
                else
                    lstCols.Items.Add(item.Name, false);
            }



        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Hashtable objTable = new Hashtable();
            for (int i = 0; i < lstCols.CheckedItems.Count; i++)
            {
                objTable.Add(lstCols.CheckedItems[i].ToString(), lstCols.CheckedItems[i].ToString());
            }
            if (JSStaticClass.TableColumns[TableName] != null)
                JSStaticClass.TableColumns.Remove(TableName);
            JSStaticClass.TableColumns.Add(TableName, objTable);
            this.Close();
        }
    }
}
