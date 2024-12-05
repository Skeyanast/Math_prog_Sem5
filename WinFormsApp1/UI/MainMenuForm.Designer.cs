namespace WinFormsApp1.UI
{
    partial class MainMenuForm
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
            _applicationTitleLabel = new Label();
            _playingFieldSizePickLabel = new Label();
            _playingFieldSizeNumericUpDown = new NumericUpDown();
            _startDemoModeButton = new Button();
            _startGameModeButton = new Button();
            ((System.ComponentModel.ISupportInitialize)_playingFieldSizeNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // _applicationTitleLabel
            // 
            _applicationTitleLabel.Dock = DockStyle.Top;
            _applicationTitleLabel.Font = new Font("Cascadia Code", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            _applicationTitleLabel.Location = new Point(5, 5);
            _applicationTitleLabel.Name = "_applicationTitleLabel";
            _applicationTitleLabel.Size = new Size(770, 80);
            _applicationTitleLabel.TabIndex = 0;
            _applicationTitleLabel.Text = "Sea Battle Game";
            _applicationTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _playingFieldSizePickLabel
            // 
            _playingFieldSizePickLabel.AutoSize = true;
            _playingFieldSizePickLabel.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            _playingFieldSizePickLabel.Location = new Point(297, 212);
            _playingFieldSizePickLabel.Name = "_playingFieldSizePickLabel";
            _playingFieldSizePickLabel.Size = new Size(172, 21);
            _playingFieldSizePickLabel.TabIndex = 1;
            _playingFieldSizePickLabel.Text = "Select field size:";
            // 
            // _playingFieldSizeNumericUpDown
            // 
            _playingFieldSizeNumericUpDown.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            _playingFieldSizeNumericUpDown.Location = new Point(475, 210);
            _playingFieldSizeNumericUpDown.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            _playingFieldSizeNumericUpDown.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
            _playingFieldSizeNumericUpDown.Name = "_playingFieldSizeNumericUpDown";
            _playingFieldSizeNumericUpDown.ReadOnly = true;
            _playingFieldSizeNumericUpDown.Size = new Size(52, 26);
            _playingFieldSizeNumericUpDown.TabIndex = 2;
            _playingFieldSizeNumericUpDown.TextAlign = HorizontalAlignment.Center;
            _playingFieldSizeNumericUpDown.Value = new decimal(new int[] { 7, 0, 0, 0 });
            // 
            // _startDemoModeButton
            // 
            _startDemoModeButton.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            _startDemoModeButton.Location = new Point(297, 339);
            _startDemoModeButton.Name = "_startDemoModeButton";
            _startDemoModeButton.Size = new Size(200, 30);
            _startDemoModeButton.TabIndex = 3;
            _startDemoModeButton.Text = "Demo";
            _startDemoModeButton.UseVisualStyleBackColor = true;
            // 
            // _startGameModeButton
            // 
            _startGameModeButton.Enabled = false;
            _startGameModeButton.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            _startGameModeButton.Location = new Point(297, 375);
            _startGameModeButton.Name = "_startGameModeButton";
            _startGameModeButton.Size = new Size(200, 30);
            _startGameModeButton.TabIndex = 4;
            _startGameModeButton.Text = "Game";
            _startGameModeButton.UseVisualStyleBackColor = true;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 457);
            Controls.Add(_startGameModeButton);
            Controls.Add(_startDemoModeButton);
            Controls.Add(_playingFieldSizeNumericUpDown);
            Controls.Add(_playingFieldSizePickLabel);
            Controls.Add(_applicationTitleLabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "MainMenuForm";
            Padding = new Padding(5);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainMenu";
            ((System.ComponentModel.ISupportInitialize)_playingFieldSizeNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label _applicationTitleLabel;
        private Label _playingFieldSizePickLabel;
        private NumericUpDown _playingFieldSizeNumericUpDown;
        private Button _startDemoModeButton;
        private Button _startGameModeButton;
    }
}