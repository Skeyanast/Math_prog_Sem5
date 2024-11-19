using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.UI
{
    public partial class ChangeUsernameForm : Form, IChangeUsernameView
    {
        public event Action? SaveClicked;

        public string Username => _usernameTextBox.Text;

        public ChangeUsernameForm()
        {
            InitializeComponent();

            _saveButton.Click += SaveButtonClick;
        }

        public new void Show()
        {
            ShowDialog();
        }

        private void SaveButtonClick(object? sender, EventArgs e)
        {
            SaveClicked?.Invoke();
        }
    }
}
