namespace WinFormsApp1;

public partial class MainForm : Form
{
    private const int CELLSIZE = 40;

    private int[,] _maze;
    private Point _start;
    private Point _end;
    private List<Point> _path = new();

    public MainForm()
    {
        InitializeComponent();
        DoubleBuffered = true;

        //InitializeMaze(0, new Point(1, 1), new Point(6, 5), out _maze);
        //InitializeMaze(1, new Point(1, 1), new Point(7, 6), out _maze);
        InitializeMaze(2, new Point(1, 1), new Point(8, 8), out _maze);

        Paint += MainForm_Paint;
        _dijkstraButton.Click += (s, e) =>  AlgorithmExecutionButton_Click(Dijkstra);
        _aStarButton.Click += (s, e) =>  AlgorithmExecutionButton_Click(AStar);
        _waveAlgorithmButton.Click += (s, e) =>  AlgorithmExecutionButton_Click(WaveAlgorithm);
        _clearPathButton.Click += (s, e) => ClearPathButton_Click();
    }

    private void InitializeMaze(int mazeNumber, Point start, Point end, out int[,] maze)
    {
        List<int[,]> testMazes =
        [
            new int[,]
            {
                { 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 1, 0, 0, 0, 1 },
                { 1, 1, 0, 1, 0, 1, 0, 1 },
                { 1, 0, 0, 1, 0, 1, 0, 1 },
                { 1, 0, 1, 1, 0, 1, 0, 1 },
                { 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1 }
            },
            new int[,]
            {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 1, 0, 1, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 1, 0, 0, 1 },
                { 1, 1, 0, 0, 1, 1, 0, 1, 1 },
                { 1, 0, 0, 1, 1, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1 }
            },
            new int[,]
            {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 1, 0, 0, 0, 1, 1, 0, 1 },
                { 1, 0, 1, 1, 1, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1, 1, 0, 1 },
                { 1, 1, 0, 1, 1, 0, 0, 1, 0, 1 },
                { 1, 0, 0, 1, 1, 1, 0, 1, 0, 1 },
                { 1, 0, 1, 1, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 0, 1, 1, 0, 1, 1, 0, 1 },
                { 1, 1, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
            },
        ];

        maze = testMazes[mazeNumber];

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

