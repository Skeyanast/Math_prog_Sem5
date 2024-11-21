using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.UI;

public partial class DemoModeForm : Form, IDemoModeView
{
    public event Action? OnFieldCellClicked;
    public event Action? OnPlaceShipsClicked;
    public event Action? OnFinishGameClicked;

    public DemoModeForm()
    {
        InitializeComponent();
    }

}
