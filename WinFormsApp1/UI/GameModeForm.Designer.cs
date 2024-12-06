namespace WinFormsApp1.UI
{
    partial class GameModeForm
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
            _statusStrip = new StatusStrip();
            _currentShotNumberToolStripLabel = new ToolStripStatusLabel();
            _shotHistoryListBox = new ListBox();
            _currentTurnLabel = new Label();
            _placeShipsButton = new Button();
            _toResultsButton = new Button();
            _player1PlayingFieldTableLayoutPanel = new TableLayoutPanel();
            _player2PlayingFieldTableLayoutPanel = new TableLayoutPanel();
            _statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // _statusStrip
            // 
            _statusStrip.Items.AddRange(new ToolStripItem[] { _currentShotNumberToolStripLabel });
            _statusStrip.Location = new Point(5, 430);
            _statusStrip.Name = "_statusStrip";
            _statusStrip.Size = new Size(770, 22);
            _statusStrip.TabIndex = 7;
            _statusStrip.Text = "_statusStrip";
            // 
            // _currentShotNumberToolStripLabel
            // 
            _currentShotNumberToolStripLabel.Name = "_currentShotNumberToolStripLabel";
            _currentShotNumberToolStripLabel.Size = new Size(0, 17);
            // 
            // _shotHistoryListBox
            // 
            _shotHistoryListBox.FormattingEnabled = true;
            _shotHistoryListBox.ItemHeight = 17;
            _shotHistoryListBox.Location = new Point(244, 8);
            _shotHistoryListBox.Name = "_shotHistoryListBox";
            _shotHistoryListBox.SelectionMode = SelectionMode.None;
            _shotHistoryListBox.Size = new Size(290, 72);
            _shotHistoryListBox.TabIndex = 0;
            // 
            // _currentTurnLabel
            // 
            _currentTurnLabel.Location = new Point(318, 95);
            _currentTurnLabel.Name = "_currentTurnLabel";
            _currentTurnLabel.Size = new Size(149, 23);
            _currentTurnLabel.TabIndex = 1;
            _currentTurnLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _placeShipsButton
            // 
            _placeShipsButton.Location = new Point(10, 34);
            _placeShipsButton.Name = "_placeShipsButton";
            _placeShipsButton.Size = new Size(200, 30);
            _placeShipsButton.TabIndex = 2;
            _placeShipsButton.Text = "Place ships";
            _placeShipsButton.UseVisualStyleBackColor = true;
            // 
            // _toResultsButton
            // 
            _toResultsButton.Location = new Point(572, 34);
            _toResultsButton.Name = "_toResultsButton";
            _toResultsButton.Size = new Size(200, 30);
            _toResultsButton.TabIndex = 4;
            _toResultsButton.Text = "Finish game";
            _toResultsButton.UseVisualStyleBackColor = true;
            _toResultsButton.Visible = false;
            // 
            // _player1PlayingFieldTableLayoutPanel
            // 
            _player1PlayingFieldTableLayoutPanel.ColumnCount = 2;
            _player1PlayingFieldTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _player1PlayingFieldTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _player1PlayingFieldTableLayoutPanel.Enabled = false;
            _player1PlayingFieldTableLayoutPanel.Location = new Point(10, 88);
            _player1PlayingFieldTableLayoutPanel.Margin = new Padding(5);
            _player1PlayingFieldTableLayoutPanel.Name = "_player1PlayingFieldTableLayoutPanel";
            _player1PlayingFieldTableLayoutPanel.RowCount = 2;
            _player1PlayingFieldTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            _player1PlayingFieldTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            _player1PlayingFieldTableLayoutPanel.Size = new Size(330, 330);
            _player1PlayingFieldTableLayoutPanel.TabIndex = 5;
            // 
            // _player2PlayingFieldTableLayoutPanel
            // 
            _player2PlayingFieldTableLayoutPanel.ColumnCount = 2;
            _player2PlayingFieldTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _player2PlayingFieldTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _player2PlayingFieldTableLayoutPanel.Enabled = false;
            _player2PlayingFieldTableLayoutPanel.Location = new Point(440, 88);
            _player2PlayingFieldTableLayoutPanel.Margin = new Padding(5);
            _player2PlayingFieldTableLayoutPanel.Name = "_player2PlayingFieldTableLayoutPanel";
            _player2PlayingFieldTableLayoutPanel.RowCount = 2;
            _player2PlayingFieldTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            _player2PlayingFieldTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            _player2PlayingFieldTableLayoutPanel.Size = new Size(330, 330);
            _player2PlayingFieldTableLayoutPanel.TabIndex = 6;
            // 
            // GameModeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 457);
            Controls.Add(_statusStrip);
            Controls.Add(_player2PlayingFieldTableLayoutPanel);
            Controls.Add(_player1PlayingFieldTableLayoutPanel);
            Controls.Add(_toResultsButton);
            Controls.Add(_placeShipsButton);
            Controls.Add(_currentTurnLabel);
            Controls.Add(_shotHistoryListBox);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "GameModeForm";
            Padding = new Padding(5);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sea Battle Game";
            _statusStrip.ResumeLayout(false);
            _statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip _statusStrip;
        private ToolStripStatusLabel _currentShotNumberToolStripLabel;
        private ListBox _shotHistoryListBox;
        private Label _currentTurnLabel;
        private Button _placeShipsButton;
        private Button _toResultsButton;
        private TableLayoutPanel _player1PlayingFieldTableLayoutPanel;
        private TableLayoutPanel _player2PlayingFieldTableLayoutPanel;
    }
}