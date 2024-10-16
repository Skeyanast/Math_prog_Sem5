namespace WinFormsApp1;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        Panel ballsPanel = new Panel { Padding = new Padding(10) };
        ballsPanel.Dock = DockStyle.Fill;
        Controls.Add(ballsPanel);

        ToolStrip toolStrip = new ToolStrip { Padding = new Padding(5) };
        toolStrip.Font = new Font(toolStrip.Font.FontFamily, 12f);
        toolStrip.Dock = DockStyle.Bottom;
        toolStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
        toolStrip.CanOverflow = true;
        toolStrip.Stretch = true;

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
        
        StatusStrip statusStrip = new StatusStrip { Padding = new Padding(5) };
        statusStrip.Dock = DockStyle.Bottom;
        statusStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;

        ToolStripLabel ballsCountLabel = new ToolStripLabel { Text = "Ball count: 0" };
        statusStrip.Items.Add(ballsCountLabel);
        ToolStripLabel bounceCountLabel = new ToolStripLabel { Text = "Bounces count: 0" };
        statusStrip.Items.Add(bounceCountLabel);
        Controls.Add(statusStrip);

        DataContext = new MainViewModel(ballsPanel.Controls, ballsPanel.Bounds);

        startStopButton.DataBindings.Add(new Binding(nameof(startStopButton.Command), DataContext, "StartStopCommand", true));
        startStopButton.DataBindings.Add(new Binding(nameof(startStopButton.Text), DataContext, "StartStopText", true, DataSourceUpdateMode.OnPropertyChanged));

        addBallButton.DataBindings.Add(new Binding(nameof(addBallButton.Command), DataContext, "AddCommand", true));

        removeBallButton.DataBindings.Add(new Binding(nameof(removeBallButton.Command), DataContext, "RemoveCommand", true));

        Binding ballsCountBinding = new Binding(nameof(ballsCountLabel.Text), DataContext, "BallsCount", true, DataSourceUpdateMode.OnPropertyChanged);
        ballsCountBinding.Format += (sender, e) => e.Value = $"Balls count: {e.Value}";
        ballsCountLabel.DataBindings.Add(ballsCountBinding);

        Binding bounceCountBinding = new Binding(nameof(bounceCountLabel.Text), DataContext, "BounceCount", true, DataSourceUpdateMode.OnPropertyChanged);
        bounceCountBinding.Format += (sender, e) => e.Value = $"Bounces count: {e.Value}";
        bounceCountLabel.DataBindings.Add(bounceCountBinding);
    }
}