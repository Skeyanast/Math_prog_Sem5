using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.UI;

public partial class ResultsForm : Form, IResultsView
{
    public event Action? OnReturnToMainMenuClicked;

    public ResultsForm()
    {
        InitializeComponent();
    }

}
