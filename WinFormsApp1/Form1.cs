using System.Collections.ObjectModel;

namespace WinFormsApp1;

public partial class Form1 : Form
{
    private readonly PresentationSceneViewModel _viewModel;

    private readonly Panel _planetarySystemPanel;
    private readonly Panel _pieDiagramPanel;
    private readonly Button _toggleViewButton;
    private readonly Button _togglePlanetarySystemPlayingButton;

    public Form1()
    {
        InitializeComponent();

        _viewModel = new PresentationSceneViewModel();

        DoubleBuffered = true;

        // planetarySystemPanel
        _planetarySystemPanel = new DoubleBufferedPanel { Padding = new Padding(10) };
        _planetarySystemPanel.Dock = DockStyle.Bottom;
        _planetarySystemPanel.Height = (int)(Height * 0.7);
        Controls.Add(_planetarySystemPanel);

        // pieDiagramPanel;
        _pieDiagramPanel = new DoubleBufferedPanel() { Padding = new Padding(10) };
        _pieDiagramPanel.Height = (int)(Height * 0.7);
        _pieDiagramPanel.Width = _pieDiagramPanel.Height;
        _pieDiagramPanel.Location = new Point((Width - _pieDiagramPanel.Width) / 2, Height - (int)(_pieDiagramPanel.Height * 1.1));
        Controls.Add(_pieDiagramPanel);

        // togglePlanetarySystemPlayingButton
        _togglePlanetarySystemPlayingButton = new Button();
        _togglePlanetarySystemPlayingButton.Size = new Size((int)(Width * 0.3), (int)(Height * 0.1));
        _togglePlanetarySystemPlayingButton.Location = new Point((int)(Width * 0.1), (int)(Height * 0.05));
        _togglePlanetarySystemPlayingButton.TabStop = true;
        Controls.Add(_togglePlanetarySystemPlayingButton);

        // toggleViewButton
        _toggleViewButton = new Button();
        _toggleViewButton.Size = new Size((int)(Width * 0.3), (int)(Height * 0.1));
        _toggleViewButton.Location = new Point((int)(Width * 0.6), (int)(Height * 0.05));
        _toggleViewButton.TabStop = true;
        Controls.Add(_toggleViewButton);

        UpdateViewVisibility();

        SubscribeOnEvents();

        BindControls();
    }

    private void PresentationSceneViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (sender is PresentationSceneViewModel presentationSceneViewModel)
        {
            if (e.PropertyName == nameof(presentationSceneViewModel.PlanetarySystemViewActive))
            {
                UpdateViewVisibility();
            }
        }
    }

    private void PlanetarySystemPanel_Paint(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        DrawSun(g, _planetarySystemPanel, _viewModel.PlanetarySystem.SunRadius);

        foreach (Planet planet in _viewModel.PlanetarySystem.Planets)
        {
            DrawPlanetOrbit(g, _planetarySystemPanel, planet);
        }

        foreach (Planet planet in _viewModel.PlanetarySystem.Planets)
        {
            DrawPlanet(g, _planetarySystemPanel, planet);
        }

        void DrawSun(Graphics g, Panel planetarySystemPanel, float sunRadius)
        {
            g.FillEllipse(
                Brushes.Yellow,
                planetarySystemPanel.Width / 2 - sunRadius,
                planetarySystemPanel.Height / 2 - sunRadius,
                sunRadius * 2,
                sunRadius * 2
            );
        }

        void DrawPlanetOrbit(Graphics g, Panel planetarySystemPanel, Planet planet)
        {
            float orbitDiameter = planet.OrbitRadius * 2;
            float orbitX = (planetarySystemPanel.Width / 2) - planet.OrbitRadius;
            float orbitY = (planetarySystemPanel.Height / 2) - planet.OrbitRadius;
            g.DrawEllipse(Pens.LightGray, orbitX, orbitY, orbitDiameter, orbitDiameter);
        }

        void DrawPlanet(Graphics g, Panel planetarySystemPanel, Planet planet)
        {
            float angleInRadians = planet.Angle * (float)(Math.PI / 180);
            float x = (float)(planetarySystemPanel.Width / 2 + planet.OrbitRadius * Math.Cos(angleInRadians)) - planet.PlanetRadius;
            float y = (float)(planetarySystemPanel.Height / 2 + planet.OrbitRadius * Math.Sin(angleInRadians)) - planet.PlanetRadius;
            g.FillEllipse(Brushes.Blue, x, y, planet.PlanetRadius * 2, planet.PlanetRadius * 2);
        }
    }

    private void PieDiagramPanel_Paint(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        DrawPieDiagram(g, _viewModel.PieDiagram, _pieDiagramPanel.ClientRectangle);
    
        void DrawPieDiagram(Graphics g, PieDiagram pieDiagram, Rectangle clientRectangle)
        {
            if (pieDiagram.Total == 0) return;

            float startAngle = 0;

            for (int i = 0; i < pieDiagram.Data.Count; i++)
            {
                float sweepAngle = pieDiagram.RelativeData[i] * 360;

                using (Brush brush = new SolidBrush(pieDiagram.Data[i].Color))
                {
                    g.FillPie(brush, clientRectangle, startAngle, sweepAngle);
                }

                startAngle += sweepAngle;
            }
        }
    }

    private void UpdatePlanetarySystem(object? sender, EventArgs e)
    {
        _planetarySystemPanel.Invalidate();
    }

    private void UpdateViewVisibility()
    {
        _planetarySystemPanel.Visible = _viewModel.PlanetarySystemViewActive;
        _togglePlanetarySystemPlayingButton.Visible = _viewModel.PlanetarySystemViewActive;

        _pieDiagramPanel.Visible = !_viewModel.PlanetarySystemViewActive;
    }

    private void SubscribeOnEvents()
    {
        _viewModel.PlanetarySystem.OnTimerTick += UpdatePlanetarySystem;
        _viewModel.PropertyChanged += PresentationSceneViewModel_PropertyChanged;
        _planetarySystemPanel.Paint += PlanetarySystemPanel_Paint;
        _pieDiagramPanel.Paint += PieDiagramPanel_Paint;
    }

    private void BindControls()
    {
        _togglePlanetarySystemPlayingButton.DataBindings.Add(new Binding(nameof(_togglePlanetarySystemPlayingButton.Text), _viewModel, nameof(_viewModel.TogglePlanetarySystemPlayingButtonText), true, DataSourceUpdateMode.OnPropertyChanged));
        _togglePlanetarySystemPlayingButton.DataBindings.Add(new Binding(nameof(_togglePlanetarySystemPlayingButton.Command), _viewModel, nameof(_viewModel.TogglePlanetarySystemPlayingCommand), true));

        _toggleViewButton.DataBindings.Add(new Binding(nameof(_toggleViewButton.Text), _viewModel, nameof(_viewModel.ToggleViewButtonText), true, DataSourceUpdateMode.OnPropertyChanged));
        _toggleViewButton.DataBindings.Add(new Binding(nameof(_toggleViewButton.Command), _viewModel, nameof(_viewModel.ToggleViewButtonCommand), true));
    }
}