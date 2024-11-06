using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Timer = System.Windows.Forms.Timer;

namespace WinFormsApp1;

internal class PlanetarySystem : INotifyPropertyChanged
{
    private ObservableCollection<Planet> _planets;
    private float _sunRadius;
    private readonly Timer _timer;

    public event EventHandler? OnTimerTick;
    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<Planet> Planets
    {
        get => _planets;
        set
        {
            _planets = value;
            OnPropertyChanged();
        }
    }

    public float SunRadius
    {
        get => _sunRadius;
        set
        {
            _sunRadius = value;
            OnPropertyChanged();
        }
    }

    public PlanetarySystem(ObservableCollection<Planet> planets, float sunRadius)
    {
        _planets = planets;
        _sunRadius = sunRadius;
        _timer = new Timer();
        InitializeTimer();
    }

    public void StartMovement()
    {
        _timer.Start();
    }

    public void StopMovement()
    {
        _timer.Stop();
    }

    private void InitializeTimer()
    {
        _timer.Interval = 30;
        _timer.Tick += Timer_Tick;
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        UpdatePlanetPositions();
        OnTimerTick?.Invoke(this, EventArgs.Empty);
    }

    private void UpdatePlanetPositions()
    {
        foreach(Planet planet in Planets)
        {
            planet.Angle = (planet.Angle + planet.Speed) % 360;
        }
        OnPropertyChanged(nameof(Planets));
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
