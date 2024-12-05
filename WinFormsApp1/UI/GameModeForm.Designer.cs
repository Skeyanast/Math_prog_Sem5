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
            currentShotNumberToolStripLabel = new ToolStripStatusLabel();
            _shotHistoryLabel = new ListBox();
            _currentTurnLabel = new Label();
            _firstPlayerPlaceShipsButton = new Button();
            _secondPlayerPlaceShipsButton = new Button();
            _toResultsButton = new Button();
            _firstPlayerPlayingFieldTableLayoutPanel = new TableLayoutPanel();
            _secondPlayerPlayingFieldTableLayoutPanel = new TableLayoutPanel();
            _statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // _statusStrip
            // 
            _statusStrip.Items.AddRange(new ToolStripItem[] { currentShotNumberToolStripLabel });
            _statusStrip.Location = new Point(5, 430);
            _statusStrip.Name = "_statusStrip";
            _statusStrip.Size = new Size(770, 22);
            _statusStrip.TabIndex = 7;
            _statusStrip.Text = "_statusStrip";
            // 
            // currentShotNumberToolStripLabel
            // 
            currentShotNumberToolStripLabel.Name = "currentShotNumberToolStripLabel";
            currentShotNumberToolStripLabel.Size = new Size(187, 17);
            currentShotNumberToolStripLabel.Text = "currentShotNumberToolStripLabel";
            // 
            // _shotHistoryLabel
            // 
            _shotHistoryLabel.FormattingEnabled = true;
            _shotHistoryLabel.ItemHeight = 17;
            _shotHistoryLabel.Location = new Point(277, 8);
            _shotHistoryLabel.Name = "_shotHistoryLabel";
            _shotHistoryLabel.SelectionMode = SelectionMode.None;
            _shotHistoryLabel.Size = new Size(223, 55);
            _shotHistoryLabel.TabIndex = 0;
            // 
            // _currentTurnLabel
            // 
            _currentTurnLabel.Location = new Point(277, 67);
            _currentTurnLabel.Name = "_currentTurnLabel";
            _currentTurnLabel.Size = new Size(223, 23);
            _currentTurnLabel.TabIndex = 1;
            _currentTurnLabel.Text = "'s player turn";
            _currentTurnLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _firstPlayerPlaceShipsButton
            // 
            _firstPlayerPlaceShipsButton.Location = new Point(60, 57);
            _firstPlayerPlaceShipsButton.Name = "_firstPlayerPlaceShipsButton";
            _firstPlayerPlaceShipsButton.Size = new Size(200, 30);
            _firstPlayerPlaceShipsButton.TabIndex = 2;
            _firstPlayerPlaceShipsButton.Text = "Place ships";
            _firstPlayerPlaceShipsButton.UseVisualStyleBackColor = true;
            // 
            // _secondPlayerPlaceShipsButton
            // 
            _secondPlayerPlaceShipsButton.Location = new Point(525, 57);
            _secondPlayerPlaceShipsButton.Name = "_secondPlayerPlaceShipsButton";
            _secondPlayerPlaceShipsButton.Size = new Size(200, 30);
            _secondPlayerPlaceShipsButton.TabIndex = 3;
            _secondPlayerPlaceShipsButton.Text = "Place ships";
            _secondPlayerPlaceShipsButton.UseVisualStyleBackColor = true;
            // 
            // _toResultsButton
            // 
            _toResultsButton.Location = new Point(291, 397);
            _toResultsButton.Name = "_toResultsButton";
            _toResultsButton.Size = new Size(200, 30);
            _toResultsButton.TabIndex = 4;
            _toResultsButton.Text = "Finish game";
            _toResultsButton.UseVisualStyleBackColor = true;
            // 
            // _firstPlayerPlayingFieldTableLayoutPanel
            // 
            _firstPlayerPlayingFieldTableLayoutPanel.ColumnCount = 2;
            _firstPlayerPlayingFieldTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _firstPlayerPlayingFieldTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _firstPlayerPlayingFieldTableLayoutPanel.Enabled = false;
            _firstPlayerPlayingFieldTableLayoutPanel.Location = new Point(10, 95);
            _firstPlayerPlayingFieldTableLayoutPanel.Margin = new Padding(5);
            _firstPlayerPlayingFieldTableLayoutPanel.Name = "_firstPlayerPlayingFieldTableLayoutPanel";
            _firstPlayerPlayingFieldTableLayoutPanel.RowCount = 2;
            _firstPlayerPlayingFieldTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            _firstPlayerPlayingFieldTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            _firstPlayerPlayingFieldTableLayoutPanel.Size = new Size(300, 300);
            _firstPlayerPlayingFieldTableLayoutPanel.TabIndex = 5;
            // 
            // _secondPlayerPlayingFieldTableLayoutPanel
            // 
            _secondPlayerPlayingFieldTableLayoutPanel.ColumnCount = 2;
            _secondPlayerPlayingFieldTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _secondPlayerPlayingFieldTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _secondPlayerPlayingFieldTableLayoutPanel.Enabled = false;
            _secondPlayerPlayingFieldTableLayoutPanel.Location = new Point(475, 95);
            _secondPlayerPlayingFieldTableLayoutPanel.Margin = new Padding(5);
            _secondPlayerPlayingFieldTableLayoutPanel.Name = "_secondPlayerPlayingFieldTableLayoutPanel";
            _secondPlayerPlayingFieldTableLayoutPanel.RowCount = 2;
            _secondPlayerPlayingFieldTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            _secondPlayerPlayingFieldTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            _secondPlayerPlayingFieldTableLayoutPanel.Size = new Size(300, 300);
            _secondPlayerPlayingFieldTableLayoutPanel.TabIndex = 6;
            // 
            // GameModeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 457);
            Controls.Add(_statusStrip);
            Controls.Add(_secondPlayerPlayingFieldTableLayoutPanel);
            Controls.Add(_firstPlayerPlayingFieldTableLayoutPanel);
            Controls.Add(_toResultsButton);
            Controls.Add(_secondPlayerPlaceShipsButton);
            Controls.Add(_firstPlayerPlaceShipsButton);
            Controls.Add(_currentTurnLabel);
            Controls.Add(_shotHistoryLabel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "GameModeForm";
            Padding = new Padding(5);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GameModeForm";
            _statusStrip.ResumeLayout(false);
            _statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip _statusStrip;
        private ToolStripStatusLabel currentShotNumberToolStripLabel;
        private ListBox _shotHistoryLabel;
        private Label _currentTurnLabel;
        private Button _firstPlayerPlaceShipsButton;
        private Button _secondPlayerPlaceShipsButton;
        private Button _toResultsButton;
        private TableLayoutPanel _firstPlayerPlayingFieldTableLayoutPanel;
        private TableLayoutPanel _secondPlayerPlayingFieldTableLayoutPanel;
    }
}