        Invalidate();
    }

    private void MainForm_Paint(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        for (int y = 0; y < _maze.GetLength(0); y++)
        {
            for (int x = 0; x < _maze.GetLength(1); x++)
            {
                Color color = _maze[y, x] == 1 ? Color.Black : Color.White;
                g.FillRectangle(new SolidBrush(color), x * CELLSIZE, y * CELLSIZE, CELLSIZE, CELLSIZE);
            }
        }

        g.FillRectangle(Brushes.Green, _start.X * CELLSIZE, _start.Y * CELLSIZE, CELLSIZE, CELLSIZE);
        g.FillRectangle(Brushes.Red, _end.X * CELLSIZE, _end.Y * CELLSIZE, CELLSIZE, CELLSIZE);

        foreach (Point point in _path)
        {
            g.FillRectangle(Brushes.Cyan, point.X * CELLSIZE, point.Y * CELLSIZE, CELLSIZE, CELLSIZE);
        }
    }

    private void AlgorithmExecutionButton_Click(Action PathfindingAlgorithm)
    {
        System.Diagnostics.Stopwatch stopwatch = new();
        stopwatch.Start();
        PathfindingAlgorithm?.Invoke();
        stopwatch.Stop();
        Invalidate();
        _algorithmNameLabel.Text = $"Algorithm Name: {PathfindingAlgorithm?.Method.Name}";
        _executionTimeLabel.Text = $"Execution time: {stopwatch.ElapsedMilliseconds} ms";
    }

    private void ClearPathButton_Click()
    {
        _path.Clear();
        Invalidate();
    }

    private void Dijkstra()
    {
        int[,] distance = new int[_maze.GetLength(0), _maze.GetLength(1)];
        Point[,] previous = new Point[_maze.GetLength(0), _maze.GetLength(1)];
        SortedSet<PointDistance> priorityQueue = new(
            Comparer<PointDistance>.Create((a, b) =>
            {
                int compareResult = a.Distance.CompareTo(b.Distance);
                return compareResult == 0
                    ? a.Point.GetHashCode().CompareTo(b.Point.GetHashCode())
                    : compareResult;
            }
        ));

        for (int y = 0; y < _maze.GetLength(0); y++)
        {
            for (int x = 0; x < _maze.GetLength(1); x++)
            {
                distance[y, x] = int.MaxValue;
                previous[y, x] = Point.Empty;
            }
        }

        distance[_start.Y, _start.X] = 0;
        priorityQueue.Add(new PointDistance(_start, 0));

        while (priorityQueue.Count > 0)
        {
            PointDistance? current = priorityQueue.Min;
            priorityQueue.Remove(current);

            if (current.Point == _end)
            {
                break;
            }

            foreach (Point neighbor in GetNeighbors(current.Point))
            {
                if (_maze[neighbor.Y, neighbor.X] == 1)
                {
                    continue;
                }

                int newDist = distance[current.Point.Y, current.Point.X] + 1;

                if (newDist < distance[neighbor.Y, neighbor.X])
                {
                    distance[neighbor.Y, neighbor.X] = newDist;
                    previous[neighbor.Y, neighbor.X] = current.Point;
                    priorityQueue.Add(new PointDistance(neighbor, newDist));
                }
            }
        }

        _path.Clear();
        for (Point at = _end; at != Point.Empty; at = previous[at.Y, at.X])
        {
            _path.Add(at);
        }
        _path.Reverse();
    }

    private void AStar()
    {
        HashSet<Point> openSet = new();
        Dictionary<Point, Point> cameFrom = new();
        Dictionary<Point, int> gScore = new();
        Dictionary<Point, int> fScore = new();

        foreach (int y in Enumerable.Range(0, _maze.GetLength(0)))
        {
            foreach (int x in Enumerable.Range(0, _maze.GetLength(1)))
            {
                gScore[new Point(x, y)] = int.MaxValue;
                fScore[new Point(x, y)] = int.MaxValue;
            }
        }
        gScore[_start] = 0;
        fScore[_start] = Heuristic(_start, _end);
        openSet.Add(_start);

        while (openSet.Count > 0)
        {
            Point currentPoint = openSet.OrderBy(p => fScore[p]).First();

            if (currentPoint == _end)
            {
                ReconstructPath(cameFrom, currentPoint);
                return;
            }

            openSet.Remove(currentPoint);

            foreach (Point neighbor in GetNeighbors(currentPoint))
            {
                if (_maze[neighbor.Y, neighbor.X] == 1)
                {
                    continue;
                }

                int tentativeGScore = gScore[currentPoint] + 1;
                if (tentativeGScore < gScore[neighbor])
                {
                    cameFrom[neighbor] = currentPoint;
                    gScore[neighbor] = tentativeGScore;
                    fScore[neighbor] = gScore[neighbor] + Heuristic(neighbor, _end);
                    openSet.Add(neighbor);
                }
            }
        }

        void ReconstructPath(Dictionary<Point, Point> cameFrom, Point current)
        {
            _path.Clear();
            _path.Add(current);
            while (cameFrom.TryGetValue(current, out Point next))
            {
                current = next;
                _path.Add(current);
            }
            _path.Reverse();
        }

        static int Heuristic(Point a, Point b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }
    }

    private void WaveAlgorithm()
    {
        int[,] wave = new int[_maze.GetLength(0), _maze.GetLength(1)];
        Queue<Point> queue = new();
        wave[_start.Y, _start.X] = 1;
        queue.Enqueue(_start);

        while (queue.Count > 0)
        {
            Point current = queue.Dequeue();
            
            if (current == _end)
            {
                GetPathFromWave(wave, current);
                return;
            }

            foreach (Point neighbor in GetNeighbors(current))
            {
                if (_maze[neighbor.Y, neighbor.X] == 1 ||
                    wave[neighbor.Y, neighbor.X] != 0)
                {
                    continue;
                }

                wave[neighbor.Y, neighbor.X] = wave[current.Y, current.X] + 1;
                queue.Enqueue(neighbor);
            }
        }

        void GetPathFromWave(int[,] wave, Point end)
        {
            _path.Clear();
            Point current = end;

            while (wave[current.Y, current.X] != 1)
            {
                _path.Add(current);

                foreach (Point neighbor in GetNeighbors(current))
                {
                    if (wave[neighbor.Y, neighbor.X] == wave[current.Y, current.X] - 1)
                    {
                        current = neighbor;
                        break;
                    }
                }
            }
            _path.Add(_start);
            _path.Reverse();
        }
    }

    private bool PointInBounds(Point point)
    {
        if (point.X >= 0 && point.X < _maze.GetLength(1) &&
            point.Y >= 0 && point.Y < _maze.GetLength(0))
        {
            return true;
        }
        return false;
    }

    private IEnumerable<Point> GetNeighbors(Point current)
    {
        Point[] directions = new[]
        {
            new Point(0, 1),
            new Point(0, -1),
            new Point(1, 0),
            new Point(-1, 0)
        };

        foreach (Point direction in directions)
        {
            Point neighbor = new(current.X + direction.X, current.Y + direction.Y);
            if (PointInBounds(neighbor))
            {
                yield return neighbor;
            }
        }
    }
}
