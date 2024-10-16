using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using static System.Windows.Forms.Control;

namespace WinFormsApp1;

internal class MainViewModel : INotifyPropertyChanged
{
    private static int _ballId = 0;
    private int _bounceCount = 0;
    private bool _isPlaying = false;
    private Rectangle _formBounds;
    private string _startStopText = "Start";

    public event PropertyChangedEventHandler? PropertyChanged;

    public ICommand StartStopCommand { get; set; }
    public ICommand AddCommand { get; set; }
    public ICommand RemoveCommand { get; set; }
    public BindingList<Ball> Balls { get; }
    public ControlCollection BallsControlCollection { get; }
    public string StartStopText
    {
        get => _startStopText;
        private set
        {
            if (_startStopText != value)
            {
                _startStopText = value;
                OnPropertyChanged();
            }
        }
    }
    public Rectangle FormBounds
    {
        get => _formBounds;
        private set => _formBounds = value;
    }
    public int BallsCount
    {
        get => Balls.Count;
    }
    public int BounceCount
    {
        get => _bounceCount;
        private set
        {
            if (_bounceCount != value)
            {
                _bounceCount = value;
                OnPropertyChanged();
            }
        }
    }

    public MainViewModel(ControlCollection controlCollection, Rectangle formBounds)
    {
        Balls = new BindingList<Ball>();
        BallsControlCollection = controlCollection;

        CreateNewBall(new Point(200, 200), new Size(100, 100), new Point(10, -10), _isPlaying);

        FormBounds = formBounds;

        StartStopCommand = new MainCommand(_ =>
        {
            TogglePlaying();
        });

        AddCommand = new MainCommand(_ =>
        {
            if (_ballId % 2 == 0)
            {
                CreateNewBall(new Point(200, 200), new Size(100, 100), new Point(10, -10), _isPlaying);
            }
            else
            {
                CreateNewBall(new Point(600, 200), new Size(100, 100), new Point(-10, -10), _isPlaying);
            }
        });

        RemoveCommand = new MainCommand(_ =>
        {
            RemoveBall();
        });
    }

    private void TogglePlaying()
    {
        _isPlaying = !_isPlaying;
        if (_isPlaying)
        {
            StartStopText = "Stop";
            foreach (Ball ball in Balls)
            {
                ball.StartMovement();
            }
        }
        else
        {
            StartStopText = "Start";
            foreach (Ball ball in Balls)
            {
                ball.StopMovement();
            }
        }
    }

    private void CreateNewBall(Point position, Size size, Point speed, bool isMoving = false)
    {
        Ball newBall = new Ball(
            _ballId++,
            position,
            size,
            speed
        );
        newBall.OnTimerTick += ProcessCollisionsWithBorders;
        Balls.Add(newBall);
        BallsControlCollection.Add(newBall.PictureBox);
        OnPropertyChanged(nameof(BallsCount));
        if (isMoving)
        {
            newBall.StartMovement();
        }
    }

    private void RemoveBall()
    {
        if (BallsCount > 0)
        {
            Ball ball = Balls[^1];
            ball.OnTimerTick -= ProcessCollisionsWithBorders;
            Balls.RemoveAt(Balls.Count - 1);
            BallsControlCollection.RemoveAt(BallsControlCollection.Count - 1);
            OnPropertyChanged(nameof(BallsCount));
        }
    }

    private void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    private void ProcessCollisionsWithBorders(object? sender, EventArgs e)
    {
        if (sender is Ball ball)
        {
            if ((ball.Position.X <= FormBounds.Left) || (ball.Position.X + ball.Size.Width >= FormBounds.Right))
            {
                ball.Speed = new Point(ball.Speed.X * (-1), ball.Speed.Y);
                BounceCount++;
            }

            if ((ball.Position.Y <= FormBounds.Top) || (ball.Position.Y + ball.Size.Height >= FormBounds.Bottom))
            {
                ball.Speed = new Point(ball.Speed.X, ball.Speed.Y * (-1));
                BounceCount++;
            }
        }
    }
}