using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.UI;

public partial class ResultsForm : Form, IResultsView
{
    private readonly ApplicationContext _context;

    public event Action? OnReturnToMainMenuClicked;

    public int WinPlayerNumber { get; set; }
    public int ShotCount { get; set; }

    public ResultsForm(ApplicationContext context)
    {
        _context = context;
        InitializeComponent();

        _backToMenuButton.Click += BackToMenuButton_Click;
    }

    public new void Show()
    {
        _context.MainForm = this;
        base.Show();
    }

    public void SetResults()
    {
        _playerWinLabel.Text = $"Player {WinPlayerNumber} win!";
        _shotCountLabel.Text = $"Shots count: {ShotCount}";
    }

    private void BackToMenuButton_Click(object? sender, EventArgs e)
    {
        OnReturnToMainMenuClicked?.Invoke();
    }
}
