namespace WinFormsApp1.UI
{
    partial class ShipPlacementForm
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
            _shipPlacementPointsToolStripStatusLabel = new ToolStripStatusLabel();
            _placedShipsLabel = new Label();
            _shipSizeLabel = new Label();
            _placedShipsListBox = new ListBox();
            _shipOrientationGroupBox = new GroupBox();
            _horizontalOrientationRadioButton = new RadioButton();
            _verticalOrientationRadioButton = new RadioButton();
            _shipSizeNumericUpDown = new NumericUpDown();
            _playingFieldTableLayoutPanel = new TableLayoutPanel();
            _completePlacementButton = new Button();
            _statusStrip.SuspendLayout();
            _shipOrientationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_shipSizeNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // _statusStrip
            // 
            _statusStrip.Items.AddRange(new ToolStripItem[] { _shipPlacementPointsToolStripStatusLabel });
            _statusStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            _statusStrip.Location = new Point(0, 435);
            _statusStrip.Name = "_statusStrip";
            _statusStrip.Size = new Size(780, 22);
            _statusStrip.TabIndex = 0;
            _statusStrip.Text = "_statusStrip";
            // 
            // _shipPlacementPointsToolStripStatusLabel
            // 
            _shipPlacementPointsToolStripStatusLabel.Name = "_shipPlacementPointsToolStripStatusLabel";
            _shipPlacementPointsToolStripStatusLabel.Size = new Size(119, 17);
            _shipPlacementPointsToolStripStatusLabel.Text = "ShipPlacementPoints";
            // 
            // _placedShipsLabel
            // 
            _placedShipsLabel.AutoSize = true;
            _placedShipsLabel.Location = new Point(12, 31);
            _placedShipsLabel.Name = "_placedShipsLabel";
            _placedShipsLabel.Size = new Size(112, 17);
            _placedShipsLabel.TabIndex = 1;
            _placedShipsLabel.Text = "Placed ships:";
            // 
            // _shipSizeLabel
            // 
            _shipSizeLabel.AutoSize = true;
            _shipSizeLabel.Location = new Point(214, 179);
            _shipSizeLabel.Name = "_shipSizeLabel";
            _shipSizeLabel.Size = new Size(48, 17);
            _shipSizeLabel.TabIndex = 2;
            _shipSizeLabel.Text = "Size:";
            // 
            // _placedShipsListBox
            // 
            _placedShipsListBox.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            _placedShipsListBox.FormattingEnabled = true;
            _placedShipsListBox.Location = new Point(12, 51);
            _placedShipsListBox.Name = "_placedShipsListBox";
            _placedShipsListBox.Size = new Size(185, 244);
            _placedShipsListBox.TabIndex = 3;
            // 
            // _shipOrientationGroupBox
            // 
            _shipOrientationGroupBox.Controls.Add(_horizontalOrientationRadioButton);
            _shipOrientationGroupBox.Controls.Add(_verticalOrientationRadioButton);
            _shipOrientationGroupBox.Location = new Point(214, 51);
            _shipOrientationGroupBox.Name = "_shipOrientationGroupBox";
            _shipOrientationGroupBox.Size = new Size(160, 79);
            _shipOrientationGroupBox.TabIndex = 4;
            _shipOrientationGroupBox.TabStop = false;
            _shipOrientationGroupBox.Text = "Orientation:";
            // 
            // _horizontalOrientationRadioButton
            // 
            _horizontalOrientationRadioButton.AutoSize = true;
            _horizontalOrientationRadioButton.Location = new Point(6, 22);
            _horizontalOrientationRadioButton.Name = "_horizontalOrientationRadioButton";
            _horizontalOrientationRadioButton.Size = new Size(106, 21);
            _horizontalOrientationRadioButton.TabIndex = 1;
            _horizontalOrientationRadioButton.TabStop = true;
            _horizontalOrientationRadioButton.Text = "Horizontal";
            _horizontalOrientationRadioButton.UseVisualStyleBackColor = true;
            // 
            // _verticalOrientationRadioButton
            // 
            _verticalOrientationRadioButton.AutoSize = true;
            _verticalOrientationRadioButton.Location = new Point(6, 52);
            _verticalOrientationRadioButton.Name = "_verticalOrientationRadioButton";
            _verticalOrientationRadioButton.Size = new Size(90, 21);
            _verticalOrientationRadioButton.TabIndex = 0;
            _verticalOrientationRadioButton.TabStop = true;
            _verticalOrientationRadioButton.Text = "Vertical";
            _verticalOrientationRadioButton.UseVisualStyleBackColor = true;
            // 
            // _shipSizeNumericUpDown
            // 
            _shipSizeNumericUpDown.Location = new Point(268, 177);
            _shipSizeNumericUpDown.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            _shipSizeNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            _shipSizeNumericUpDown.Name = "_shipSizeNumericUpDown";
            _shipSizeNumericUpDown.ReadOnly = true;
            _shipSizeNumericUpDown.Size = new Size(60, 23);
            _shipSizeNumericUpDown.TabIndex = 5;
            _shipSizeNumericUpDown.TextAlign = HorizontalAlignment.Center;
            _shipSizeNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // _playingFieldTableLayoutPanel
            // 
            _playingFieldTableLayoutPanel.ColumnCount = 2;
            _playingFieldTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _playingFieldTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _playingFieldTableLayoutPanel.Location = new Point(386, 31);
            _playingFieldTableLayoutPanel.Margin = new Padding(5);
            _playingFieldTableLayoutPanel.Name = "_playingFieldTableLayoutPanel";
            _playingFieldTableLayoutPanel.RowCount = 2;
            _playingFieldTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            _playingFieldTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            _playingFieldTableLayoutPanel.Size = new Size(380, 380);
            _playingFieldTableLayoutPanel.TabIndex = 6;
            // 
            // _completePlacementButton
            // 
            _completePlacementButton.Enabled = false;
            _completePlacementButton.Location = new Point(203, 381);
            _completePlacementButton.Name = "_completePlacementButton";
            _completePlacementButton.Size = new Size(171, 30);
            _completePlacementButton.TabIndex = 7;
            _completePlacementButton.Text = "Complete";
            _completePlacementButton.UseVisualStyleBackColor = true;
            _completePlacementButton.Click += CompletePlacementButton_Click;
            // 
            // ShipPlacementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 457);
            ControlBox = false;
            Controls.Add(_completePlacementButton);
            Controls.Add(_playingFieldTableLayoutPanel);
            Controls.Add(_shipSizeNumericUpDown);
            Controls.Add(_shipOrientationGroupBox);
            Controls.Add(_placedShipsListBox);
            Controls.Add(_shipSizeLabel);
            Controls.Add(_placedShipsLabel);
            Controls.Add(_statusStrip);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "ShipPlacementForm";
            Text = "Ship Placement";
            _statusStrip.ResumeLayout(false);
            _statusStrip.PerformLayout();
            _shipOrientationGroupBox.ResumeLayout(false);
            _shipOrientationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_shipSizeNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip _statusStrip;
        private ToolStripStatusLabel _shipPlacementPointsToolStripStatusLabel;
        private Label _placedShipsLabel;
        private Label _shipSizeLabel;
        private ListBox _placedShipsListBox;
        private GroupBox _shipOrientationGroupBox;
        private RadioButton _horizontalOrientationRadioButton;
        private RadioButton _verticalOrientationRadioButton;
        private NumericUpDown _shipSizeNumericUpDown;
        private TableLayoutPanel _playingFieldTableLayoutPanel;
        private Button _completePlacementButton;
    }
}