﻿namespace NanoMonitor
{
    partial class EmptyForm
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
            this._tbLogs = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _tbLogs
            // 
            this._tbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tbLogs.Location = new System.Drawing.Point(0, 0);
            this._tbLogs.Multiline = true;
            this._tbLogs.Name = "_tbLogs";
            this._tbLogs.Size = new System.Drawing.Size(292, 273);
            this._tbLogs.TabIndex = 1;
            // 
            // EmptyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this._tbLogs);
            this.Name = "EmptyForm";
            this.Text = "EmptyForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _tbLogs;
    }
}