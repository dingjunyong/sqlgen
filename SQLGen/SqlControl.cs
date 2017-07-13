using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Server;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;
using System.Collections;

namespace JSSqlControl
{
    public partial class SqlControl : UserControl
    {
        public SqlControl()
        {
            InitializeComponent();
        }
        bool blServDropped = false;
        private void comServers_DropDown(object sender, EventArgs e)
        {
            if (!blServDropped)
            {
                //DataTable dataTable = SmoApplication.EnumAvailableSqlServers(false);
                //comServers.DataSource = new string[1] { "119.29.60.130" };
                //comServers.ValueMember = "Name";
                //comServers.Items.Add("119.29.60.130");
            }
            blServDropped = true;
        }

        private void chkTrusted_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.Enabled = !chkTrusted.Checked;
            txtUserName.Enabled = !chkTrusted.Checked;
        }
        bool blDbDropped = false;
        private ServerConnection serverConnection = null;
        private void comDatabases_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (!this.blDbDropped)
            {


                if (!this.chkTrusted.Checked)
                {
                    serverConnection = new ServerConnection(this.comServers.Text, this.txtUserName.Text, this.txtPassword.Text);
                }
                else
                {
                    serverConnection = new ServerConnection(this.comServers.Text, this.txtUserName.Text, this.txtPassword.Text);
                    //serverConnection = new ServerConnection(this.comServers.Text);
                }
                Server server = new Server(serverConnection);
                DatabaseCollection databases = server.Databases;
                this.comDatabases.Items.Clear();
                foreach (Database database in databases)
                {
                    this.comDatabases.Items.Add(database.Name);
                }
                //this.comDatabases.Items.Add("QlCg");
            }
            //this.blDbDropped = true;
            this.Cursor = Cursors.Default;
           
        }
        public string ConnectionString { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public SqlConnection SQLConnection()
        {
            SqlConnection retCnn = new SqlConnection(ConnectionString);
            if (retCnn.State != ConnectionState.Open)
            {
                try
                {
                    retCnn.Open();
                    
                }
                catch (Exception ex)
                {
                }
            }
            return retCnn;
        }
        private void comDatabases_SelectedValueChanged(object sender, EventArgs e)
        {
            serverConnection.Disconnect();
            if (!this.chkTrusted.Checked)
            {
                serverConnection = new ServerConnection(this.comServers.Text, this.txtUserName.Text, this.txtPassword.Text);
            }
            else
            {
                serverConnection = new ServerConnection(this.comServers.Text);
            }
            serverConnection.DatabaseName = comDatabases.Text.ToString();
            ConnectionString = string.Format("Data Source = {0};Initial Catalog = {1};User Id = {2};Password = {3}", this.comServers.Text, comDatabases.Text.ToString(), this.txtUserName.Text, this.txtPassword.Text);
            ServerName = serverConnection.ServerInstance;
            DatabaseName = comDatabases.Text.ToString();

        }
    }
}
