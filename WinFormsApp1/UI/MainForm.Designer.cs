namespace WinFormsApp1
{
    partial class MainForm
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
            _usernameLabel = new Label();
            _passwordLabel = new Label();
            _changeUsernameButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            _usernameLabel.AutoSize = true;
            _usernameLabel.Location = new Point(304, 99);
            _usernameLabel.Name = "label1";
            _usernameLabel.Size = new Size(56, 17);
            _usernameLabel.TabIndex = 0;
            _usernameLabel.Text = "label1";
            // 
            // label2
            // 
            _passwordLabel.AutoSize = true;
            _passwordLabel.Location = new Point(304, 150);
            _passwordLabel.Name = "label2";
            _passwordLabel.Size = new Size(56, 17);
            _passwordLabel.TabIndex = 1;
            _passwordLabel.Text = "label2";
            // 
            // button1
            // 
            _changeUsernameButton.Location = new Point(304, 236);
            _changeUsernameButton.Name = "button1";
            _changeUsernameButton.Size = new Size(176, 30);
            _changeUsernameButton.TabIndex = 2;
            _changeUsernameButton.Text = "Change username";
            _changeUsernameButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(_changeUsernameButton);
            Controls.Add(_passwordLabel);
            Controls.Add(_usernameLabel);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label _usernameLabel;
        private Label _passwordLabel;
        private Button _changeUsernameButton;
    }
}