using System.ComponentModel;
using System.Windows.Input;

namespace WinFormsApp1;

internal class MainViewModel
{
    private static int _ballId = 0;
    private bool _isPlaying;
    private Rectangle _formBounds;

    public ICommand StartStopCommand { get; set; }
    public ICommand AddCommand { get; set; }
    public ICommand RemoveCommand { get; set; }
    public BindingList<Ball> Balls { get; }

    public MainViewModel()
    {
        Balls = new BindingList<Ball>
        {
            new Ball(
                _ballId++,
                new Point(200, 200),
                new Size(100, 100),
                new Point(10, 10)
                ),
            new Ball(
                _ballId++,
                new Point(400, 400),
                new Size(100, 100),
                new Point(-10, 10)
                )
        };

        StartStopCommand = new MainCommand(_ =>
        {

        });

        AddCommand = new MainCommand(_ =>
        {
            Balls.Add(
                new Ball(
                    _ballId++,
                    new Point(200, 200),
                    new Size(100, 100),
                    new Point(10, 10)
                    )
                );
        });

        RemoveCommand = new MainCommand(_ =>
        {
            if (Balls.Count > 0)
            {
                Balls.RemoveAt(Balls.Count - 1);
            }
        });
    }

    /*private void PlayButton_Click(object sender, EventArgs e)
    {
        _isPlaying = !_isPlaying;
        if (_isPlaying)
        {
            _ballSpeedX = _ballLastSpeedX;
            _ballSpeedY = _ballLastSpeedY;
            _ballTimer1.Enabled = true;
            _playButton.Text = "Stop";
        }
        else
        {
            _ballLastSpeedX = _ballSpeedX;
            _ballLastSpeedY = _ballSpeedY;
            _ballSpeedX = 0;
            _ballSpeedY = 0;
            _ballTimer1.Enabled = false;
            _playButton.Text = "Start";
        }
    }*/

    /*private void CheckCollisionsWithBorders()
    {
        if ((_ballX <= 0) || (_ballX + _ballWidth >= _formBounds.Width))
        {
            _ballSpeedX *= -1;
        }

        if ((_ballY <= 0) || (_ballY + _ballHeight >= _formBounds.Height))
        {
            _ballSpeedY *= -1;
        }
    }*/
}