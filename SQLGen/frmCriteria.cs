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
    public partial class frmCriteria : Form
    {
        public frmCriteria()
        {
            InitializeComponent();
        }
        public string TableName { get; set; }
        public ColumnCollection TableCols { get; set; }
        public void PopulateForm()
        {
            this.Text ="Select the CRITERIA fields for " + TableName;
            Hashtable objItems = new Hashtable();
            if (JSStaticClass.WhereColumns[TableName] != null)
            {
                objItems = (Hashtable)JSStaticClass.WhereColumns[TableName];
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
            if (JSStaticClass.WhereColumns[TableName] != null)
                JSStaticClass.WhereColumns.Remove(TableName);
            JSStaticClass.WhereColumns.Add(TableName, objTable);
            this.Close();
        }
    }
}
