using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.UI;

public partial class MainMenuForm : Form, IMainMenuView
{
    private readonly ApplicationContext _context;

    public event Action? OnDemoModeClicked;
    public event Action? OnGameModeClicked;

    public int PlayingFieldSize => Convert.ToInt32(_playingFieldSizeNumericUpDown.Value);

    public MainMenuForm(ApplicationContext context)
    {
        _context = context;
        InitializeComponent();

        _startDemoModeButton.Click += StartDemoModeButton_Click;
        _startGameModeButton.Click += StartGameModeButton_Click;
    }

    public new void Show()
    {
        _context.MainForm = this;
        Application.Run(_context);
    }

    public void OnInvalidFieldSizeValue(string errorMessage)
    {
        MessageBox.Show(errorMessage);
    }

    private void StartDemoModeButton_Click(object? sender,  EventArgs e)
    {
        OnDemoModeClicked?.Invoke();
    }

    private void StartGameModeButton_Click(Object? sender, EventArgs e)
    {
        OnGameModeClicked?.Invoke();
    }
}
