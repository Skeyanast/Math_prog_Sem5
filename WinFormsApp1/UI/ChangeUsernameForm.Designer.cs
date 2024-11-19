namespace WinFormsApp1.UI
{
    partial class ChangeUsernameForm
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
            _usernameTextBox = new TextBox();
            _saveButton = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            _usernameTextBox.Location = new Point(254, 94);
            _usernameTextBox.Name = "textBox1";
            _usernameTextBox.Size = new Size(232, 23);
            _usernameTextBox.TabIndex = 0;
            // 
            // button1
            // 
            _saveButton.Location = new Point(254, 165);
            _saveButton.Name = "button1";
            _saveButton.Size = new Size(232, 23);
            _saveButton.TabIndex = 1;
            _saveButton.Text = "Save";
            _saveButton.UseVisualStyleBackColor = true;
            // 
            // ChangeUsernameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(_saveButton);
            Controls.Add(_usernameTextBox);
            Name = "ChangeUsernameForm";
            Text = "ChangeUsernameForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox _usernameTextBox;
        private Button _saveButton;
    }
}