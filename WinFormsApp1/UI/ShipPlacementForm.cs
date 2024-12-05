using System.Collections.ObjectModel;
using System.Windows.Forms;
using WinFormsApp1.DomainModel;
using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.UI;

public partial class ShipPlacementForm : Form, IShipPlacementView
{

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

        _completePlacementButton.Click += CompletePlacementButton_Click;

        PlacedShips.CollectionChanged += PlacedShipsCollectionChanged;
    }

    public new void Show()
    {
        _horizontalOrientationRadioButton.Select();
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
        _shipPlacementPointsToolStripStatusLabel.Text = $"Ship creation points: {remainingPoints} / {maxPoints}";
    }

    public void FinishPlacement()
    {
        _playingFieldTableLayoutPanel.Enabled = false;
        _completePlacementButton.Enabled = true;
    }

    private void InitializePlayingFieldWithData()
    {
        _playingFieldTableLayoutPanel.ColumnStyles.Clear();
        _playingFieldTableLayoutPanel.RowStyles.Clear();

        _playingFieldTableLayoutPanel.ColumnCount = PlayingFieldGridSize + 1;
        _playingFieldTableLayoutPanel.RowCount = PlayingFieldGridSize + 1;

        for (int i = 0; i < PlayingFieldGridSize + 1; i++)
        {
            _playingFieldTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, _playingFieldTableLayoutPanel.Size.Width / _playingFieldTableLayoutPanel.ColumnCount));
        }
        for (int i = 0; i < PlayingFieldGridSize + 1; i++)
        {
            _playingFieldTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, _playingFieldTableLayoutPanel.Size.Height / _playingFieldTableLayoutPanel.RowCount));
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

    private void CompletePlacementButton_Click(object? sender, EventArgs e)
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
