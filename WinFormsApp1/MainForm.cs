
namespace WinFormsApp1;

public partial class MainForm : Form
{
    private const int GRIDSIZE = 40;
    private const int ROWS = 10;
    private const int COLUMNS = 10;

    private int[,] _maze;
    private int _playerX, _playerY;
    private bool[,] _editGrid;
    private List<DynamicObject> _dynamicObjects;
    private readonly System.Windows.Forms.Timer _moveTimer;

    public MainForm()
    {
        InitializeComponent();
        DoubleBuffered = true;
        Width = COLUMNS * GRIDSIZE + 16;
        Height = ROWS * GRIDSIZE + 39;
        KeyDown += MainForm_KeyDown;
        Paint += MainForm_Paint;

        InitializeMaze();
        InitializeDynamicObjects();

        _editGrid = new bool[ROWS, COLUMNS];

        _moveTimer = new System.Windows.Forms.Timer();
        _moveTimer.Interval = 500;
        _moveTimer.Tick += (s, e) => MoveDynamicObjects();
        _moveTimer.Start();
    }

    private void InitializeMaze()
    {
        _maze = new int[,]
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 0, 1, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 0, 1, 1, 1, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1, 0, 1, 1, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 1, 0, 0, 1 },
            { 1, 0, 1, 1, 1, 1, 1, 0, 1, 1 },
            { 1, 0, 0, 0, 0, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 0, 0, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        };

        _playerX = 1;
        _playerY = 1;
    }

    private void InitializeDynamicObjects()
    {
        _dynamicObjects = new()
        {
            new DynamicObject(3, 1, 1),
            new DynamicObject(5, 3, 2)
        };
    }

    private void MainForm_KeyDown(object? sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.W:
                MovePlayer(0, -1);
                break;
            case Keys.S:
                MovePlayer(0, 1);
                break;
            case Keys.A:
                MovePlayer(-1, 0);
                break;
            case Keys.D:
                MovePlayer(1, 0);
                break;
            case Keys.Space:
                ToggleCell();
                break;
        }
        Invalidate();
    }

    private void ToggleCell()
    {
        int cellX = _playerX;
        int cellY = _playerY;

        if (cellX < COLUMNS &&
            cellY < ROWS)
        {
            _editGrid[cellY, cellX] = !_editGrid[cellY, cellX];
        }
    }

    private void MovePlayer(int deltaX, int deltaY)
    {
        int newX = _playerX + deltaX;
        int newY = _playerY + deltaY;

        if (newX >= 0 && newX < COLUMNS &&
            newY >= 0 && newY < ROWS &&
            _maze[newY, newX] == 0)
        {
            _playerX = newX;
            _playerY = newY;
        }
    }

    private void MoveDynamicObjects()
    {
        foreach (DynamicObject obj in _dynamicObjects)
        {
            obj.Move(_maze, COLUMNS, ROWS, _playerX, _playerY);
        }
        Invalidate();
    }

    private void MainForm_Paint(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        for (int y = 0; y < ROWS; y++)
        {
            for (int x = 0; x < COLUMNS; x++)
            {
                Color color = _maze[y, x] == 1
                    ? Color.Black
                    : Color.White;
                g.FillRectangle(new SolidBrush(color), x * GRIDSIZE, y * GRIDSIZE, GRIDSIZE, GRIDSIZE);

                if (_editGrid[y, x])
                {
                    g.FillRectangle(new SolidBrush(Color.DarkGray), x * GRIDSIZE, y * GRIDSIZE, GRIDSIZE, GRIDSIZE);
                }
            }
        }

        g.FillRectangle(Brushes.Blue, _playerX * GRIDSIZE, _playerY * GRIDSIZE, GRIDSIZE, GRIDSIZE);

        foreach (var obj in _dynamicObjects)
        {
            g.FillRectangle(Brushes.Red, obj.X * GRIDSIZE, obj.Y * GRIDSIZE, GRIDSIZE, GRIDSIZE);
        }
    }
}
