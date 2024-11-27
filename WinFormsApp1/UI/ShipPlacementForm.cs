using System.Collections.ObjectModel;
using System.Windows.Forms;
using WinFormsApp1.DomainModel;
using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.UI;

public partial class ShipPlacementForm : Form, IShipPlacementView
{
    private readonly StatusStrip _statusStrip = new();
    private readonly ToolStripLabel _shipPlacementPointsToolStripLabel = new();
    private readonly Label _shipSizeLabel = new();
    private readonly ListBox _placedShipsListBox = new();
    private readonly Button _completePlacementButton = new();
    private readonly RadioButton _horizontalOrientationRadioButton = new();
    private readonly RadioButton _verticalOrientationRadioButton = new();
    private readonly GroupBox _shipOrientationGroupBox = new();
    private readonly NumericUpDown _shipSizeNumericUpDown = new();
    private readonly TableLayoutPanel _playingFieldTableLayoutPanel = new();

    public event Action<int, int>? OnPlaceShipGridCellClicked;
    public event Action? OnCompletePlacementClicked;

    public required int PlayingFieldGridSize { get; set; }
    public required IReadOnlyList<string> PlayingFieldHorizontalNaming { get; set; }
    public required IReadOnlyList<string> PlayingFieldVerticalNaming { get; set; }
    public required IReadOnlyList<IReadOnlyList<CellStatus>> PlayingFieldGridCellStatuses { get; set; }
    public ObservableCollection<string> PlacedShips { get; } = new();
    public int ShipSize => Convert.ToInt32(_shipSizeNumericUpDown.Value);

    public ShipOrientation ShipOrientation
    {
        get
        {
            if (_horizontalOrientationRadioButton.Checked)
            {
                return ShipOrientation.Horizontal;
            }
            else if (_verticalOrientationRadioButton.Checked)
            {
                return ShipOrientation.Vertical;
            }
            else
            {
                return ShipOrientation.Horizontal;
            }
        }
    }

    public ShipPlacementForm()
    {
        InitializeComponent();

        InitializeControls();

        PlacedShips.CollectionChanged += PlacedShipsCollectionChanged;
    }

    public new void Show()
    {
        InitializePlayingFieldWithData();
        PlacementFieldGridInvalidate();
        ShowDialog();
    }

    public void PlacementFieldGridInvalidate()
    {
        for (int row = 1; row < _playingFieldTableLayoutPanel.RowCount; row++)
        {
            for (int column = 1; column < _playingFieldTableLayoutPanel.ColumnCount; column++)
            {
                Control? cellControl = _playingFieldTableLayoutPanel.GetControlFromPosition(column, row);
                if (cellControl != null)
                {
                    UpdateCellColor(cellControl, PlayingFieldGridCellStatuses[row - 1][column - 1]);
                    UpdateCellInteractable(cellControl, PlayingFieldGridCellStatuses[row - 1][column - 1]);
                }
            }
        }

        static void UpdateCellColor(Control cellControl, CellStatus cellStatus)
        {
            cellControl.BackColor = cellStatus switch
            {
                CellStatus.Water => Color.Navy,
                CellStatus.Ship => Color.Yellow,
                CellStatus.Hit => Color.DarkRed,
                CellStatus.Miss => Color.Silver,
                _ => cellControl.BackColor
            };
        }

        static void UpdateCellInteractable(Control cellControl, CellStatus cellStatus)
        {
            cellControl.Enabled = cellStatus switch
            {
                CellStatus.Water => true,
                CellStatus.Ship => false,
                CellStatus.Hit => false,
                CellStatus.Miss => false,
                _ => cellControl.Enabled
            };
        }
    }

    public void ProcessShipCreationResult(ShipPlacementResult shipPlacementResult)
    {
        if (shipPlacementResult != ShipPlacementResult.Success)
        {
            MessageBox.Show($"Placement error: {shipPlacementResult}");
        }
    }

    public void SetRemainingPlacementPoints(int remainingPoints, int maxPoints)
    {
        _shipPlacementPointsToolStripLabel.Text = $"Ship creation points: {remainingPoints} / {maxPoints}";
    }

    public void FinishPlacement()
    {
        _playingFieldTableLayoutPanel.Enabled = false;
        _completePlacementButton.Enabled = true;
    }

