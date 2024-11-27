using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.UI;

public partial class ResultsForm : Form, IResultsView
{
    private readonly ApplicationContext _context;

    private readonly Label _playerWinLabel = new();
    private readonly Label _shotCountLabel = new();
    private readonly Button _backToMenuButton = new();

    public event Action? OnReturnToMainMenuClicked;

    public int WinPlayerNumber { get; set; }
    public int ShotCount { get; set; }

    public ResultsForm(ApplicationContext context)
    {
        _context = context;
        InitializeComponent();

        InitializeControls();
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

    private void InitializeControls()
    {
        // 
        // _playerWinLabel
        // 
        _playerWinLabel.AutoSize = true;
        _playerWinLabel.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
        _playerWinLabel.Location = new Point((int)(Width * 0.25), (int)(Height * 0.2));
        _playerWinLabel.Name = "_playerWinLabel";
        _playerWinLabel.TabIndex = 0;
        _playerWinLabel.Text = "Player # win!";
        Controls.Add(_playerWinLabel);
        // 
        // _shootCountLabel
        // 
        _shotCountLabel.AutoSize = true;
        _shotCountLabel.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
        _shotCountLabel.Location = new Point((int)(Width * 0.25), (int)(Height * 0.4));
        _shotCountLabel.Name = "_shootCountLabel";
        _shotCountLabel.TabIndex = 1;
        _shotCountLabel.Text = "Shoot count:";
        Controls.Add(_shotCountLabel);
        // 
        // _backToMenuButton
        // 
        _backToMenuButton.Size = new Size(200, 30);
        _backToMenuButton.Location = new Point((Width - _backToMenuButton.Width) / 2, (int)(Height * 0.6));
        _backToMenuButton.Name = "_backToMenuButton";
        _backToMenuButton.TabIndex = 2;
        _backToMenuButton.Text = "Back to menu";
        _backToMenuButton.UseVisualStyleBackColor = true;
        _backToMenuButton.Enabled = false;
        _backToMenuButton.Click += OnBackToMenuButtonClick;
        Controls.Add(_backToMenuButton);
    }

    private void OnBackToMenuButtonClick(object? sender, EventArgs e)
    {
        OnReturnToMainMenuClicked?.Invoke();
    }
}
