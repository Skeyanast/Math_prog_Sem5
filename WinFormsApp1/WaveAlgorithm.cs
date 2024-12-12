namespace WinFormsApp1;

internal static class WaveAlgorithm
{
    public static bool Run(int[,] maze, Point start, Point end, out List<Point> path)
    {
        int rows = maze.GetLength(0);
        int cols = maze.GetLength(1);
        int[,] wave = new int[rows, cols];
        Queue<Point> queue = new();

        wave[start.Y, start.X] = 1;
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            Point current = queue.Dequeue();

            if (current == end)
            {
                path = GetPathFromWave(wave, current, start);
                return true;
            }

            foreach (Point neighbor in GetNeighbors(current, rows, cols))
            {
                if (maze[neighbor.Y, neighbor.X] == (int)MazeCellStatus.Wall ||
                    wave[neighbor.Y, neighbor.X] != 0)
                {
                    continue;
                }

                wave[neighbor.Y, neighbor.X] = wave[current.Y, current.X] + GetStepCost(maze[neighbor.Y, neighbor.X]);
                queue.Enqueue(neighbor);
            }
        }

        path = new List<Point>();
        return false;
    }

    private static List<Point> GetPathFromWave(int[,] wave, Point end, Point start)
    {
        List<Point> path = new();
        Point current = end;

        while (current != start &&
            wave[current.Y, current.X] != 0)
        {
            path.Add(current);
            current = GetPreviousPoint(wave, current);
        }

        path.Add(start);
        path.Reverse();
        return path;
    }

    private static Point GetPreviousPoint(int[,] wave, Point current)
    {
        foreach (Point neightbor in GetNeighbors(current, wave.GetLength(0), wave.GetLength(1)))
        {
            if (wave[neightbor.Y, neightbor.X] == wave[current.Y, current.X] - 1)
            {
                return neightbor;
            }
        }
        return current;
    }

    private static int GetStepCost(int cellStatus) => cellStatus switch
    {
        (int)MazeCellStatus.SlowingObstacle => 2,
        (int)MazeCellStatus.DangerousObstacle => 0,
        _ => 1
    };

    private static IEnumerable<Point> GetNeighbors(Point current, int rows, int cols)
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
            if (PointInBounds(neighbor, rows, cols))
            {
                yield return neighbor;
            }
        }
    }

    private static bool PointInBounds(Point point, int rows, int cols)
    {
        return
            point.X >= 0 &&
            point.X < cols &&
            point.Y >= 0 &&
            point.Y < rows;
    }
}
