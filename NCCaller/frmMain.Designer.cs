namespace NCCaller
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.L3Session = new AppSvrIF.Session(this.components);
            this.Adapter = new AppSvrHMI.L3Adapter(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearSent = new System.Windows.Forms.Button();
            this.btnDelSent = new System.Windows.Forms.Button();
            this.btnClearFailed = new System.Windows.Forms.Button();
            this.btnDelFailed = new System.Windows.Forms.Button();
            this.lstFailed = new System.Windows.Forms.ListBox();
            this.lstSent = new System.Windows.Forms.ListBox();
            this.lstTypes = new System.Windows.Forms.ListBox();
            this.txtMESServer = new System.Windows.Forms.TextBox();
            this.txtNCServer = new System.Windows.Forms.TextBox();
            this.bbtnExit = new System.Windows.Forms.Button();
            this.pbMESStatus = new System.Windows.Forms.PictureBox();
            this.pbNCStatus = new System.Windows.Forms.PictureBox();
            this.timerCheck = new System.Windows.Forms.Timer(this.components);
            this.dsLog = new AppSvrHMI.L3DataSet();
            this.schemadsLog = new System.Data.DataTable();
            this.coldsLogL3DataTableGUID = new System.Data.DataColumn();
            this.coldsLogL3DataTableName = new System.Data.DataColumn();
            this.coldsLogL3DataTableHeatID = new System.Data.DataColumn();
            this.coldsLogL3DataTableBillType = new System.Data.DataColumn();
            this.coldsLogL3DataTableFlag = new System.Data.DataColumn();
            this.coldsLogL3DataTableRemark = new System.Data.DataColumn();
            this.coldsLogL3DataTableCreateTime = new System.Data.DataColumn();
            this.coldsLogL3DataTableOther1 = new System.Data.DataColumn();
            this.coldsLogL3DataTableOther2 = new System.Data.DataColumn();
            this.coldsLogL3DataTableOther3 = new System.Data.DataColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMESStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNCStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schemadsLog)).BeginInit();
            this.SuspendLayout();
            // 
            // L3Session
            // 
            this.L3Session.ConnectionStr = null;
            this.L3Session.Password = null;
            this.L3Session.TimeOut = ((uint)(4294967295u));
            this.L3Session.User = null;
            // 
            // Adapter
            // 
            this.Adapter.Session = this.L3Session;
            this.Adapter.OnObjectPropChanged += new AppSvrHMI.Delegate_OnObjectPropChanged(this.Adapter_OnObjectPropChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "MES服务器：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "NC服务器：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearSent);
            this.groupBox1.Controls.Add(this.btnDelSent);
            this.groupBox1.Controls.Add(this.btnClearFailed);
            this.groupBox1.Controls.Add(this.btnDelFailed);
            this.groupBox1.Controls.Add(this.lstFailed);
            this.groupBox1.Controls.Add(this.lstSent);
            this.groupBox1.Controls.Add(this.lstTypes);
            this.groupBox1.Location = new System.Drawing.Point(27, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(469, 337);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "上传日志";
            // 
            // btnClearSent
            // 
            this.btnClearSent.Location = new System.Drawing.Point(211, 305);
            this.btnClearSent.Name = "btnClearSent";
            this.btnClearSent.Size = new System.Drawing.Size(48, 26);
            this.btnClearSent.TabIndex = 2;
            this.btnClearSent.Text = "全删";
            this.btnClearSent.UseVisualStyleBackColor = true;
            // 
            // btnDelSent
            // 
            this.btnDelSent.Location = new System.Drawing.Point(265, 305);
            this.btnDelSent.Name = "btnDelSent";
            this.btnDelSent.Size = new System.Drawing.Size(34, 26);
            this.btnDelSent.TabIndex = 2;
            this.btnDelSent.Text = "删";
            this.btnDelSent.UseVisualStyleBackColor = true;
            // 
            // btnClearFailed
            // 
            this.btnClearFailed.Location = new System.Drawing.Point(366, 305);
            this.btnClearFailed.Name = "btnClearFailed";
            this.btnClearFailed.Size = new System.Drawing.Size(48, 26);
            this.btnClearFailed.TabIndex = 2;
            this.btnClearFailed.Text = "全删";
            this.btnClearFailed.UseVisualStyleBackColor = true;
            // 
            // btnDelFailed
            // 
            this.btnDelFailed.Location = new System.Drawing.Point(420, 305);
            this.btnDelFailed.Name = "btnDelFailed";
            this.btnDelFailed.Size = new System.Drawing.Size(34, 26);
            this.btnDelFailed.TabIndex = 2;
            this.btnDelFailed.Text = "删";
            this.btnDelFailed.UseVisualStyleBackColor = true;
            // 
            // lstFailed
            // 
            this.lstFailed.FormattingEnabled = true;
            this.lstFailed.ItemHeight = 12;
            this.lstFailed.Location = new System.Drawing.Point(306, 25);
            this.lstFailed.Name = "lstFailed";
            this.lstFailed.Size = new System.Drawing.Size(148, 268);
            this.lstFailed.Sorted = true;
            this.lstFailed.TabIndex = 1;
            // 
            // lstSent
            // 
            this.lstSent.FormattingEnabled = true;
            this.lstSent.ItemHeight = 12;
            this.lstSent.Location = new System.Drawing.Point(159, 25);
            this.lstSent.Name = "lstSent";
            this.lstSent.Size = new System.Drawing.Size(141, 268);
            this.lstSent.Sorted = true;
            this.lstSent.TabIndex = 1;
            this.lstSent.DoubleClick += new System.EventHandler(this.LogFile_DoubleClicked);
            // 
            // lstTypes
            // 
            this.lstTypes.FormattingEnabled = true;
            this.lstTypes.ItemHeight = 12;
            this.lstTypes.Location = new System.Drawing.Point(17, 25);
            this.lstTypes.Name = "lstTypes";
            this.lstTypes.Size = new System.Drawing.Size(123, 268);
            this.lstTypes.TabIndex = 0;
            // 
            // txtMESServer
            // 
            this.txtMESServer.Location = new System.Drawing.Point(109, 7);
            this.txtMESServer.Name = "txtMESServer";
            this.txtMESServer.ReadOnly = true;
            this.txtMESServer.Size = new System.Drawing.Size(278, 21);
            this.txtMESServer.TabIndex = 2;
            // 
            // txtNCServer
            // 
            this.txtNCServer.Location = new System.Drawing.Point(109, 31);
            this.txtNCServer.Name = "txtNCServer";
            this.txtNCServer.ReadOnly = true;
            this.txtNCServer.Size = new System.Drawing.Size(278, 21);
            this.txtNCServer.TabIndex = 2;
            // 
            // bbtnExit
            // 
            this.bbtnExit.Location = new System.Drawing.Point(429, 7);
            this.bbtnExit.Name = "bbtnExit";
            this.bbtnExit.Size = new System.Drawing.Size(67, 45);
            this.bbtnExit.TabIndex = 3;
            this.bbtnExit.Text = "退出";
            this.bbtnExit.UseVisualStyleBackColor = true;
            this.bbtnExit.Click += new System.EventHandler(this.bbtnExit_Click);
            // 
            // pbMESStatus
            // 
            this.pbMESStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMESStatus.Location = new System.Drawing.Point(393, 7);
            this.pbMESStatus.Name = "pbMESStatus";
            this.pbMESStatus.Size = new System.Drawing.Size(25, 25);
            this.pbMESStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMESStatus.TabIndex = 4;
            this.pbMESStatus.TabStop = false;
            // 
            // pbNCStatus
            // 
            this.pbNCStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbNCStatus.Location = new System.Drawing.Point(393, 32);
            this.pbNCStatus.Name = "pbNCStatus";
            this.pbNCStatus.Size = new System.Drawing.Size(25, 25);
            this.pbNCStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNCStatus.TabIndex = 4;
            this.pbNCStatus.TabStop = false;
            // 
            // timerCheck
            // 
            this.timerCheck.Enabled = true;
            this.timerCheck.Interval = 2000;
            this.timerCheck.Tick += new System.EventHandler(this.timerCheck_Tick);
            // 
            // dsLog
            // 
            this.dsLog.AutoSubscribe = true;
            this.dsLog.DataSetName = "L3DataSet";
            this.dsLog.DeleteMethod = "";
            this.dsLog.InsertMethod = "";
            this.dsLog.L3DataAdapter = null;
            this.dsLog.LoadEvent = "";
            this.dsLog.LoadTrigger = null;
            this.dsLog.RefreshValve = 1000;
            this.dsLog.SourceCommand = null;
            this.dsLog.SourceCondition = "";
            this.dsLog.SourceMethod = "";
            this.dsLog.SourceType = AppSvrHMI.L3DataSetSourceType.Class;
            this.dsLog.SourceURI = "";
            this.dsLog.SubscribeTarget = "";
            this.dsLog.Tables.AddRange(new System.Data.DataTable[] {
            this.schemadsLog});
            this.dsLog.UpdateEvent = "";
            this.dsLog.UpdateMethod = "";
            this.dsLog.UpdateTrigger = null;
            // 
            // schemadsLog
            // 
            this.schemadsLog.Columns.AddRange(new System.Data.DataColumn[] {
            this.coldsLogL3DataTableGUID,
            this.coldsLogL3DataTableName,
            this.coldsLogL3DataTableHeatID,
            this.coldsLogL3DataTableBillType,
            this.coldsLogL3DataTableFlag,
            this.coldsLogL3DataTableRemark,
            this.coldsLogL3DataTableCreateTime,
            this.coldsLogL3DataTableOther1,
            this.coldsLogL3DataTableOther2,
            this.coldsLogL3DataTableOther3});
            this.schemadsLog.TableName = "L3DataTable";
            // 
            // coldsLogL3DataTableGUID
            // 
            this.coldsLogL3DataTableGUID.Caption = "GUID";
            this.coldsLogL3DataTableGUID.ColumnName = "GUID";
            this.coldsLogL3DataTableGUID.Namespace = "";
            // 
            // coldsLogL3DataTableName
            // 
            this.coldsLogL3DataTableName.Caption = "Name";
            this.coldsLogL3DataTableName.ColumnName = "Name";
            this.coldsLogL3DataTableName.Namespace = "";
            // 
            // coldsLogL3DataTableHeatID
            // 
            this.coldsLogL3DataTableHeatID.Caption = "HeatID";
            this.coldsLogL3DataTableHeatID.ColumnName = "HeatID";
            this.coldsLogL3DataTableHeatID.Namespace = "";
            // 
            // coldsLogL3DataTableBillType
            // 
            this.coldsLogL3DataTableBillType.Caption = "BillType";
            this.coldsLogL3DataTableBillType.ColumnName = "BillType";
            this.coldsLogL3DataTableBillType.Namespace = "";
            // 
            // coldsLogL3DataTableFlag
            // 
            this.coldsLogL3DataTableFlag.Caption = "Flag";
            this.coldsLogL3DataTableFlag.ColumnName = "Flag";
            this.coldsLogL3DataTableFlag.Namespace = "";
            // 
            // coldsLogL3DataTableRemark
            // 
            this.coldsLogL3DataTableRemark.Caption = "Remark";
            this.coldsLogL3DataTableRemark.ColumnName = "Remark";
            this.coldsLogL3DataTableRemark.Namespace = "";
            // 
            // coldsLogL3DataTableCreateTime
            // 
            this.coldsLogL3DataTableCreateTime.Caption = "CreateTime";
            this.coldsLogL3DataTableCreateTime.ColumnName = "CreateTime";
            this.coldsLogL3DataTableCreateTime.DataType = typeof(System.DateTime);
            this.coldsLogL3DataTableCreateTime.Namespace = "";
            // 
            // coldsLogL3DataTableOther1
            // 
            this.coldsLogL3DataTableOther1.Caption = "Other1";
            this.coldsLogL3DataTableOther1.ColumnName = "Other1";
            this.coldsLogL3DataTableOther1.Namespace = "";
            // 
            // coldsLogL3DataTableOther2
            // 
            this.coldsLogL3DataTableOther2.Caption = "Other2";
            this.coldsLogL3DataTableOther2.ColumnName = "Other2";
            this.coldsLogL3DataTableOther2.Namespace = "";
            // 
            // coldsLogL3DataTableOther3
            // 
            this.coldsLogL3DataTableOther3.Caption = "Other3";
            this.coldsLogL3DataTableOther3.ColumnName = "Other3";
            this.coldsLogL3DataTableOther3.Namespace = "";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 407);
            this.Controls.Add(this.pbNCStatus);
            this.Controls.Add(this.pbMESStatus);
            this.Controls.Add(this.bbtnExit);
            this.Controls.Add(this.txtNCServer);
            this.Controls.Add(this.txtMESServer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "frmMain";
            this.Text = "上传NC接口程序";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMESStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNCStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schemadsLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AppSvrIF.Session L3Session;
        private AppSvrHMI.L3Adapter Adapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMESServer;
        private System.Windows.Forms.TextBox txtNCServer;
        private System.Windows.Forms.Button bbtnExit;
        private System.Windows.Forms.ListBox lstSent;
        private System.Windows.Forms.ListBox lstTypes;
        private System.Windows.Forms.PictureBox pbMESStatus;
        private System.Windows.Forms.PictureBox pbNCStatus;
        private System.Windows.Forms.Timer timerCheck;
        private System.Windows.Forms.ListBox lstFailed;
        private System.Windows.Forms.Button btnClearSent;
        private System.Windows.Forms.Button btnDelSent;
        private System.Windows.Forms.Button btnClearFailed;
        private System.Windows.Forms.Button btnDelFailed;
        private AppSvrHMI.L3DataSet dsLog;
        private System.Data.DataTable schemadsLog;
        private System.Data.DataColumn coldsLogL3DataTableGUID;
        private System.Data.DataColumn coldsLogL3DataTableName;
        private System.Data.DataColumn coldsLogL3DataTableHeatID;
        private System.Data.DataColumn coldsLogL3DataTableBillType;
        private System.Data.DataColumn coldsLogL3DataTableFlag;
        private System.Data.DataColumn coldsLogL3DataTableRemark;
        private System.Data.DataColumn coldsLogL3DataTableCreateTime;
        private System.Data.DataColumn coldsLogL3DataTableOther1;
        private System.Data.DataColumn coldsLogL3DataTableOther2;
        private System.Data.DataColumn coldsLogL3DataTableOther3;
    }
}