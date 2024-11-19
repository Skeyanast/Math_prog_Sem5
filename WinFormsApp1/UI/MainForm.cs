using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1;

public partial class MainForm : Form, IMainView
{
    private readonly ApplicationContext _context;

    public event Action? ChangeUsernameClickedButton;

    public MainForm(ApplicationContext context)
    {
        _context = context;
        InitializeComponent();

        _changeUsernameButton.Click += ChangeUsernameButtonClick;
    }

    public new void Show()
    {
        _context.MainForm = this;
        base.Show();
    }

    public void SetUserInfo(string username, string password)
    {
        _usernameLabel.Text = username;
        _passwordLabel.Text = password;
    }

    private void ChangeUsernameButtonClick(object? sender, EventArgs e)
    {
        ChangeUsernameClickedButton?.Invoke();
    }
}
