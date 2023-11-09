namespace EncryptSoftware.UserControls
{
    partial class UC_Morse
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2ToggleSwitch1 = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.outputTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.inputTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Stencil", 13.8F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(833, 129);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 27);
            this.label2.TabIndex = 11;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 13.8F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(157, 129);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 27);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1";
            // 
            // guna2ToggleSwitch1
            // 
            this.guna2ToggleSwitch1.Animated = true;
            this.guna2ToggleSwitch1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ToggleSwitch1.CheckedState.FillColor = System.Drawing.Color.DarkOliveGreen;
            this.guna2ToggleSwitch1.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch1.CheckedState.InnerColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2ToggleSwitch1.Location = new System.Drawing.Point(593, 283);
            this.guna2ToggleSwitch1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2ToggleSwitch1.Name = "guna2ToggleSwitch1";
            this.guna2ToggleSwitch1.Size = new System.Drawing.Size(89, 30);
            this.guna2ToggleSwitch1.TabIndex = 9;
            this.guna2ToggleSwitch1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2ToggleSwitch1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(131)))), ((int)(((byte)(99)))));
            this.guna2ToggleSwitch1.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch1.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch1.CheckedChanged += new System.EventHandler(this.guna2ToggleSwitch1_CheckedChanged);
            // 
            // outputTextBox
            // 
            this.outputTextBox.BorderColor = System.Drawing.Color.Olive;
            this.outputTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.outputTextBox.DefaultText = "";
            this.outputTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.outputTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.outputTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.outputTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.outputTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(131)))), ((int)(((byte)(99)))));
            this.outputTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.outputTextBox.Font = new System.Drawing.Font("Stencil", 11F);
            this.outputTextBox.ForeColor = System.Drawing.Color.White;
            this.outputTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.outputTextBox.Location = new System.Drawing.Point(838, 160);
            this.outputTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.PasswordChar = '\0';
            this.outputTextBox.PlaceholderText = "";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.SelectedText = "";
            this.outputTextBox.Size = new System.Drawing.Size(267, 315);
            this.outputTextBox.TabIndex = 8;
            // 
            // inputTextBox
            // 
            this.inputTextBox.BorderColor = System.Drawing.Color.Olive;
            this.inputTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.inputTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.inputTextBox.DefaultText = "";
            this.inputTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.inputTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.inputTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.inputTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.inputTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(131)))), ((int)(((byte)(99)))));
            this.inputTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.inputTextBox.Font = new System.Drawing.Font("Stencil", 11F);
            this.inputTextBox.ForeColor = System.Drawing.Color.White;
            this.inputTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.inputTextBox.Location = new System.Drawing.Point(162, 160);
            this.inputTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.PasswordChar = '\0';
            this.inputTextBox.PlaceholderText = "";
            this.inputTextBox.SelectedText = "";
            this.inputTextBox.Size = new System.Drawing.Size(267, 315);
            this.inputTextBox.TabIndex = 7;
            this.inputTextBox.TextChanged += new System.EventHandler(this.inputTextBox_TextChanged);
            // 
            // UC_Morse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(71)))), ((int)(((byte)(58)))));
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2ToggleSwitch1);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.inputTextBox);
            this.Name = "UC_Morse";
            this.Size = new System.Drawing.Size(1262, 605);
            this.Load += new System.EventHandler(this.UC_Morse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ToggleSwitch guna2ToggleSwitch1;
        private Guna.UI2.WinForms.Guna2TextBox outputTextBox;
        private Guna.UI2.WinForms.Guna2TextBox inputTextBox;
    }
}
