namespace MouseHolder
{
    partial class Form1
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
            this.hotKeyLabel = new System.Windows.Forms.Label();
            this.hotKeyChange = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lmButton = new System.Windows.Forms.CheckBox();
            this.mmButton = new System.Windows.Forms.CheckBox();
            this.rmButton = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // hotKeyLabel
            // 
            this.hotKeyLabel.Location = new System.Drawing.Point(12, 26);
            this.hotKeyLabel.Name = "hotKeyLabel";
            this.hotKeyLabel.Size = new System.Drawing.Size(145, 28);
            this.hotKeyLabel.TabIndex = 0;
            this.hotKeyLabel.Text = "ControlKey + H";
            this.hotKeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hotKeyChange
            // 
            this.hotKeyChange.Location = new System.Drawing.Point(163, 12);
            this.hotKeyChange.Name = "hotKeyChange";
            this.hotKeyChange.Size = new System.Drawing.Size(79, 35);
            this.hotKeyChange.TabIndex = 1;
            this.hotKeyChange.Text = "Change Hotkey";
            this.hotKeyChange.UseVisualStyleBackColor = true;
            this.hotKeyChange.Click += new System.EventHandler(this.hotKeyChange_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hotkey:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lmButton
            // 
            this.lmButton.Checked = true;
            this.lmButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lmButton.Location = new System.Drawing.Point(12, 100);
            this.lmButton.Name = "lmButton";
            this.lmButton.Size = new System.Drawing.Size(125, 26);
            this.lmButton.TabIndex = 6;
            this.lmButton.Text = "Left mouse button";
            this.lmButton.UseVisualStyleBackColor = true;
            this.lmButton.CheckedChanged += new System.EventHandler(this.lmButton_CheckedChanged);
            // 
            // mmButton
            // 
            this.mmButton.Location = new System.Drawing.Point(12, 132);
            this.mmButton.Name = "mmButton";
            this.mmButton.Size = new System.Drawing.Size(125, 26);
            this.mmButton.TabIndex = 7;
            this.mmButton.Text = "Middle mouse button";
            this.mmButton.UseVisualStyleBackColor = true;
            this.mmButton.CheckedChanged += new System.EventHandler(this.mmButton_CheckedChanged);
            // 
            // rmButton
            // 
            this.rmButton.Location = new System.Drawing.Point(12, 164);
            this.rmButton.Name = "rmButton";
            this.rmButton.Size = new System.Drawing.Size(125, 26);
            this.rmButton.TabIndex = 8;
            this.rmButton.Text = "Right mouse button";
            this.rmButton.UseVisualStyleBackColor = true;
            this.rmButton.CheckedChanged += new System.EventHandler(this.rmButton_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 223);
            this.Controls.Add(this.rmButton);
            this.Controls.Add(this.mmButton);
            this.Controls.Add(this.lmButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hotKeyChange);
            this.Controls.Add(this.hotKeyLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "MouseHolder";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.CheckBox rmButton;

        private System.Windows.Forms.CheckBox mmButton;

        private System.Windows.Forms.CheckBox lmButton;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Label hotKeyLabel;
        private System.Windows.Forms.Button hotKeyChange;

        #endregion
    }
}