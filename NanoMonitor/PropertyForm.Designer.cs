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
            this._tbAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._bTest = new System.Windows.Forms.Button();
            this._bSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _tbAddress
            // 
            this._tbAddress.Enabled = false;
            this._tbAddress.Location = new System.Drawing.Point(106, 12);
            this._tbAddress.Name = "_tbAddress";
            this._tbAddress.ReadOnly = true;
            this._tbAddress.Size = new System.Drawing.Size(327, 20);
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
            this._bSave.Location = new System.Drawing.Point(338, 212);
            this._bSave.Name = "_bSave";
            this._bSave.Size = new System.Drawing.Size(95, 23);
            this._bSave.TabIndex = 2;
            this._bSave.Text = "Сохранить";
            this._bSave.UseVisualStyleBackColor = true;
            // 
            // PropertyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 247);
            this.Controls.Add(this._bSave);
            this.Controls.Add(this._bTest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._tbAddress);
            this.Name = "PropertyForm";
            this.Text = "Свойства системы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _tbAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _bTest;
        private System.Windows.Forms.Button _bSave;
    }
}

