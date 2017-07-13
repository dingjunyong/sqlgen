namespace SQLGen
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGo = new System.Windows.Forms.Button();
            this.lstTables = new System.Windows.Forms.CheckedListBox();
            this.chkInsert = new System.Windows.Forms.CheckBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.chkSelect = new System.Windows.Forms.CheckBox();
            this.chkInsUpd = new System.Windows.Forms.CheckBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSQL = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnClasses = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkWeb = new System.Windows.Forms.CheckBox();
            this.chkWebMethods = new System.Windows.Forms.CheckBox();
            this.sqlControl1 = new JSSqlControl.SqlControl();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(304, 128);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(87, 21);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "链接数据库";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lstTables
            // 
            this.lstTables.CheckOnClick = true;
            this.lstTables.FormattingEnabled = true;
            this.lstTables.Location = new System.Drawing.Point(2, 183);
            this.lstTables.Name = "lstTables";
            this.lstTables.Size = new System.Drawing.Size(1000, 164);
            this.lstTables.TabIndex = 2;
            this.lstTables.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstTables_ItemCheck);
            // 
            // chkInsert
            // 
            this.chkInsert.AutoSize = true;
            this.chkInsert.Location = new System.Drawing.Point(6, 18);
            this.chkInsert.Name = "chkInsert";
            this.chkInsert.Size = new System.Drawing.Size(60, 16);
            this.chkInsert.TabIndex = 3;
            this.chkInsert.Text = "Insert";
            this.chkInsert.UseVisualStyleBackColor = true;
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Location = new System.Drawing.Point(6, 39);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(60, 16);
            this.chkUpdate.TabIndex = 4;
            this.chkUpdate.Text = "Update";
            this.chkUpdate.UseVisualStyleBackColor = true;
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Location = new System.Drawing.Point(6, 60);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(60, 16);
            this.chkDelete.TabIndex = 5;
            this.chkDelete.Text = "Delete";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // chkSelect
            // 
            this.chkSelect.AutoSize = true;
            this.chkSelect.Location = new System.Drawing.Point(6, 81);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Size = new System.Drawing.Size(60, 16);
            this.chkSelect.TabIndex = 6;
            this.chkSelect.Text = "Select";
            this.chkSelect.UseVisualStyleBackColor = true;
            // 
            // chkInsUpd
            // 
            this.chkInsUpd.AutoSize = true;
            this.chkInsUpd.Location = new System.Drawing.Point(6, 102);
            this.chkInsUpd.Name = "chkInsUpd";
            this.chkInsUpd.Size = new System.Drawing.Size(102, 16);
            this.chkInsUpd.TabIndex = 7;
            this.chkInsUpd.Text = "Insert/Update";
            this.chkInsUpd.UseVisualStyleBackColor = true;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(2, 162);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(138, 16);
            this.chkAll.TabIndex = 8;
            this.chkAll.Text = "Select/Deselect All";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 21);
            this.button1.TabIndex = 9;
            this.button1.Text = "生成存储过程";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSQL
            // 
            this.txtSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSQL.Location = new System.Drawing.Point(2, 387);
            this.txtSQL.Multiline = true;
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSQL.Size = new System.Drawing.Size(1013, 169);
            this.txtSQL.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(2, 556);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "保存文件";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(940, 556);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 21);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExecute.Location = new System.Drawing.Point(100, 360);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(100, 21);
            this.btnExecute.TabIndex = 13;
            this.btnExecute.Text = "执行存储过程";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnClasses
            // 
            this.btnClasses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClasses.Location = new System.Drawing.Point(83, 556);
            this.btnClasses.Name = "btnClasses";
            this.btnClasses.Size = new System.Drawing.Size(119, 21);
            this.btnClasses.TabIndex = 14;
            this.btnClasses.Text = "生成类";
            this.btnClasses.UseVisualStyleBackColor = true;
            this.btnClasses.Click += new System.EventHandler(this.btnClasses_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkInsert);
            this.groupBox1.Controls.Add(this.chkUpdate);
            this.groupBox1.Controls.Add(this.chkDelete);
            this.groupBox1.Controls.Add(this.chkSelect);
            this.groupBox1.Controls.Add(this.chkInsUpd);
            this.groupBox1.Location = new System.Drawing.Point(435, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 134);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SQL Settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNameSpace);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.chkWeb);
            this.groupBox2.Controls.Add(this.chkWebMethods);
            this.groupBox2.Location = new System.Drawing.Point(673, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(313, 134);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Code Settings";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Location = new System.Drawing.Point(6, 79);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(301, 21);
            this.txtNameSpace.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "NameSpace :";
            // 
            // chkWeb
            // 
            this.chkWeb.AutoSize = true;
            this.chkWeb.Location = new System.Drawing.Point(6, 18);
            this.chkWeb.Name = "chkWeb";
            this.chkWeb.Size = new System.Drawing.Size(78, 16);
            this.chkWeb.TabIndex = 3;
            this.chkWeb.Text = "Uses Web?";
            this.chkWeb.UseVisualStyleBackColor = true;
            // 
            // chkWebMethods
            // 
            this.chkWebMethods.AutoSize = true;
            this.chkWebMethods.Location = new System.Drawing.Point(6, 39);
            this.chkWebMethods.Name = "chkWebMethods";
            this.chkWebMethods.Size = new System.Drawing.Size(96, 16);
            this.chkWebMethods.TabIndex = 4;
            this.chkWebMethods.Text = "Web Methods?";
            this.chkWebMethods.UseVisualStyleBackColor = true;
            // 
            // sqlControl1
            // 
            this.sqlControl1.ConnectionString = null;
            this.sqlControl1.DatabaseName = null;
            this.sqlControl1.Location = new System.Drawing.Point(2, 3);
            this.sqlControl1.Name = "sqlControl1";
            this.sqlControl1.ServerName = null;
            this.sqlControl1.Size = new System.Drawing.Size(317, 165);
            this.sqlControl1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(208, 556);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 21);
            this.button2.TabIndex = 17;
            this.button2.Text = "生成仓储类";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 581);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClasses);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSQL);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.lstTables);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.sqlControl1);
            this.Name = "frmMain";
            this.Text = "Jayess Sql Gen";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JSSqlControl.SqlControl sqlControl1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.CheckedListBox lstTables;
        private System.Windows.Forms.CheckBox chkInsert;
        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.CheckBox chkSelect;
        private System.Windows.Forms.CheckBox chkInsUpd;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSQL;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnClasses;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkWeb;
        private System.Windows.Forms.CheckBox chkWebMethods;
        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}

