using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.UI;

public partial class GameModeForm : Form, IGameModeView
{
    public event Action<int>? OnFieldCellClicked;
    public event Action<int>? OnPlaceShipsClicked;
    public event Action? OnFinishGameClicked;

    public GameModeForm()
    {
        InitializeComponent();
    }

}
