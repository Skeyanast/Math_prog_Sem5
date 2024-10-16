namespace WinFormsApp1;

internal class Ball
{
    private int _id;
    private Point _speed;
    private PictureBox _pictureBox;
    private System.Windows.Forms.Timer _timer;

    public event EventHandler OnTimerTick;

    public Ball(int id, Point position, Size size, Point speed)
    {
        _id = id;
        _pictureBox = new PictureBox();
        _timer = new System.Windows.Forms.Timer();
        Position = position;
        Size = size;
        _speed = speed;
        StartInitializePictureBox();
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
        set => _speed = value;
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
        _pictureBox.Name = $"_ballPictureBox{_id}";
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
        OnTimerTick(this, EventArgs.Empty);
    }

    public void StartMovement()
    {
        _timer.Start();
    }

    public void StopMovement()
    {
        _timer.Stop();
    }
}