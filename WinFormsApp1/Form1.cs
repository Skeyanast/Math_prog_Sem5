namespace WinFormsApp1;

public partial class Form1 : Form
{
    private readonly PresentationSceneViewModel _viewModel;

    private readonly Panel _planetarySystemPanel;
    //private readonly Panel _pieDiagramPanel;
    //private readonly Button _toggleViewButton;
    private readonly Button _togglePlanetarySystemPlayingButton;

    public Form1()
    {
        InitializeComponent();

        DoubleBuffered = true;

        // planetarySystemPanel
        _planetarySystemPanel = new DoubleBufferedPanel { Padding = new Padding(10) };
        _planetarySystemPanel.Dock = DockStyle.Bottom;
        _planetarySystemPanel.Height = (int)(Height * 0.7);
        Controls.Add(_planetarySystemPanel);

        // togglePlanetarySystemPlayingButton
        _togglePlanetarySystemPlayingButton = new Button();
        _togglePlanetarySystemPlayingButton.Size = new Size((int)(Width * 0.3), (int)(Height * 0.1));
        _togglePlanetarySystemPlayingButton.Location = new Point(Width / 2 - _togglePlanetarySystemPlayingButton.Width / 2, (int)(Height * 0.1));
        _togglePlanetarySystemPlayingButton.TabStop = true;
        Controls.Add(_togglePlanetarySystemPlayingButton);

        _viewModel = new PresentationSceneViewModel();
        _viewModel.PlanetarySystem.OnTimerTick += UpdatePlanetarySystem;

        _planetarySystemPanel.Paint += Form1_Paint;

        BindControls();
    }

    private void Form1_Paint(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.FillEllipse(Brushes.Yellow, _planetarySystemPanel.Width / 2 - _viewModel.SunRadius, _planetarySystemPanel.Height / 2 - _viewModel.SunRadius, _viewModel.SunRadius * 2, _viewModel.SunRadius * 2);

        DrawOrbits(g);

        foreach (Planet planet in _viewModel.PlanetarySystem.Planets)
        {
            DrawPlanet(g, planet);
        }
    }

    private void UpdatePlanetarySystem(object? sender, EventArgs e)
    {
        _planetarySystemPanel.Invalidate();
    }

    private void DrawOrbits(Graphics g)
    {
        foreach (Planet planet in _viewModel.PlanetarySystem.Planets)
        {
            float orbitDiameter = planet.OrbitRadius * 2;
            float orbitX = (_planetarySystemPanel.Width / 2) - planet.OrbitRadius;
            float orbitY = (_planetarySystemPanel.Height / 2) - planet.OrbitRadius;
            g.DrawEllipse(Pens.LightGray, orbitX, orbitY, orbitDiameter, orbitDiameter);
        }
    }

    private void DrawPlanet(Graphics g, Planet planet)
    {
        float angleInRadians = planet.Angle * (float)(Math.PI / 180);
        float x = (float)(_planetarySystemPanel.Width / 2 + planet.OrbitRadius * Math.Cos(angleInRadians)) - planet.PlanetRadius;
        float y = (float)(_planetarySystemPanel.Height / 2 + planet.OrbitRadius * Math.Sin(angleInRadians)) - planet.PlanetRadius;
        g.FillEllipse(Brushes.Blue, x, y, planet.PlanetRadius * 2, planet.PlanetRadius * 2);
    }

    private void BindControls()
    {
        _togglePlanetarySystemPlayingButton.DataBindings.Add(new Binding(nameof(_togglePlanetarySystemPlayingButton.Text), _viewModel, nameof(_viewModel.TogglePlanetarySystemPlayingButtonText), true, DataSourceUpdateMode.OnPropertyChanged));
        _togglePlanetarySystemPlayingButton.DataBindings.Add(new Binding(nameof(_togglePlanetarySystemPlayingButton.Command), _viewModel, nameof(_viewModel.TogglePlanetarySystemPlayingButtonCommand), true));
    }
}