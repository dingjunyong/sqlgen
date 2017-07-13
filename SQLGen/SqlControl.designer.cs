namespace JSSqlControl
{
    partial class SqlControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkTrusted = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comServers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comDatabases = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkTrusted);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(5, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 92);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Credentials";
            // 
            // chkTrusted
            // 
            this.chkTrusted.AutoSize = true;
            this.chkTrusted.Checked = true;
            this.chkTrusted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrusted.Location = new System.Drawing.Point(3, 14);
            this.chkTrusted.Name = "chkTrusted";
            this.chkTrusted.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkTrusted.Size = new System.Drawing.Size(84, 16);
            this.chkTrusted.TabIndex = 6;
            this.chkTrusted.Text = "Trusted   ";
            this.chkTrusted.UseVisualStyleBackColor = true;
            this.chkTrusted.CheckedChanged += new System.EventHandler(this.chkTrusted_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(69, 59);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(219, 21);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Text = "Djy123456789";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Password:";
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.Enabled = false;
            this.txtUserName.Location = new System.Drawing.Point(69, 35);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(219, 21);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Text = "sa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "User Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Server :";
            // 
            // comServers
            // 
            this.comServers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comServers.FormattingEnabled = true;
            this.comServers.Items.AddRange(new object[] {
            "119.29.60.130"});
            this.comServers.Location = new System.Drawing.Point(60, 3);
            this.comServers.Name = "comServers";
            this.comServers.Size = new System.Drawing.Size(233, 20);
            this.comServers.TabIndex = 8;
            this.comServers.DropDown += new System.EventHandler(this.comServers_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "Database:";
            // 
            // comDatabases
            // 
            this.comDatabases.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comDatabases.FormattingEnabled = true;
            this.comDatabases.Location = new System.Drawing.Point(65, 126);
            this.comDatabases.Name = "comDatabases";
            this.comDatabases.Size = new System.Drawing.Size(228, 20);
            this.comDatabases.Sorted = true;
            this.comDatabases.TabIndex = 11;
            this.comDatabases.DropDown += new System.EventHandler(this.comDatabases_DropDown);
            this.comDatabases.SelectedValueChanged += new System.EventHandler(this.comDatabases_SelectedValueChanged);
            // 
            // SqlControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comDatabases);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comServers);
            this.Name = "SqlControl";
            this.Size = new System.Drawing.Size(317, 165);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkTrusted;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comServers;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox comDatabases;
    }
}