    private void InitializeControls()
    {
        ((System.ComponentModel.ISupportInitialize)_shipSizeNumericUpDown).BeginInit();
        SuspendLayout();

        //
        // _statusStrip
        //
        _statusStrip.Dock = DockStyle.Bottom;
        _statusStrip.Padding = new Padding(2);
        _statusStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
        Controls.Add(_statusStrip);
        // 
        // _shipPlacementPointsToolStripLabel
        // 
        _shipPlacementPointsToolStripLabel.Name = "_shipPlacementPointsToolStripLabel";
        _statusStrip.Items.Add(_shipPlacementPointsToolStripLabel);
        // 
        // _shipSizeLabel
        // 
        _shipSizeLabel.AutoSize = true;
        _shipSizeLabel.Location = new Point((int)(Width * 0.25), (int)(Height * 0.4));
        _shipSizeLabel.Name = "_shipSizeLabel";
        _shipSizeLabel.Text = "Size:";
        Controls.Add(_shipSizeLabel);
        // 
        // _placedShipsListBox
        // 
        _placedShipsListBox.Size = new Size((int)(Width * 0.2), (int)(Height * 0.5));
        _placedShipsListBox.Location = new Point(12, (int)(Height * 0.1));
        _placedShipsListBox.FormattingEnabled = true;
        _placedShipsListBox.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
        _placedShipsListBox.SelectionMode = SelectionMode.One;
        _placedShipsListBox.Name = "_placedShipsListBox";
        _placedShipsListBox.TabIndex = 0;
        Controls.Add(_placedShipsListBox);
        // 
        // _completePlacementButton
        // 
        _completePlacementButton.Size = new Size(200, 30);
        _completePlacementButton.Location = new Point((int)(Width * 0.2), (int)(Height * 0.8));
        _completePlacementButton.Name = "_completePlacementButton";
        _completePlacementButton.TabIndex = 1;
        _completePlacementButton.Text = "Complete";
        _completePlacementButton.UseVisualStyleBackColor = true;
        _completePlacementButton.Enabled = false;
        _completePlacementButton.Click += CompletePlacementClicked;
        Controls.Add(_completePlacementButton);
        // 
        // _horizontalOrientationRadioButton
        // 
        _horizontalOrientationRadioButton.AutoSize = true;
        _horizontalOrientationRadioButton.Location = new Point((int)(_shipOrientationGroupBox.Width * 0.05), (int)(_shipOrientationGroupBox.Height * 0.3));
        _horizontalOrientationRadioButton.Name = "_horizontalOrientationRadioButton";
        _horizontalOrientationRadioButton.TabIndex = 3;
        _horizontalOrientationRadioButton.TabStop = true;
        _horizontalOrientationRadioButton.Text = "Horizontal";
        _horizontalOrientationRadioButton.UseVisualStyleBackColor = true;
        _horizontalOrientationRadioButton.Select();
        // 
        // _verticalOrientationRadioButton
        // 
        _verticalOrientationRadioButton.AutoSize = true;
        _verticalOrientationRadioButton.Location = new Point((int)(_shipOrientationGroupBox.Width * 0.05), (int)(_shipOrientationGroupBox.Height * 0.6));
        _verticalOrientationRadioButton.Name = "_verticalOrientationRadioButton";
        _verticalOrientationRadioButton.TabIndex = 4;
        _verticalOrientationRadioButton.TabStop = true;
        _verticalOrientationRadioButton.Text = "Vertical";
        _verticalOrientationRadioButton.UseVisualStyleBackColor = true;
        // 
        // _shipOrientationGroupBox
        // 
        _shipOrientationGroupBox.Controls.Add(_horizontalOrientationRadioButton);
        _shipOrientationGroupBox.Controls.Add(_verticalOrientationRadioButton);
        _shipOrientationGroupBox.Size = new Size((int)(Width * 0.2), (int)(Height * 0.2));
        _shipOrientationGroupBox.Location = new Point((int)(Width * 0.25), (int)(Height * 0.15));
        _shipOrientationGroupBox.Name = "_shipOrientationGroupBox";
        _shipOrientationGroupBox.TabIndex = 2;
        _shipOrientationGroupBox.TabStop = false;
        _shipOrientationGroupBox.Text = "Orientation:";
        Controls.Add(_shipOrientationGroupBox);
        // 
        // _shipSizeNumericUpDown
        // 
        _shipSizeNumericUpDown.Width = 60;
        _shipSizeNumericUpDown.Location = new Point((int)(Width * 0.35), (int)(Height * 0.4));
        _shipSizeNumericUpDown.Minimum = 1;
        _shipSizeNumericUpDown.Maximum = 4;
        _shipSizeNumericUpDown.Name = "_shipSizeNumericUpDown";
        _shipSizeNumericUpDown.TabIndex = 5;
        _shipSizeNumericUpDown.TextAlign = HorizontalAlignment.Center;
        _shipSizeNumericUpDown.ReadOnly = true;
        _shipSizeNumericUpDown.Value = 1;
        Controls.Add(_shipSizeNumericUpDown);
        // 
        // _playingFieldTableLayoutPanel
        // 
        _playingFieldTableLayoutPanel.Height = (int)(Height * 0.8);
        _playingFieldTableLayoutPanel.Width = _playingFieldTableLayoutPanel.Height;
        _playingFieldTableLayoutPanel.Location = new Point((int)(Width - (_playingFieldTableLayoutPanel.Width * 1.1)), (int)(Height - (_playingFieldTableLayoutPanel.Height * 1.2)));
        _playingFieldTableLayoutPanel.Name = "_playingFieldTableLayoutPanel";
        _playingFieldTableLayoutPanel.TabIndex = 6;
        _playingFieldTableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
        _playingFieldTableLayoutPanel.Padding = new Padding(0);
        _playingFieldTableLayoutPanel.Margin = new Padding(5);
        // Continues in the InitializePlacementFieldWithData method

        ((System.ComponentModel.ISupportInitialize)_shipSizeNumericUpDown).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private void InitializePlayingFieldWithData()
    {
        _playingFieldTableLayoutPanel.RowCount = PlayingFieldGridSize + 1;
        _playingFieldTableLayoutPanel.ColumnCount = PlayingFieldGridSize + 1;

        for (int i = 0; i < PlayingFieldGridSize + 1; i++)
        {
            _playingFieldTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, _playingFieldTableLayoutPanel.Width / _playingFieldTableLayoutPanel.ColumnCount));
        }
        for (int i = 0; i < PlayingFieldGridSize + 1; i++)
        {
            _playingFieldTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, _playingFieldTableLayoutPanel.Height / _playingFieldTableLayoutPanel.RowCount));
        }

        InitializePlayingFieldHorizontalNamingLabel();
        InitializePlayingFieldVerticalNamingLabel();

        InitializePlayingGrid();

        Controls.Add(_playingFieldTableLayoutPanel);
    }

    private void InitializePlayingFieldHorizontalNamingLabel()
    {
        for (int i = 1; i < _playingFieldTableLayoutPanel.ColumnCount; i++)
        {
            Label label = new();
            label.Text = PlayingFieldHorizontalNaming[i - 1];
            label.Dock = DockStyle.Fill;
            label.AutoSize = false;
            label.MinimumSize = new Size(10, 10);
            label.TextAlign = ContentAlignment.MiddleCenter;
            _playingFieldTableLayoutPanel.Controls.Add(label, i, 0);
        }
    }

    private void InitializePlayingFieldVerticalNamingLabel()
    {
        for (int i = 1; i < _playingFieldTableLayoutPanel.RowCount; i++)
        {
            Label label = new();
            label.Text = PlayingFieldVerticalNaming[i - 1];
            label.Dock = DockStyle.Fill;
            label.AutoSize = false;
            label.MinimumSize = new Size(10, 10);
            label.TextAlign = ContentAlignment.MiddleCenter;
            _playingFieldTableLayoutPanel.Controls.Add(label, 0, i);
        }
    }

    private void InitializePlayingGrid()
    {
        for (int row = 1; row < _playingFieldTableLayoutPanel.RowCount; row++)
        {
            for (int column = 1; column < _playingFieldTableLayoutPanel.ColumnCount; column++)
            {
                InitializePlayingGridCellButton(row, column);
            }
        }

        void InitializePlayingGridCellButton(int row, int column)
        {
            Button cellButton = new();
            cellButton.Dock = DockStyle.Fill;
            cellButton.Margin = new Padding(0);
            cellButton.TabStop = false;
            cellButton.Click += (sender, e) => OnPlaceShipGridCellClicked?.Invoke(row - 1, column - 1);
            _playingFieldTableLayoutPanel.Controls.Add(cellButton, column, row);
        }
    }

    private void CompletePlacementClicked(object? sender,  EventArgs e)
    {
        OnCompletePlacementClicked?.Invoke();
    }

    private void PlacedShipsCollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
        {
            foreach (object? newItem in e.NewItems!)
            {
                _placedShipsListBox.Items.Add(newItem);
            }
            _placedShipsListBox.TopIndex = _placedShipsListBox.Items.Count - 1;
        }
    }
}
