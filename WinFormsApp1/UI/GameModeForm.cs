using System.Collections.Generic;
using System.Collections.ObjectModel;
using WinFormsApp1.DomainModel;
using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.UI;

public partial class GameModeForm : Form, IGameModeView
{
    private readonly ApplicationContext _context;

    public event Action<int, int, int>? OnPlayingFieldCellClicked;
    public event Action<int>? OnPlaceShipsClicked;
    public event Action? OnToResultsClicked;

    public required int PlayingFieldGridSize { get; set; }
    public required IReadOnlyList<string> PlayingFieldHorizontalNaming { get; set; }
    public required IReadOnlyList<string> PlayingFieldVerticalNaming { get; set; }
    public required IReadOnlyList<IReadOnlyList<CellStatus>> Player1FieldGridCellStatuses { get; set; }
    public required IReadOnlyList<IReadOnlyList<CellStatus>> Player2FieldGridCellStatuses { get; set; }
    public ObservableCollection<string> ShotsHistory { get; } = new();

    public GameModeForm(ApplicationContext context)
    {
        _context = context;
        InitializeComponent();

        _placeShipsButton.Click += Player1PlaceShipsButton_Click;
        _toResultsButton.Click += ToResultsButton_Click;

        ShotsHistory.CollectionChanged += ShotsHistoryCollectionChanged;
    }

    public new void Show()
    {
        _context.MainForm = this;
        InitializePlayerFieldsWithData();
        base.Show();
    }

    public void SetActivePlayer(int playerNumber)
    {
        switch (playerNumber)
        {
            case 1:
                _player1PlayingFieldTableLayoutPanel.Enabled = false;
                _player2PlayingFieldTableLayoutPanel.Enabled = true;
                break;
            case 2:
                _player1PlayingFieldTableLayoutPanel.Enabled = true;
                _player2PlayingFieldTableLayoutPanel.Enabled = false;
                break;
            default:
                throw new ArgumentException("Invalid player number");
        }
        _currentTurnLabel.Text = $"{playerNumber} player's turn";
    }

    public void SetShotsFired(int number)
    {
        _currentShotNumberToolStripLabel.Text = $"Shots fired: {number}";
    }

    public void PlayingFieldGridInvalidate(int fieldNumber)
    {
        TableLayoutPanel invalidatingField;
        IReadOnlyList<IReadOnlyList<CellStatus>> cellStatuses;
        switch (fieldNumber)
        {
            case 1:
                invalidatingField = _player1PlayingFieldTableLayoutPanel;
                cellStatuses = Player1FieldGridCellStatuses;
                break;
            case 2:
                invalidatingField = _player2PlayingFieldTableLayoutPanel;
                cellStatuses = Player2FieldGridCellStatuses;
                break;
            default:
                throw new ArgumentException("Invalid field number");
        }
        for (int row = 1; row < invalidatingField.RowCount; row++)
        {
            for (int column = 1; column < invalidatingField.ColumnCount; column++)
            {
                Control? cellControl = invalidatingField.GetControlFromPosition(column, row);
                if (cellControl != null)
                {
                    UpdateCellColor(cellControl, cellStatuses[row - 1][column - 1]);
                    UpdateCellInteractable(cellControl, cellStatuses[row - 1][column - 1]);
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
        _player1PlayingFieldTableLayoutPanel.Enabled = false;
        _player2PlayingFieldTableLayoutPanel.Enabled = false;
        _toResultsButton.Visible = true;
    }

    private void InitializePlayerFieldsWithData()
    {
        List<TableLayoutPanel> playingFields = new() { _player1PlayingFieldTableLayoutPanel, _player2PlayingFieldTableLayoutPanel };
        foreach(TableLayoutPanel field in playingFields)
        {
            field.ColumnStyles.Clear();
            field.RowStyles.Clear();

            field.ColumnCount = PlayingFieldGridSize + 1;
            field.RowCount = PlayingFieldGridSize + 1;

            for (int i = 0; i < PlayingFieldGridSize + 1; i++)
            {
                field.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, field.Size.Width / field.ColumnCount));
            }
            for (int i = 0; i < PlayingFieldGridSize + 1; i++)
            {
                field.RowStyles.Add(new RowStyle(SizeType.Percent, field.Size.Height / field.RowCount));
            }

            InitializePlayingFieldHorizontalNamingLabel(field);
            InitializePlayingFieldVerticalNamingLabel(field);

            InitializePlayingGrid(field, playingFields.IndexOf(field) + 1);

            Controls.Add(field);
        }
    }

    private void InitializePlayingFieldHorizontalNamingLabel(TableLayoutPanel playingField)
    {
        for (int i = 1; i < playingField.ColumnCount; i++)
        {
            Label label = new();
            label.Text = PlayingFieldHorizontalNaming[i - 1];
            label.Dock = DockStyle.Fill;
            label.AutoSize = false;
            label.MinimumSize = new Size(10, 10);
            label.TextAlign = ContentAlignment.MiddleCenter;
            playingField.Controls.Add(label, i, 0);
        }
    }

    private void InitializePlayingFieldVerticalNamingLabel(TableLayoutPanel playingField)
    {
        for (int i = 1; i < playingField.RowCount; i++)
        {
            Label label = new();
            label.Text = PlayingFieldVerticalNaming[i - 1];
            label.Dock = DockStyle.Fill;
            label.AutoSize = false;
            label.MinimumSize = new Size(10, 10);
            label.TextAlign = ContentAlignment.MiddleCenter;
            playingField.Controls.Add(label, 0, i);
        }
    }

    private void InitializePlayingGrid(TableLayoutPanel playingField, int fieldNumber)
    {
        for (int row = 1; row < playingField.RowCount; row++)
        {
            for (int column = 1; column < playingField.ColumnCount; column++)
            {
                InitializePlayingGridCellButton(row, column, fieldNumber);
            }
        }

        void InitializePlayingGridCellButton(int row, int column, int fieldNumber)
        {
            Button cellButton = new();
            cellButton.Dock = DockStyle.Fill;
            cellButton.Margin = new Padding(0);
            cellButton.TabStop = false;
            cellButton.Click += (sender, e) => OnPlayingFieldCellClicked?.Invoke(row - 1, column - 1, fieldNumber);
            playingField.Controls.Add(cellButton, column, row);
        }
    }

    private void Player1PlaceShipsButton_Click(object? sender, EventArgs e)
    {
        _placeShipsButton.Visible = false;
        OnPlaceShipsClicked?.Invoke(1);
        OnPlaceShipsClicked?.Invoke(2);
        SetActivePlayer(1);
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
