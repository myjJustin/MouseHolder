using System.ComponentModel;

namespace MouseHolder
{
    partial class GetHotkey
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Location = new System.Drawing.Point(12, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(294, 118);
            this.label.TabIndex = 0;
            this.label.Text = "Press Any Keys...";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GetHotKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 136);
            this.Controls.Add(this.label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetHotKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set you hotkey";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GetHotkey_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GetHotkey_KeyUp);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label;

        #endregion
    }
}