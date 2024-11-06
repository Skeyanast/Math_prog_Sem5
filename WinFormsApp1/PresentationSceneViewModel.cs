using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WinFormsApp1;

internal class PresentationSceneViewModel : INotifyPropertyChanged
{
    private PlanetarySystem _planetarySystem;
    private string _toggleViewButtonText = "On Pie Diagram";
    private string _togglePlanetarySystemPlayingText = "Start";
    private bool _planetarySystemPlaying = false;

    public event PropertyChangedEventHandler? PropertyChanged;

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

    public float SunRadius
    {
        get => _planetarySystem.SunRadius;
    }

    public ICommand ToggleViewButtonCommand { get; private set; }

    public ICommand TogglePlanetarySystemPlayingButtonCommand { get; private set; }

    public PresentationSceneViewModel()
    {
        ObservableCollection<Planet> planets = new ObservableCollection<Planet>
        {
            new Planet { Name = "Planet 1", Angle = 0f, Speed = 1f, PlanetRadius = 5f, OrbitRadius = 50f },
            new Planet { Name = "Planet 2", Angle = 120f, Speed = 0.5f, PlanetRadius = 7f, OrbitRadius = 80f },
            new Planet { Name = "Planet 3", Angle = 240f, Speed = 0.8f, PlanetRadius = 4f, OrbitRadius = 110f }
        };
        float sunRadius = 15f;
        _planetarySystem = new PlanetarySystem(planets, sunRadius);

        ToggleViewButtonCommand = new MainCommand(_ =>
        {
            throw new NotImplementedException();
        });

        TogglePlanetarySystemPlayingButtonCommand = new MainCommand(_ =>
        {
            TogglePlaying();
        });
    }

    private void TogglePlaying()
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