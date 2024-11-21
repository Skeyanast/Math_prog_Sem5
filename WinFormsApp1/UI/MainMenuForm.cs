using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.UI;

public partial class MainMenuForm : Form, IMainMenuView
{
    public event Action? DemoModeClicked;
    public event Action? GameModeClicked;

    public int FieldSize => throw new NotImplementedException();

    public MainMenuForm()
    {
        InitializeComponent();
    }

}
