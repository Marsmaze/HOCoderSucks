namespace HOCoderSucks
{
    partial class HCS_MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HCS_MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TB_Import = new System.Windows.Forms.TextBox();
            this.TB_SAMAccount = new System.Windows.Forms.TextBox();
            this.LB_IsAccountDisabled_R = new System.Windows.Forms.Label();
            this.LB_IsAccountLockout_R = new System.Windows.Forms.Label();
            this.TB_Password = new System.Windows.Forms.TextBox();
            this.LB_Search = new System.Windows.Forms.Label();
            this.TB_Search = new System.Windows.Forms.TextBox();
            this.DG_Result = new System.Windows.Forms.DataGridView();
            this.GB_AccountStatus = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BT_Update = new System.Windows.Forms.Button();
            this.LB_SAMAccount = new System.Windows.Forms.Label();
            this.LB_Password = new System.Windows.Forms.Label();
            this.GB_Update = new System.Windows.Forms.GroupBox();
            this.BT_Import = new System.Windows.Forms.Button();
            this.LB_Importtip = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.CB_UPN = new System.Windows.Forms.CheckBox();
            this.LB_UPN = new System.Windows.Forms.Label();
            this.TB_UPN = new System.Windows.Forms.TextBox();
            this.LB_LDAP_Example = new System.Windows.Forms.Label();
            this.CB_LDAP = new System.Windows.Forms.CheckBox();
            this.LB_LDAP = new System.Windows.Forms.Label();
            this.TB_LDAP = new System.Windows.Forms.TextBox();
            this.CB_Unlock = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BT_RstPwd = new System.Windows.Forms.Button();
            this.CB_MustCHGPWD = new System.Windows.Forms.CheckBox();
            this.TB_RstAccount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_RstPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.BT_EFB_Import = new System.Windows.Forms.Button();
            this.LB_Processing = new System.Windows.Forms.Label();
            this.LB_Total = new System.Windows.Forms.Label();
            this.BT_ChnConvert = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.PB_Import = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Result)).BeginInit();
            this.GB_AccountStatus.SuspendLayout();
            this.GB_Update.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TB_Import
            // 
            resources.ApplyResources(this.TB_Import, "TB_Import");
            this.TB_Import.Name = "TB_Import";
            this.TB_Import.TextChanged += new System.EventHandler(this.TB_Import_TextChanged);
            // 
            // TB_SAMAccount
            // 
            resources.ApplyResources(this.TB_SAMAccount, "TB_SAMAccount");
            this.TB_SAMAccount.Name = "TB_SAMAccount";
            this.TB_SAMAccount.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TB_SAMAccountClick);
            this.TB_SAMAccount.Enter += new System.EventHandler(this.TB_SAMAccountEnter);
            // 
            // LB_IsAccountDisabled_R
            // 
            this.LB_IsAccountDisabled_R.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.LB_IsAccountDisabled_R, "LB_IsAccountDisabled_R");
            this.LB_IsAccountDisabled_R.Name = "LB_IsAccountDisabled_R";
            // 
            // LB_IsAccountLockout_R
            // 
            this.LB_IsAccountLockout_R.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.LB_IsAccountLockout_R, "LB_IsAccountLockout_R");
            this.LB_IsAccountLockout_R.Name = "LB_IsAccountLockout_R";
            // 
            // TB_Password
            // 
            resources.ApplyResources(this.TB_Password, "TB_Password");
            this.TB_Password.Name = "TB_Password";
            this.TB_Password.UseSystemPasswordChar = true;
            this.TB_Password.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TB_PasswordClick);
            this.TB_Password.Enter += new System.EventHandler(this.TB_PasswordEnter);
            // 
            // LB_Search
            // 
            resources.ApplyResources(this.LB_Search, "LB_Search");
            this.LB_Search.Name = "LB_Search";
            // 
            // TB_Search
            // 
            resources.ApplyResources(this.TB_Search, "TB_Search");
            this.TB_Search.Name = "TB_Search";
            this.TB_Search.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TB_SearchClick);
            this.TB_Search.Enter += new System.EventHandler(this.TB_SearchEnter);
            this.TB_Search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_Search_KeyPress);
            // 
            // DG_Result
            // 
            this.DG_Result.BackgroundColor = System.Drawing.Color.White;
            this.DG_Result.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DG_Result.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.DG_Result.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DG_Result.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DG_Result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.DG_Result, "DG_Result");
            this.DG_Result.Name = "DG_Result";
            this.DG_Result.RowTemplate.Height = 23;
            this.DG_Result.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_Result_CellClick);
            this.DG_Result.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_Result_CellContentClick);
            this.DG_Result.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_Result_DoubleClick);
            this.DG_Result.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_Result_CellClick);
            this.DG_Result.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellValueChanged);
            this.DG_Result.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DG_RH_DoubleClick);
            // 
            // GB_AccountStatus
            // 
            this.GB_AccountStatus.Controls.Add(this.label2);
            this.GB_AccountStatus.Controls.Add(this.label1);
            this.GB_AccountStatus.Controls.Add(this.LB_IsAccountDisabled_R);
            this.GB_AccountStatus.Controls.Add(this.LB_IsAccountLockout_R);
            resources.ApplyResources(this.GB_AccountStatus, "GB_AccountStatus");
            this.GB_AccountStatus.Name = "GB_AccountStatus";
            this.GB_AccountStatus.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // BT_Update
            // 
            resources.ApplyResources(this.BT_Update, "BT_Update");
            this.BT_Update.Name = "BT_Update";
            this.BT_Update.UseVisualStyleBackColor = true;
            this.BT_Update.Click += new System.EventHandler(this.BT_Update_Click);
            // 
            // LB_SAMAccount
            // 
            resources.ApplyResources(this.LB_SAMAccount, "LB_SAMAccount");
            this.LB_SAMAccount.Name = "LB_SAMAccount";
            // 
            // LB_Password
            // 
            resources.ApplyResources(this.LB_Password, "LB_Password");
            this.LB_Password.Name = "LB_Password";
            // 
            // GB_Update
            // 
            this.GB_Update.Controls.Add(this.TB_SAMAccount);
            this.GB_Update.Controls.Add(this.LB_Password);
            this.GB_Update.Controls.Add(this.TB_Password);
            this.GB_Update.Controls.Add(this.LB_SAMAccount);
            resources.ApplyResources(this.GB_Update, "GB_Update");
            this.GB_Update.Name = "GB_Update";
            this.GB_Update.TabStop = false;
            // 
            // BT_Import
            // 
            resources.ApplyResources(this.BT_Import, "BT_Import");
            this.BT_Import.Name = "BT_Import";
            this.BT_Import.UseVisualStyleBackColor = true;
            this.BT_Import.Click += new System.EventHandler(this.BT_Import_Click);
            // 
            // LB_Importtip
            // 
            resources.ApplyResources(this.LB_Importtip, "LB_Importtip");
            this.LB_Importtip.ForeColor = System.Drawing.Color.Red;
            this.LB_Importtip.Name = "LB_Importtip";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage1.Controls.Add(this.CB_UPN);
            this.tabPage1.Controls.Add(this.LB_UPN);
            this.tabPage1.Controls.Add(this.TB_UPN);
            this.tabPage1.Controls.Add(this.LB_LDAP_Example);
            this.tabPage1.Controls.Add(this.CB_LDAP);
            this.tabPage1.Controls.Add(this.LB_LDAP);
            this.tabPage1.Controls.Add(this.TB_LDAP);
            this.tabPage1.Controls.Add(this.CB_Unlock);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.TB_Search);
            this.tabPage1.Controls.Add(this.LB_Search);
            this.tabPage1.Controls.Add(this.GB_AccountStatus);
            this.tabPage1.Controls.Add(this.BT_Update);
            this.tabPage1.Controls.Add(this.GB_Update);
            this.tabPage1.Controls.Add(this.DG_Result);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            // 
            // CB_UPN
            // 
            resources.ApplyResources(this.CB_UPN, "CB_UPN");
            this.CB_UPN.Name = "CB_UPN";
            this.CB_UPN.CheckStateChanged += new System.EventHandler(this.CB_UPN_CheckStateChanged);
            // 
            // LB_UPN
            // 
            resources.ApplyResources(this.LB_UPN, "LB_UPN");
            this.LB_UPN.Name = "LB_UPN";
            // 
            // TB_UPN
            // 
            resources.ApplyResources(this.TB_UPN, "TB_UPN");
            this.TB_UPN.Name = "TB_UPN";
            // 
            // LB_LDAP_Example
            // 
            resources.ApplyResources(this.LB_LDAP_Example, "LB_LDAP_Example");
            this.LB_LDAP_Example.Name = "LB_LDAP_Example";
            this.LB_LDAP_Example.DoubleClick += new System.EventHandler(this.LB_LDAP_Example_DoubleClick);
            // 
            // CB_LDAP
            // 
            resources.ApplyResources(this.CB_LDAP, "CB_LDAP");
            this.CB_LDAP.Name = "CB_LDAP";
            this.CB_LDAP.UseVisualStyleBackColor = true;
            this.CB_LDAP.CheckStateChanged += new System.EventHandler(this.CB_LDAP_CheckStateChanged);
            // 
            // LB_LDAP
            // 
            resources.ApplyResources(this.LB_LDAP, "LB_LDAP");
            this.LB_LDAP.Name = "LB_LDAP";
            // 
            // TB_LDAP
            // 
            resources.ApplyResources(this.TB_LDAP, "TB_LDAP");
            this.TB_LDAP.Name = "TB_LDAP";
            // 
            // CB_Unlock
            // 
            resources.ApplyResources(this.CB_Unlock, "CB_Unlock");
            this.CB_Unlock.Name = "CB_Unlock";
            this.CB_Unlock.UseVisualStyleBackColor = true;
            this.CB_Unlock.CheckStateChanged += new System.EventHandler(this.CB_Unlock_CheckStateChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BT_RstPwd);
            this.groupBox1.Controls.Add(this.CB_MustCHGPWD);
            this.groupBox1.Controls.Add(this.TB_RstAccount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TB_RstPwd);
            this.groupBox1.Controls.Add(this.label4);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // BT_RstPwd
            // 
            resources.ApplyResources(this.BT_RstPwd, "BT_RstPwd");
            this.BT_RstPwd.Name = "BT_RstPwd";
            this.BT_RstPwd.UseVisualStyleBackColor = true;
            this.BT_RstPwd.Click += new System.EventHandler(this.BT_RstPwd_Click);
            // 
            // CB_MustCHGPWD
            // 
            resources.ApplyResources(this.CB_MustCHGPWD, "CB_MustCHGPWD");
            this.CB_MustCHGPWD.Name = "CB_MustCHGPWD";
            this.CB_MustCHGPWD.UseVisualStyleBackColor = true;
            // 
            // TB_RstAccount
            // 
            resources.ApplyResources(this.TB_RstAccount, "TB_RstAccount");
            this.TB_RstAccount.Name = "TB_RstAccount";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // TB_RstPwd
            // 
            resources.ApplyResources(this.TB_RstPwd, "TB_RstPwd");
            this.TB_RstPwd.Name = "TB_RstPwd";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.BT_EFB_Import);
            this.tabPage2.Controls.Add(this.LB_Processing);
            this.tabPage2.Controls.Add(this.LB_Total);
            this.tabPage2.Controls.Add(this.BT_ChnConvert);
            this.tabPage2.Controls.Add(this.LB_Importtip);
            this.tabPage2.Controls.Add(this.BT_Import);
            this.tabPage2.Controls.Add(this.TB_Import);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.PB_Import);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Name = "label6";
            // 
            // BT_EFB_Import
            // 
            resources.ApplyResources(this.BT_EFB_Import, "BT_EFB_Import");
            this.BT_EFB_Import.Name = "BT_EFB_Import";
            this.BT_EFB_Import.UseVisualStyleBackColor = true;
            this.BT_EFB_Import.Click += new System.EventHandler(this.BT_EFB_Import_Click);
            // 
            // LB_Processing
            // 
            resources.ApplyResources(this.LB_Processing, "LB_Processing");
            this.LB_Processing.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LB_Processing.Name = "LB_Processing";
            // 
            // LB_Total
            // 
            resources.ApplyResources(this.LB_Total, "LB_Total");
            this.LB_Total.Name = "LB_Total";
            // 
            // BT_ChnConvert
            // 
            resources.ApplyResources(this.BT_ChnConvert, "BT_ChnConvert");
            this.BT_ChnConvert.Name = "BT_ChnConvert";
            this.BT_ChnConvert.UseVisualStyleBackColor = true;
            this.BT_ChnConvert.Click += new System.EventHandler(this.BT_ChnConvert_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // PB_Import
            // 
            resources.ApplyResources(this.PB_Import, "PB_Import");
            this.PB_Import.Name = "PB_Import";
            // 
            // HCS_MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "HCS_MainForm";
            this.Load += new System.EventHandler(this.HCS_MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DG_Result)).EndInit();
            this.GB_AccountStatus.ResumeLayout(false);
            this.GB_AccountStatus.PerformLayout();
            this.GB_Update.ResumeLayout(false);
            this.GB_Update.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TB_Import;
        private System.Windows.Forms.TextBox TB_SAMAccount;
        private System.Windows.Forms.Label LB_IsAccountDisabled_R;
        private System.Windows.Forms.Label LB_IsAccountLockout_R;
        private System.Windows.Forms.TextBox TB_Password;
        private System.Windows.Forms.Label LB_Search;
        private System.Windows.Forms.TextBox TB_Search;
        private System.Windows.Forms.DataGridView DG_Result;
        private System.Windows.Forms.GroupBox GB_AccountStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_Update;
        private System.Windows.Forms.Label LB_SAMAccount;
        private System.Windows.Forms.Label LB_Password;
        private System.Windows.Forms.GroupBox GB_Update;
        private System.Windows.Forms.Button BT_Import;
        private System.Windows.Forms.Label LB_Importtip;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BT_RstPwd;
        private System.Windows.Forms.CheckBox CB_MustCHGPWD;
        private System.Windows.Forms.TextBox TB_RstAccount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_RstPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BT_ChnConvert;
        private System.Windows.Forms.Label LB_Total;
        private System.Windows.Forms.Label LB_Processing;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox CB_Unlock;
        private System.Windows.Forms.ProgressBar PB_Import;
        private System.Windows.Forms.Label LB_LDAP;
        private System.Windows.Forms.TextBox TB_LDAP;
        private System.Windows.Forms.CheckBox CB_LDAP;
        private System.Windows.Forms.Label LB_LDAP_Example;
        private System.Windows.Forms.Label LB_UPN;
        private System.Windows.Forms.TextBox TB_UPN;
        private System.Windows.Forms.CheckBox CB_UPN;
        private System.Windows.Forms.Button BT_EFB_Import;
        private System.Windows.Forms.Label label6;
    }
}

