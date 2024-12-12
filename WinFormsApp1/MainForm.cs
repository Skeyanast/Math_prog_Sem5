namespace WinFormsApp1;

public partial class MainForm : Form
{
    private const int CELLSIZE = 40;

    private int[,] _maze;
    private Color[,] _cellColors;
    private List<Point> _path = new();
    private Point _start;
    private Point _end;
    private int _currentStepIndex = 0;

    public MainForm()
    {
        InitializeComponent();
        DoubleBuffered = true;

        InitializeMaze(new Point(1, 1), new Point(5, 5), out _maze);

        Paint += MainForm_Paint;
        _waveAlgorithmButton.Click += (s, e) =>  AlgorithmExecutionButton_Click();
        _clearPathButton.Click += (s, e) => ClearPathButton_Click();
        _movementTimer.Tick += MovementTimer_Tick;
    }

    private void InitializeMaze(Point start, Point end, out int[,] maze)
    {
        maze = new int[,]
        {
            { 1, 1, 1, 1, 1, 1, 1 },
            { 1, 0, 0, 1, 0, 0, 1 },
            { 1, 0, 0, 0, 2, 0, 1 },
            { 1, 0, 2, 0, 3, 0, 1 },
            { 1, 0, 1, 0, 2, 0, 1 },
            { 1, 2, 0, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1, 1, 1 }
        };

        _cellColors = new Color[maze.GetLength(0), maze.GetLength(1)];
        for (int y = 0; y < maze.GetLength(0); y++)
        {
            for (int x = 0; x < maze.GetLength(1); x++)
            {
                _cellColors[y, x] = Color.White;
            }
        }

        if (!PointInBounds(start))
        {
            throw new ArgumentOutOfRangeException("Invalid start point");
        }
        if (!PointInBounds(end))
        {
            throw new ArgumentOutOfRangeException("Invalid end point");
        }
        _start = start;
        _end = end;
        _path.Add(_start);

        Invalidate();
    }

    private void StartMovement()
    {
        _currentStepIndex = 0;
        _movementTimer.Interval = 500;
        _movementTimer.Start();
    }

    private void AlgorithmExecutionButton_Click()
    {
        bool isReachable = WaveAlgorithm.Run(_maze, _start, _end, out _path);
        if (isReachable)
        {
            MessageBox.Show("Way was found!");
            StartMovement();

        }
        else
        {
            MessageBox.Show("Unreachable point");
        }
        Invalidate();
        _movementTimer.Start();
    }

    private bool PointInBounds(Point point)
    {
        return (point.X >= 0 && point.X < _maze.GetLength(1) &&
            point.Y >= 0 && point.Y < _maze.GetLength(0));
    }

    private void ClearPathButton_Click()
    {
        _currentStepIndex = 0;
        _path.Clear();
        _path.Add(_start);
        InitializeMaze(_start, _end, out _maze);
    }

    private void MovementTimer_Tick(object? sender, EventArgs e)
    {
        if (_currentStepIndex < _path.Count)
        {
            Point currentPoint = _path[_currentStepIndex];
            int cellValue = _maze[currentPoint.Y, currentPoint.X];

            switch (cellValue)
            {
                case (int)MazeCellStatus.SlowingObstacle:
                    _movementTimer.Interval = 1000;
                    break;
                case (int)MazeCellStatus.DangerousObstacle:
                    MessageBox.Show("Dangerous obstacle. Return to the start.");
                    _currentStepIndex = 0;
                    Invalidate();
                    return;
                default:
                    break;
            }

            _cellColors[currentPoint.Y, currentPoint.X] = Color.Green;
            _currentStepIndex++;
            Invalidate();
        }
        else
        {
            _movementTimer.Stop();
        }
    }

    private void MainForm_Paint(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        DrawMaze(g);
        DrawStartEnd(g);
        DrawCurrentPosition(g);
    }

    private void DrawMaze(Graphics g)
    {
        for (int y = 0; y < _maze.GetLength(0); y++)
        {
            for (int x = 0; x < _maze.GetLength(1); x++)
            {
                var color = _maze[y, x] switch
                {
                    (int)MazeCellStatus.Wall => Color.Black,
                    (int)MazeCellStatus.SlowingObstacle => Color.Blue,
                    (int)MazeCellStatus.DangerousObstacle => Color.Red,
                    _ => _cellColors[y, x],
                };
                using Brush brush = new SolidBrush(color);
                g.FillRectangle(brush, x * CELLSIZE, y * CELLSIZE, CELLSIZE, CELLSIZE);
            }
        }
    }

    private void DrawCurrentPosition(Graphics g)
    {
        if (_path != null && _currentStepIndex < _path.Count)
        {
            Point currentPoint = _path[_currentStepIndex];
            using Brush brush = new SolidBrush(Color.Orange);
            g.FillEllipse(brush, currentPoint.X * CELLSIZE + (CELLSIZE / 4), currentPoint.Y * CELLSIZE + (CELLSIZE / 4), CELLSIZE / 2, CELLSIZE / 2);
        }
    }

    private void DrawStartEnd(Graphics g)
    {
        g.FillRectangle(Brushes.LightGreen, _start.X * CELLSIZE, _start.Y * CELLSIZE, CELLSIZE, CELLSIZE);
        g.FillRectangle(Brushes.LightGreen, _end.X * CELLSIZE, _end.Y * CELLSIZE, CELLSIZE, CELLSIZE);
    }
}
