using WinFormsApp1.DomainModel;
using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.UI;

public partial class GameModeForm : Form, IGameModeView
{
    public event Action<int, int>? OnPlayingFieldGridCellClicked;
    public event Action? OnPlaceShipsClicked;
    public event Action? OnFinishGameClicked;

    public int PlayingFieldGridSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public List<string> ShootsHistory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public List<string> PlayingFieldHorizontalNaming { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public List<string> PlayingFieldVerticalNaming { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public IReadOnlyList<IReadOnlyList<CellStatus>> PlayingFieldGridCellStatuses { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public GameModeForm()
    {
        InitializeComponent();
    }

    public void PlayingFieldGridInvalidate()
    {
        throw new NotImplementedException();
    }
}
