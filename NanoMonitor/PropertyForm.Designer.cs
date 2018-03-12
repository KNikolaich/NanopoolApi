namespace NanoMonitor
{
    partial class PropertyForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertyForm));
            this._tbAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._bTest = new System.Windows.Forms.Button();
            this._bSave = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._timerRefreshData = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tbAddress
            // 
            this._tbAddress.Enabled = false;
            this._tbAddress.Location = new System.Drawing.Point(106, 12);
            this._tbAddress.Name = "_tbAddress";
            this._tbAddress.ReadOnly = true;
            this._tbAddress.Size = new System.Drawing.Size(273, 20);
            this._tbAddress.TabIndex = 0;
            this._tbAddress.Text = "0x13c90C011E0524793561dE63F2809Eb6723eb195";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Адрес аккаунта:";
            // 
            // _bTest
            // 
            this._bTest.Location = new System.Drawing.Point(13, 212);
            this._bTest.Name = "_bTest";
            this._bTest.Size = new System.Drawing.Size(95, 23);
            this._bTest.TabIndex = 2;
            this._bTest.Text = "Тестировать";
            this._bTest.UseVisualStyleBackColor = true;
            this._bTest.Click += new System.EventHandler(this._bTest_Click);
            // 
            // _bSave
            // 
            this._bSave.Location = new System.Drawing.Point(284, 212);
            this._bSave.Name = "_bSave";
            this._bSave.Size = new System.Drawing.Size(95, 23);
            this._bSave.TabIndex = 2;
            this._bSave.Text = "Сохранить";
            this._bSave.UseVisualStyleBackColor = true;
            this._bSave.Click += new System.EventHandler(this._bSave_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._settingToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(141, 48);
            // 
            // _settingToolStripMenuItem
            // 
            this._settingToolStripMenuItem.Name = "_settingToolStripMenuItem";
            this._settingToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this._settingToolStripMenuItem.Text = "Настройки...";
            this._settingToolStripMenuItem.Click += new System.EventHandler(this._settingToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.exitToolStripMenuItem.Text = "Выход.";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // _timerRefreshData
            // 
            this._timerRefreshData.Enabled = true;
            this._timerRefreshData.Interval = 600000;
            this._timerRefreshData.Tick += new System.EventHandler(this._timerRefreshData_Tick);
            // 
            // PropertyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 240);
            this.Controls.Add(this._bSave);
            this.Controls.Add(this._bTest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._tbAddress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PropertyForm";
            this.Text = "Свойства системы";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _tbAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _bTest;
        private System.Windows.Forms.Button _bSave;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer _timerRefreshData;
    }
}

