using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1;

public partial class LoginForm : Form, ILoginView
{
    private readonly ApplicationContext _context;

    public event Action? LoginClicked;

    public string Username => _usernameTextBox.Text;
    public string Password => _passwordTextBox.Text;

    public LoginForm(ApplicationContext context)
    {
        _context = context;
        InitializeComponent();

        _loginButton.Click += LoginButtonClick;
    }

    public new void Show()
    {
        _context.MainForm = this;
        Application.Run(_context);
    }

    public void OnLoginError(string errorMessage)
    {
        MessageBox.Show(errorMessage);
    }

    private void LoginButtonClick(object? sender, EventArgs e)
    {
        LoginClicked?.Invoke();
    }
}