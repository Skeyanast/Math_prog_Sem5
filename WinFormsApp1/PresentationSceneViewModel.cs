using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WinFormsApp1;

internal class PresentationSceneViewModel : INotifyPropertyChanged
{
    private readonly PlanetarySystem _planetarySystem;
    private readonly PieDiagram _pieDiagram;
    private string _toggleViewButtonText = "On Pie Diagram";
    private string _togglePlanetarySystemPlayingText = "Start";
    private bool _planetarySystemPlaying = false;
    private bool _planetarySystemViewActive = true;

    public event PropertyChangedEventHandler? PropertyChanged;

    public bool PlanetarySystemViewActive
    {
        get => _planetarySystemViewActive;
        set
        {
            if (_planetarySystemViewActive != value)
            {
                _planetarySystemViewActive = value;
                OnPropertyChanged();
            }
        }
    }

    public string ToggleViewButtonText
    {
        get => _toggleViewButtonText;
        set
        {
            if (_toggleViewButtonText != value)
            {
                _toggleViewButtonText = value;
                OnPropertyChanged();
            }
        }
    }

    public string TogglePlanetarySystemPlayingButtonText
    {
        get => _togglePlanetarySystemPlayingText;
        set
        {
            if ( _togglePlanetarySystemPlayingText != value)
            {
                _togglePlanetarySystemPlayingText = value;
                OnPropertyChanged();
            }
        }
    }

    public PlanetarySystem PlanetarySystem
    {
        get => _planetarySystem;
    }

    public PieDiagram PieDiagram
    {
        get => _pieDiagram;
    }

    public ICommand ToggleViewButtonCommand { get; private set; }

    public ICommand TogglePlanetarySystemPlayingCommand { get; private set; }

    public PresentationSceneViewModel()
    {
        ObservableCollection<Planet> planets =
        [
            new Planet { Name = "Planet 1", Angle = 0f, Speed = 1.3f, PlanetRadius = 7f, OrbitRadius = 50f },
            new Planet { Name = "Planet 2", Angle = 120f, Speed = 1.1f, PlanetRadius = 10f, OrbitRadius = 90f },
            new Planet { Name = "Planet 3", Angle = 240f, Speed = 1.7f, PlanetRadius = 8f, OrbitRadius = 150f },
        ];
        float sunRadius = 15f;
        _planetarySystem = new PlanetarySystem(planets, sunRadius);

        string pieDiagramName = "Product Sales";
        ObservableCollection<IDiagramCategory<int>> diagramCategories =
        [
            new ProductCategory<int>() { Name = "Category 1", Value = 10, Color = Color.Red },
            new ProductCategory<int>() { Name = "Category 2", Value = 15, Color = Color.Blue },
            new ProductCategory<int>() { Name = "Category 3", Value = 25, Color = Color.Green },
            new ProductCategory<int>() { Name = "Category 4", Value = 50, Color = Color.Yellow },
            new ProductCategory<int>() { Name = "Category 5", Value = 0, Color = Color.Brown },
            new ProductCategory<int>() { Name = "Category 6", Value = 0, Color = Color.Orange }
        ];
        _pieDiagram = new PieDiagram(pieDiagramName, diagramCategories);

        ToggleViewButtonCommand = new MainCommand(_ =>
        {
            ToggleView();
        });

        TogglePlanetarySystemPlayingCommand = new MainCommand(_ =>
        {
            TogglePlanetarySystemPlaying();
        });
    }

    private void ToggleView()
    {
        PlanetarySystemViewActive = !PlanetarySystemViewActive;
        if (PlanetarySystemViewActive)
        {
            ToggleViewButtonText = "On Pie Diagram";
        }
        else
        {
            ToggleViewButtonText = "On Planetary System";
        }
    }

    private void TogglePlanetarySystemPlaying()
    {
        _planetarySystemPlaying = !_planetarySystemPlaying;
        if (_planetarySystemPlaying)
        {
            TogglePlanetarySystemPlayingButtonText = "Stop";
            _planetarySystem.StartMovement();
        }
        else
        {
            TogglePlanetarySystemPlayingButtonText = "Start";
            _planetarySystem.StopMovement();
        }
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}