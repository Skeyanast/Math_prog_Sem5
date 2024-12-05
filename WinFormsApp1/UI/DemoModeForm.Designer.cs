namespace WinFormsApp1.UI
{
    partial class DemoModeForm
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
            _currentShotNumberToolStripStatusLabel = new ToolStripStatusLabel();
            _shotHistoryLabel = new Label();
            _shotHistoryListBox = new ListBox();
            _placeShipsButton = new Button();
            _toResultsButton = new Button();
            _playingFieldTableLayoutPanel = new TableLayoutPanel();
            _statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // _statusStrip
            // 
            _statusStrip.Items.AddRange(new ToolStripItem[] { _currentShotNumberToolStripStatusLabel });
            _statusStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            _statusStrip.Location = new Point(5, 430);
            _statusStrip.Name = "_statusStrip";
            _statusStrip.Size = new Size(770, 22);
            _statusStrip.TabIndex = 0;
            // 
            // _currentShotNumberToolStripStatusLabel
            // 
            _currentShotNumberToolStripStatusLabel.Name = "_currentShotNumberToolStripStatusLabel";
            _currentShotNumberToolStripStatusLabel.Size = new Size(0, 17);
            // 
            // _shotHistoryLabel
            // 
            _shotHistoryLabel.AutoSize = true;
            _shotHistoryLabel.Location = new Point(8, 33);
            _shotHistoryLabel.Name = "_shotHistoryLabel";
            _shotHistoryLabel.Size = new Size(72, 17);
            _shotHistoryLabel.TabIndex = 1;
            _shotHistoryLabel.Text = "History:";
            // 
            // _shotHistoryListBox
            // 
            _shotHistoryListBox.FormattingEnabled = true;
            _shotHistoryListBox.ItemHeight = 17;
            _shotHistoryListBox.Location = new Point(8, 53);
            _shotHistoryListBox.Name = "_shotHistoryListBox";
            _shotHistoryListBox.SelectionMode = SelectionMode.None;
            _shotHistoryListBox.Size = new Size(160, 344);
            _shotHistoryListBox.TabIndex = 2;
            // 
            // _placeShipsButton
            // 
            _placeShipsButton.Location = new Point(174, 53);
            _placeShipsButton.Name = "_placeShipsButton";
            _placeShipsButton.Size = new Size(200, 30);
            _placeShipsButton.TabIndex = 3;
            _placeShipsButton.Text = "Place ships";
            _placeShipsButton.UseVisualStyleBackColor = true;
            // 
            // _toResultsButton
            // 
            _toResultsButton.Location = new Point(174, 367);
            _toResultsButton.Name = "_toResultsButton";
            _toResultsButton.Size = new Size(200, 30);
            _toResultsButton.TabIndex = 4;
            _toResultsButton.Text = "To results";
            _toResultsButton.UseVisualStyleBackColor = true;
            _toResultsButton.Visible = false;
            // 
            // _playingFieldTableLayoutPanel
            // 
            _playingFieldTableLayoutPanel.ColumnCount = 2;
            _playingFieldTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _playingFieldTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _playingFieldTableLayoutPanel.Enabled = false;
            _playingFieldTableLayoutPanel.Location = new Point(390, 33);
            _playingFieldTableLayoutPanel.Margin = new Padding(5);
            _playingFieldTableLayoutPanel.Name = "_playingFieldTableLayoutPanel";
            _playingFieldTableLayoutPanel.RowCount = 2;
            _playingFieldTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            _playingFieldTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            _playingFieldTableLayoutPanel.Size = new Size(380, 380);
            _playingFieldTableLayoutPanel.TabIndex = 5;
            // 
            // DemoModeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 457);
            Controls.Add(_playingFieldTableLayoutPanel);
            Controls.Add(_toResultsButton);
            Controls.Add(_placeShipsButton);
            Controls.Add(_shotHistoryListBox);
            Controls.Add(_shotHistoryLabel);
            Controls.Add(_statusStrip);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "DemoModeForm";
            Padding = new Padding(5);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sea Battle Demo";
            _statusStrip.ResumeLayout(false);
            _statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip _statusStrip;
        private ToolStripStatusLabel _currentShotNumberToolStripStatusLabel;
        private Label _shotHistoryLabel;
        private ListBox _shotHistoryListBox;
        private Button _placeShipsButton;
        private Button _toResultsButton;
        private TableLayoutPanel _playingFieldTableLayoutPanel;
    }
}