namespace WinFormsApp1;

public partial class Form1 : Form
{
    private readonly MainViewModel _viewModel;

    public Form1()
    {
        InitializeComponent();

        // ballPanel
        Panel ballsPanel = new Panel { Padding = new Padding(10) };
        ballsPanel.Dock = DockStyle.Fill;
        Controls.Add(ballsPanel);

        // toolStrip
        ToolStrip toolStrip = new ToolStrip { Padding = new Padding(5) };
        toolStrip.Font = new Font(toolStrip.Font.FontFamily, 12f);
        toolStrip.Dock = DockStyle.Bottom;
        toolStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
        toolStrip.CanOverflow = true;
        toolStrip.Stretch = true;

        // toolStripItems
        ToolStripButton startStopButton = new ToolStripButton { Text = "Start" };
        startStopButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
        toolStrip.Items.Add(startStopButton);
        ToolStripButton addBallButton = new ToolStripButton { Text = "Add Ball" };
        addBallButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
        toolStrip.Items.Add(addBallButton);
        ToolStripButton removeBallButton = new ToolStripButton { Text = "Remove Ball" };
        removeBallButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
        toolStrip.Items.Add(removeBallButton);
        Controls.Add(toolStrip);
        
        // statusStrip
        StatusStrip statusStrip = new StatusStrip { Padding = new Padding(5) };
        statusStrip.Dock = DockStyle.Bottom;
        statusStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;

        // statusStripItems
        ToolStripLabel ballsCountLabel = new ToolStripLabel { Text = "Ball count: 0" };
        statusStrip.Items.Add(ballsCountLabel);
        ToolStripLabel bounceCountLabel = new ToolStripLabel { Text = "Bounces count: 0" };
        statusStrip.Items.Add(bounceCountLabel);
        Controls.Add(statusStrip);

        _viewModel = new MainViewModel(ballsPanel.Controls, ballsPanel.Bounds);

        // bind controls
        startStopButton.DataBindings.Add(new Binding(nameof(startStopButton.Command), _viewModel, nameof(_viewModel.StartStopCommand), true));
        startStopButton.DataBindings.Add(new Binding(nameof(startStopButton.Text), _viewModel, nameof(_viewModel.StartStopText), true, DataSourceUpdateMode.OnPropertyChanged));

        addBallButton.DataBindings.Add(new Binding(nameof(addBallButton.Command), _viewModel, nameof(_viewModel.AddCommand), true));

        removeBallButton.DataBindings.Add(new Binding(nameof(removeBallButton.Command), _viewModel, nameof(_viewModel.RemoveCommand), true));

        Binding ballsCountBinding = new Binding(nameof(ballsCountLabel.Text), _viewModel, nameof(_viewModel.BallsCount), true, DataSourceUpdateMode.OnPropertyChanged);
        ballsCountBinding.Format += (sender, e) => e.Value = $"Balls count: {e.Value}";
        ballsCountLabel.DataBindings.Add(ballsCountBinding);

        Binding bounceCountBinding = new Binding(nameof(bounceCountLabel.Text), _viewModel, nameof(_viewModel.BounceCount), true, DataSourceUpdateMode.OnPropertyChanged);
        bounceCountBinding.Format += (sender, e) => e.Value = $"Bounces count: {e.Value}";
        bounceCountLabel.DataBindings.Add(bounceCountBinding);
    }
}