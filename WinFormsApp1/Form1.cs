namespace WinFormsApp1;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        Panel ballsPanel = new Panel { Padding = new Padding(10) };
        ballsPanel.Dock = DockStyle.Fill;
        Controls.Add(ballsPanel);

        Panel buttonsPanel = new Panel { Padding = new Padding(10) };
        buttonsPanel.Dock = DockStyle.Bottom;

        Button startStopButton = new Button { Text = "Start" };
        startStopButton.Location = new Point(15, 15);
        startStopButton.Size = new Size(100, 30);
        buttonsPanel.Controls.Add(startStopButton);

        Button addBallButton = new Button { Text = "Add Ball" };
        addBallButton.Location = new Point(115, 15);
        addBallButton.Size = new Size(100, 30);
        buttonsPanel.Controls.Add(addBallButton);

        Button removeBallButton = new Button { Text = "Remove Ball" };
        removeBallButton.Location = new Point(225, 15);
        removeBallButton.Size = new Size(100, 30);
        buttonsPanel.Controls.Add(removeBallButton);
        Controls.Add(buttonsPanel);

        DataContext = new MainViewModel(ballsPanel.Controls, Bounds);

        startStopButton.DataBindings.Add(new Binding(nameof(startStopButton.Command), DataContext, "StartStopCommand", true));
        startStopButton.DataBindings.Add(new Binding(nameof(startStopButton.Text), DataContext, "StartStopText", true, DataSourceUpdateMode.OnPropertyChanged));

        addBallButton.DataBindings.Add(new Binding(nameof(addBallButton.Command), DataContext, "AddCommand", true));

        removeBallButton.DataBindings.Add(new Binding(nameof(removeBallButton.Command), DataContext, "RemoveCommand", true));
    }
}