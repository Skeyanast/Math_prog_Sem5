namespace WinFormsApp1.UI
{
    partial class ResultsForm
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
            _playerWinLabel = new Label();
            _shotCountLabel = new Label();
            _backToMenuButton = new Button();
            SuspendLayout();
            // 
            // _playerWinLabel
            // 
            _playerWinLabel.AutoSize = true;
            _playerWinLabel.Font = new Font("Cascadia Code", 12F);
            _playerWinLabel.Location = new Point(120, 90);
            _playerWinLabel.Name = "_playerWinLabel";
            _playerWinLabel.Size = new Size(127, 21);
            _playerWinLabel.TabIndex = 0;
            _playerWinLabel.Text = "Player № win!";
            // 
            // _shotCountLabel
            // 
            _shotCountLabel.AutoSize = true;
            _shotCountLabel.Font = new Font("Cascadia Code", 12F);
            _shotCountLabel.Location = new Point(120, 151);
            _shotCountLabel.Name = "_shotCountLabel";
            _shotCountLabel.Size = new Size(109, 21);
            _shotCountLabel.TabIndex = 1;
            _shotCountLabel.Text = "Shot count:";
            // 
            // _backToMenuButton
            // 
            _backToMenuButton.Enabled = false;
            _backToMenuButton.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            _backToMenuButton.Location = new Point(290, 397);
            _backToMenuButton.Name = "_backToMenuButton";
            _backToMenuButton.Size = new Size(200, 30);
            _backToMenuButton.TabIndex = 2;
            _backToMenuButton.Text = "Back to menu";
            _backToMenuButton.UseVisualStyleBackColor = true;
            // 
            // ResultsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 457);
            Controls.Add(_backToMenuButton);
            Controls.Add(_shotCountLabel);
            Controls.Add(_playerWinLabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "ResultsForm";
            Padding = new Padding(5);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Battle Results";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label _playerWinLabel;
        private Label _shotCountLabel;
        private Button _backToMenuButton;
    }
}