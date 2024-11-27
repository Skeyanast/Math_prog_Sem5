using System.Collections.ObjectModel;
using WinFormsApp1.DomainModel;
using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.UI;

public partial class DemoModeForm : Form, IDemoModeView
{
    private readonly ApplicationContext _context;

    private readonly StatusStrip _statusStrip = new();
    private readonly ToolStripLabel _currentShotNumberToolStripLabel = new();
    private readonly Label _shotHistoryLabel = new();
    private readonly Button _placeShipsButton = new();
    private readonly Button _toResultsButton = new();
    private readonly ListBox _shotHistoryListBox = new();
    private readonly TableLayoutPanel _playingFieldTableLayoutPanel = new();

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

        InitializeControls();

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
        _currentShotNumberToolStripLabel.Text = $"Shots fired: {number}";
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

    private void InitializeControls()
    {
        //
        // _statusStrip
        //
        _statusStrip.Dock = DockStyle.Bottom;
        _statusStrip.Padding = new Padding(2);
        _statusStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
        //
        // _currentShopNumberToolStripLabel
        //
        _currentShotNumberToolStripLabel.Name = "_currentShopNumberToolStripLabel";
        _statusStrip.Items.Add(_currentShotNumberToolStripLabel);
        Controls.Add(_statusStrip);
        //
        // _shotHistoryLabel
        //
        _shotHistoryLabel.AutoSize = true;
        _shotHistoryLabel.Location = new Point(8, (int)(Height * 0.05));
        _shotHistoryLabel.Name = "_shotHistoryLabel";
        _shotHistoryLabel.Text = "History:";
        Controls.Add(_shotHistoryLabel);

        // 
        // _placeShipsButton
        // 
        _placeShipsButton.Size = new Size(200, 30);
        _placeShipsButton.Location = new Point((int)(Width * 0.1), (int)(Height * 0.65));
        _placeShipsButton.Name = "_placeShipsButton";
        _placeShipsButton.TabIndex = 0;
        _placeShipsButton.Text = "Place ships";
        _placeShipsButton.UseVisualStyleBackColor = true;
        _placeShipsButton.Click += PlaceShipsButtonClicked;
        Controls.Add(_placeShipsButton);
        // 
        // _toResultsButton
        // 
        _toResultsButton.Size = new Size(200, 30);
        _toResultsButton.Location = new Point((int)(Width * 0.1), (int)(Height * 0.75));
        _toResultsButton.Name = "_toResultsButton";
        _toResultsButton.TabIndex = 1;
        _toResultsButton.Text = "To results";
        _toResultsButton.UseVisualStyleBackColor = true;
        _toResultsButton.Visible = false;
        _toResultsButton.Click += ToResultsButtonClicked;
        Controls.Add(_toResultsButton);
        // 
        // _shotHistoryListBox
        // 
        _shotHistoryListBox.Size = new Size((int)(Width * 0.2), (int)(Height * 0.5));
        _shotHistoryListBox.Location = new Point(12, (int)(Height * 0.1));
        _shotHistoryListBox.FormattingEnabled = true;
        _shotHistoryListBox.SelectionMode = SelectionMode.None;
        _shotHistoryListBox.Name = "_shotHistoryListBox";
        _shotHistoryListBox.TabIndex = 2;
        Controls.Add(_shotHistoryListBox);
        // 
        // _playingFieldTableLayoutPanel
        // 
        _playingFieldTableLayoutPanel.Height = (int)(Height * 0.8);
        _playingFieldTableLayoutPanel.Width = _playingFieldTableLayoutPanel.Height;
        _playingFieldTableLayoutPanel.Location = new Point((int)(Width - (_playingFieldTableLayoutPanel.Width * 1.1)), (int)(Height - (_playingFieldTableLayoutPanel.Height + _playingFieldTableLayoutPanel.Height * 0.2)));
        _playingFieldTableLayoutPanel.Name = "_playingFieldTableLayoutPanel";
        _playingFieldTableLayoutPanel.TabIndex = 3;
        _playingFieldTableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
        _playingFieldTableLayoutPanel.Padding = new Padding(0);
        _playingFieldTableLayoutPanel.Margin = new Padding(5);
        _playingFieldTableLayoutPanel.Enabled = false;
        // Continues in the InitializePlayingFieldWithData method
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

    private void PlaceShipsButtonClicked(object? sender, EventArgs e)
    {
        OnPlaceShipsClicked?.Invoke();
        _placeShipsButton.Visible = false;
        _playingFieldTableLayoutPanel.Enabled = true;
    }

    private void ToResultsButtonClicked(object? sender, EventArgs e)
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
