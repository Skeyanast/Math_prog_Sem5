using System.Collections.ObjectModel;
using WinFormsApp1.DomainModel;
using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.UI;

public partial class DemoModeForm : Form, IDemoModeView
{
    private readonly ApplicationContext _context;

    public event Action<int, int>? OnPlayingFieldGridCellClicked;
    public event Action? OnPlaceShipsClicked;
    public event Action? OnToResultsClicked;

    public required int PlayingFieldGridSize { get; set; }
    public required IReadOnlyList<string> PlayingFieldHorizontalNaming { get; set; }
    public required IReadOnlyList<string> PlayingFieldVerticalNaming { get; set; }
    public required IReadOnlyList<IReadOnlyList<CellStatus>> PlayingFieldGridCellStatuses { get; set; }
    public ObservableCollection<string> ShotsHistory { get; } = new();
    
    public DemoModeForm(ApplicationContext context)
    {
        _context = context;
        InitializeComponent();

        _placeShipsButton.Click += PlaceShipsButton_Click;
        _toResultsButton.Click += ToResultsButton_Click;

        ShotsHistory.CollectionChanged += ShotsHistoryCollectionChanged;
    }

    public new void Show()
    {
        _context.MainForm = this;
        InitializePlayingFieldWithData();
        base.Show();
    }

    public void SetShotsFired(int number)
    {
        _currentShotNumberToolStripStatusLabel.Text = $"Shots fired: {number}";
    }

    public void PlayingFieldGridInvalidate()
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
                CellStatus.Ship => Color.Navy,
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
                CellStatus.Ship => true,
                CellStatus.Hit => false,
                CellStatus.Miss => false,
                _ => cellControl.Enabled
            };
        }
    }

    public void FinishGame()
    {
        _playingFieldTableLayoutPanel.Enabled = false;
        _toResultsButton.Visible = true;
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
            label.MinimumSize= new Size(10, 10);
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
            cellButton.Click += (sender, e) => OnPlayingFieldGridCellClicked?.Invoke(row - 1, column - 1);
            _playingFieldTableLayoutPanel.Controls.Add(cellButton, column, row);
        }
    }

    private void PlaceShipsButton_Click(object? sender, EventArgs e)
    {
        OnPlaceShipsClicked?.Invoke();
        _placeShipsButton.Visible = false;
        _playingFieldTableLayoutPanel.Enabled = true;
    }

    private void ToResultsButton_Click(object? sender, EventArgs e)
    {
        OnToResultsClicked?.Invoke();
    }

    private void ShotsHistoryCollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
        {
            foreach (object? newItem in e.NewItems!)
            {
                _shotHistoryListBox.Items.Add(newItem);
            }
            _shotHistoryListBox.TopIndex = _shotHistoryListBox.Items.Count - 1;
        }
    }
}
