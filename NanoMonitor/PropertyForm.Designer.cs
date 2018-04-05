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
            this._notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._timerRefreshData = new System.Windows.Forms.Timer(this.components);
            this._tbBalance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this._lAddressDb = new System.Windows.Forms.Label();
            this.testForm1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testForm2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tbAddress
            // 
            this._tbAddress.BackColor = System.Drawing.Color.WhiteSmoke;
            this._tbAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tbAddress.Enabled = false;
            this._tbAddress.Location = new System.Drawing.Point(101, 3);
            this._tbAddress.Name = "_tbAddress";
            this._tbAddress.ReadOnly = true;
            this._tbAddress.Size = new System.Drawing.Size(342, 20);
            this._tbAddress.TabIndex = 0;
            this._tbAddress.Text = "0x13c90C011E0524793561dE63F2809Eb6723eb195";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Адрес аккаунта:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _bTest
            // 
            this._bTest.Dock = System.Windows.Forms.DockStyle.Left;
            this._bTest.Location = new System.Drawing.Point(3, 446);
            this._bTest.Name = "_bTest";
            this._bTest.Size = new System.Drawing.Size(91, 21);
            this._bTest.TabIndex = 2;
            this._bTest.Text = "Тестировать";
            this._bTest.UseVisualStyleBackColor = true;
            this._bTest.Click += new System.EventHandler(this._bTest_Click);
            // 
            // _bSave
            // 
            this._bSave.Dock = System.Windows.Forms.DockStyle.Right;
            this._bSave.Location = new System.Drawing.Point(348, 446);
            this._bSave.Name = "_bSave";
            this._bSave.Size = new System.Drawing.Size(95, 21);
            this._bSave.TabIndex = 2;
            this._bSave.Text = "Скрыть";
            this._bSave.UseVisualStyleBackColor = true;
            this._bSave.Click += new System.EventHandler(this._bSave_Click);
            // 
            // _notifyIcon1
            // 
            this._notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this._notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("_notifyIcon1.Icon")));
            this._notifyIcon1.Text = "_notifyIcon1";
            this._notifyIcon1.Visible = true;
            this._notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._settingToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.testForm1ToolStripMenuItem,
            this.testForm2ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 114);
            // 
            // _settingToolStripMenuItem
            // 
            this._settingToolStripMenuItem.Name = "_settingToolStripMenuItem";
            this._settingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this._settingToolStripMenuItem.Text = "Настройки...";
            this._settingToolStripMenuItem.Click += new System.EventHandler(this._settingToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Выход.";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // _timerRefreshData
            // 
            this._timerRefreshData.Enabled = true;
            this._timerRefreshData.Interval = 600000;
            this._timerRefreshData.Tick += new System.EventHandler(this._timerRefreshData_Tick);
            // 
            // _tbBalance
            // 
            this._tbBalance.BackColor = System.Drawing.Color.WhiteSmoke;
            this._tbBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tbBalance.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._tbBalance.Location = new System.Drawing.Point(101, 31);
            this._tbBalance.Multiline = true;
            this._tbBalance.Name = "_tbBalance";
            this._tbBalance.ReadOnly = true;
            this._tbBalance.Size = new System.Drawing.Size(342, 390);
            this._tbBalance.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 396);
            this.label2.TabIndex = 1;
            this.label2.Text = "Баланс и курсы:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._tbBalance, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this._tbAddress, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this._bTest, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._bSave, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this._lAddressDb, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.650247F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.34975F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(446, 470);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 424);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Адрес БД:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _lAddressDb
            // 
            this._lAddressDb.AutoSize = true;
            this._lAddressDb.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lAddressDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._lAddressDb.Location = new System.Drawing.Point(101, 424);
            this._lAddressDb.Name = "_lAddressDb";
            this._lAddressDb.Size = new System.Drawing.Size(342, 19);
            this._lAddressDb.TabIndex = 7;
            this._lAddressDb.Text = "_lAddressDb";
            // 
            // testForm1ToolStripMenuItem
            // 
            this.testForm1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.testForm1ToolStripMenuItem.Name = "testForm1ToolStripMenuItem";
            this.testForm1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.testForm1ToolStripMenuItem.Text = "TestForm1";
            this.testForm1ToolStripMenuItem.Click += new System.EventHandler(this.testForm1ToolStripMenuItem_Click);
            // 
            // testForm2ToolStripMenuItem
            // 
            this.testForm2ToolStripMenuItem.Name = "testForm2ToolStripMenuItem";
            this.testForm2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.testForm2ToolStripMenuItem.Text = "TestForm2";
            this.testForm2ToolStripMenuItem.Click += new System.EventHandler(this.testForm2ToolStripMenuItem_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "DumpWebPage Без asygn ",
            "DumpWebPage C asygn ",
            "AddAFavIcon Without asygn",
            "AddAFavIcon With asygn"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 21);
            this.toolStripComboBox1.Click += new System.EventHandler(this.toolStripComboBox1_Click);
            // 
            // PropertyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 470);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PropertyForm";
            this.Text = "Свойства системы";
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox _tbAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _bTest;
        private System.Windows.Forms.Button _bSave;
        private System.Windows.Forms.NotifyIcon _notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer _timerRefreshData;
        private System.Windows.Forms.TextBox _tbBalance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label _lAddressDb;
        private System.Windows.Forms.ToolStripMenuItem testForm1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testForm2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
    }
}

