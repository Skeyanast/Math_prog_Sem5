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

        Button startStopButton = new Button { Text = "Start", AutoSize = true };
        startStopButton.Location = new Point(15, 350);
        buttonsPanel.Controls.Add(startStopButton);

        Button addBallButton = new Button { Text = "Add Ball", AutoSize = true };
        addBallButton.Location = new Point(115, 350);
        buttonsPanel.Controls.Add(addBallButton);

        Button removeBallButton = new Button { Text = "Start", AutoSize = true };
        removeBallButton.Location = new Point(225, 350);
        buttonsPanel.Controls.Add(removeBallButton);
        Controls.Add(buttonsPanel);

        DataContext = new MainViewModel();

        startStopButton.DataBindings.Add(new Binding(nameof(startStopButton.Command), DataContext, "StartStopCommand", true));

        addBallButton.DataBindings.Add(new Binding(nameof(addBallButton.Command), DataContext, "AddCommand", true));

        removeBallButton.DataBindings.Add(new Binding(nameof(removeBallButton.Command), DataContext, "RemoveCommand", true));
    }
}