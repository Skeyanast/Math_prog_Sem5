using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.UI;

public partial class MainMenuForm : Form, IMainMenuView
{
    private readonly ApplicationContext _context;

    private readonly Label _applicationTitleLabel = new();
    private readonly Label _playingFieldSizePickLabel = new();
    private readonly NumericUpDown _playingFieldSizeNumericUpDown = new();
    private readonly Button _startDemoModeButton = new();
    private readonly Button _startGameModeButton = new();

    public event Action? DemoModeClicked;
    public event Action? GameModeClicked;

    public int PlayingFieldSize => Convert.ToInt32(_playingFieldSizeNumericUpDown.Value);

    public MainMenuForm(ApplicationContext context)
    {
        _context = context;
        InitializeComponent();

        InitializeControls();
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

    private void InitializeControls()
    {
        ((System.ComponentModel.ISupportInitialize)_playingFieldSizeNumericUpDown).BeginInit();
        SuspendLayout();
        //
        // _applicationTitleLabel
        //
        _applicationTitleLabel.Height = (int)(Height * 0.25);
        _applicationTitleLabel.Dock = DockStyle.Top;
        _applicationTitleLabel.Name = "_applicationTitleLabel";
        _applicationTitleLabel.TabIndex = 0;
        _applicationTitleLabel.Font = new Font("Cascadia Code", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
        _applicationTitleLabel.Text = "Sea Battle Game";
        _applicationTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
        Controls.Add(_applicationTitleLabel);
        //
        // _playingFieldSizePickLabel
        //
        _playingFieldSizePickLabel.Width = (int)(Width * 0.25);
        _playingFieldSizePickLabel.Location = new Point((int)(Width * 0.3), (int)(Height * 0.4));
        _playingFieldSizePickLabel.Name = "_playingFieldSizePickLabel";
        _playingFieldSizePickLabel.TabIndex = 1;
        _playingFieldSizePickLabel.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
        _playingFieldSizePickLabel.Text = "Select field size:";
        Controls.Add(_playingFieldSizePickLabel);
        //
        // _playingFieldSizeNumericUpDown
        //
        _playingFieldSizeNumericUpDown.Size = new Size(48, 26);
        _playingFieldSizeNumericUpDown.Location = new Point((int)(Width * 0.55), (int)(Height * 0.4));
        _playingFieldSizeNumericUpDown.Minimum = 4;
        _playingFieldSizeNumericUpDown.Maximum = 10;
        _playingFieldSizeNumericUpDown.Name = "_playingFieldSizeNumericUpDown";
        _playingFieldSizeNumericUpDown.TabIndex = 2;
        _playingFieldSizeNumericUpDown.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
        _playingFieldSizeNumericUpDown.TextAlign = HorizontalAlignment.Center;
        _playingFieldSizeNumericUpDown.Value = 7;
        Controls.Add(_playingFieldSizeNumericUpDown);
        //
        // _startDemoModeButton
        //
        _startDemoModeButton.Size = new Size(200, 30);
        _startDemoModeButton.Location = new Point((Width - _startDemoModeButton.Width) / 2, (int)(Height * 0.6));
        _startDemoModeButton.Name = "_startDemoModeButton";
        _startDemoModeButton.TabIndex = 3;
        _startDemoModeButton.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
        _startDemoModeButton.Text = "Demo";
        _startDemoModeButton.UseVisualStyleBackColor = true;
        _startDemoModeButton.Click += DemoModeButtonClick;
        Controls.Add(_startGameModeButton);
        //
        // _startGameModeButton
        //
        _startGameModeButton.Size = new Size(200, 30);
        _startGameModeButton.Location = new Point((Width - _startGameModeButton.Width) / 2, (int)(Height * 0.7));
        _startGameModeButton.Name = "_startGameModeButton";
        _startGameModeButton.TabIndex = 4;
        _startGameModeButton.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
        _startGameModeButton.Text = "Game";
        _startGameModeButton.UseVisualStyleBackColor = true;
        _startGameModeButton.Enabled = false;
        _startGameModeButton.Click += GameModeButtonClick;
        Controls.Add(_startDemoModeButton);

        ((System.ComponentModel.ISupportInitialize)_playingFieldSizeNumericUpDown).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private void DemoModeButtonClick(object? sender,  EventArgs e)
    {
        DemoModeClicked?.Invoke();
    }

    private void GameModeButtonClick(Object? sender, EventArgs e)
    {
        GameModeClicked?.Invoke();
    }
}
