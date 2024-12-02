namespace WinFormsApp1;

public partial class MainForm : Form
{
    private const int CELLSIZE = 40;

    private int[,] _maze;
    private Point _start;
    private Point _end;

    public MainForm()
    {
        InitializeComponent();
        DoubleBuffered = true;

        InitializeMaze();

        Paint += MainForm_Paint;
    }

    private void InitializeMaze()
    {
        _maze = new int[,]
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 0, 0, 1, 0, 0, 0, 1, 1, 0, 1 },
            { 1, 0, 1, 1, 1, 0, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 0, 1, 1, 1, 0, 1 },
            { 1, 1, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1, 1, 1, 0, 0, 1 },
            { 1, 1, 1, 0, 0, 0, 0, 1, 0, 1 },
            { 1, 0, 0, 0, 1, 1, 1, 1, 0, 1 },
            { 1, 1, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        };

        _start = new Point(1, 1);
        _end = new Point(8, 8);

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
    }

    private void DijkstraButton_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Stopwatch stopwatch = new();
        stopwatch.Start();
        Dijkstra();
        stopwatch.Stop();
        MessageBox.Show($"Execution time: {stopwatch.ElapsedMilliseconds} ms");
    }

    private void AAsteriskButton_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Stopwatch stopwatch = new();
        stopwatch.Start();
        AAsterisk();
        stopwatch.Stop();
        MessageBox.Show($"Execution time: {stopwatch.ElapsedMilliseconds} ms");
    }

    private void WaveAlgorithmButton_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Stopwatch stopwatch = new();
        stopwatch.Start();
        WaveAlgorithm();
        stopwatch.Stop();
        MessageBox.Show($"Execution time: {stopwatch.ElapsedMilliseconds} ms");
    }

    private void Dijkstra()
    {
        int[,] distance = new int[_maze.GetLength(0), _maze.GetLength(1)];
        Point[,] previous = new Point[_maze.GetLength(0), _maze.GetLength(1)];
        SortedSet<PointDistance> priorityQueue = new(
            Comparer<PointDistance>.Create((a, b) =>
            {
                int cmp = a.Distance.CompareTo(b.Distance);
                return cmp == 0
                    ? a.Point.GetHashCode().CompareTo(b.Point.GetHashCode())
                    : cmp;
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

            foreach (var neighbor in GetNeighbors(current.Point))
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

        List<Point> path = new();
        for (Point at = _end; at != Point.Empty; at = previous[at.Y, at.X])
        {
            path.Add(at);
        }
        path.Reverse();

        DrawPath(path);
    }

    private void AAsterisk()
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
            Point current = openSet.OrderBy(p => fScore[p]).First();

            if (current == _end)
            {
                DrawPath(ReconstructPath(cameFrom, current));
                return;
            }

            openSet.Remove(current);

            foreach (Point neighbor in GetNeighbors(current))
            {
                if (_maze[neighbor.Y, neighbor.X] == 1)
                {
                    continue;
                }

                int tentativeGScore = gScore[current] + 1;
                if (tentativeGScore < gScore[neighbor])
                {
                    cameFrom[neighbor] = current;
                    gScore[neighbor] = tentativeGScore;
                    fScore[neighbor] = gScore[neighbor] + Heuristic(neighbor, _end);
                    if (!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                    }
                }
            }
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
                DrawPath(GetPathFromWave(wave, current));
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
    }

    private void DrawPath(List<Point> path)
    {
        foreach (Point point in path)
        {
            Graphics g = CreateGraphics();
            g.FillRectangle(Brushes.Cyan, point.X * CELLSIZE, point.Y * CELLSIZE, CELLSIZE, CELLSIZE);
        }
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
            if (neighbor.X >= 0 && neighbor.Y >= 0 &&
                neighbor.X < _maze.GetLength(1) && neighbor.Y < _maze.GetLength(0))
            {
                yield return neighbor;
            }
        }
    }

    private static int Heuristic(Point a, Point b)
    {
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }

    private static List<Point> ReconstructPath(Dictionary<Point, Point> cameFrom, Point current)
    {
        List<Point> totalPath = new() { current };
        while (cameFrom.TryGetValue(current, out Point next))
        {
            current = next;
            totalPath.Add(current);
        }
        totalPath.Reverse();
        return totalPath;
    }

    private List<Point> GetPathFromWave(int[,] wave, Point end)
    {
        List<Point> path = new();
        Point current = end;

        while (wave[current.Y, current.X] != 1)
        {
            path.Add(current);

            foreach (Point neighbor in GetNeighbors(current))
            {
                if (wave[neighbor.Y, neighbor.X] == wave[current.Y, current.X] - 1)
                {
                    current = neighbor;
                    break;
                }
            }
        }
        path.Add(_start);
        path.Reverse();
        return path;
    }
}
