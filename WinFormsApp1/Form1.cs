namespace WinFormsApp1;

public partial class Form1 : Form
{
    private int _ballX, _ballY, _ballWidth, _ballHeight;
    private int _ballSpeedX, _ballSpeedY;
    private int _ballLastSpeedX, _ballLastSpeedY;
    private bool _isPlaying;
    private Rectangle _formBounds;

    public Form1()
    {
        InitializeComponent();
        _ballX = _ballPicture1.Location.X;
        _ballY = _ballPicture1.Location.Y;
        _ballWidth = _ballPicture1.Width;
        _ballHeight = _ballPicture1.Height;
        _ballSpeedX = 5;
        _ballSpeedY = 5;
        _ballLastSpeedX = _ballSpeedX;
        _ballLastSpeedY = _ballSpeedY;
        _formBounds = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);
    }

    private void _playButton_Click(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void Timer1_Tick(object sender, EventArgs e)
    {
        UpdateBallPosition();
    }

    private void Timer2_Tick(object sender, EventArgs e)
    {

    }

    private void PlayButton_Click(object sender, EventArgs e)
    {
        _isPlaying = !_isPlaying;
        if (_isPlaying)
        {
            _ballSpeedX = _ballLastSpeedX;
            _ballSpeedY = _ballLastSpeedY;
            _timer1.Enabled = true;
            _playButton.Text = "Стоп";
            _timer2.Enabled = true;
        }
        else
        {
            _ballLastSpeedX = _ballSpeedX;
            _ballLastSpeedY = _ballSpeedY;
            _ballSpeedX = 0;
            _ballSpeedY = 0;
            _timer1.Enabled = false;
            _playButton.Text = "Пуск";
            _timer2.Enabled = false;
        }
    }

    private void SpeedUpButton_Click(object sender, EventArgs e)
    {
        _ballSpeedX *= 2;
        _ballSpeedY *= 2;
    }

    private void SpeedDownButton_Click(object sender, EventArgs e)
    {
        if (_ballSpeedY > 1)
        {
            _ballSpeedX /= 2;
            _ballSpeedY /= 2;
        }
    }

    private void BallPicture1_LocationChanged(object sender, EventArgs e)
    {
        CheckCollisionsWithBorders();
    }

    private void BallPicture2_LocationChanged(object sender, EventArgs e)
    {

    }

    private void UpdateBallPosition()
    {
        _ballX += _ballSpeedX;
        _ballY += _ballSpeedY;
        _ballPicture1.Location = new Point(_ballX, _ballY);
    }

    private void CheckCollisionsWithBorders()
    {
        if ((_ballX <= 0) || (_ballX + _ballWidth >= _formBounds.Width))
        {
            _ballSpeedX *= -1;
        }

        if ((_ballY <= 0) || (_ballY + _ballHeight >= _formBounds.Height))
        {
            _ballSpeedY *= -1;
        }
    }
}
