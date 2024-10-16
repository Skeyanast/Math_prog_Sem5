namespace WinFormsApp1;

internal class Ball
{
    private int _id;
    private Point _speed;
    private Point _lastSpeed;
    private PictureBox _pictureBox;
    private System.Windows.Forms.Timer _timer;

    public Ball(int id, Point position, Size size, Point speed)
    {
        _id = id;
        Position = position;
        Size = size;
        _speed = speed;
        _lastSpeed = speed;
        _pictureBox = new PictureBox();
        StartInitializePictureBox();
        _timer = new System.Windows.Forms.Timer();
        InitializeTimer();
        EndInitializePictureBox();
    }

    public Point Position
    {
        get => _pictureBox.Location;
        set => _pictureBox.Location = value;
    }
    public Size Size
    {
        get => _pictureBox.Size;
        set => _pictureBox.Size = value;
    }
    public Point Speed
    {
        get => _speed;
        set
        {
            _speed = value;
            _lastSpeed = _speed;
        }
    }
    public Point LastSpeed
    {
        get => _lastSpeed;
    }
    public PictureBox PictureBox
    {
        get => _pictureBox;
        set => _pictureBox = value;
    }
    public System.Windows.Forms.Timer Timer
    {
        get => _timer;
        set => _timer = value;
    }
    
    private void StartInitializePictureBox()
    {
        ((System.ComponentModel.ISupportInitialize)_pictureBox).BeginInit();
        _pictureBox.Image = Properties.Resources.pngwing_com2;
        _pictureBox.Location = Position;
        _pictureBox.Name = $"_ballPictureBox{Guid.NewGuid()}";
        _pictureBox.Size = Size;
        _pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
        _pictureBox.TabIndex = _id;
        _pictureBox.TabStop = false;
    }

    private void EndInitializePictureBox()
    {
        ((System.ComponentModel.ISupportInitialize)_pictureBox).EndInit();
    }

    private void InitializeTimer()
    {
        _timer.Interval = 50;
        _timer.Tick += _timer_Tick;
    }

    private void _timer_Tick(object? sender, EventArgs e)
    {
        Position = new Point(Position.X + _speed.X, Position.Y + _speed.Y);
    }
}