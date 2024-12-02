namespace WinFormsApp1;

internal class DynamicObject
{
    private int _directionX;
    private int _directionY;

    public int X { get; private set; }
    public int Y { get; private set; }

    public DynamicObject(int x, int y, int initialDirection)
    {
        X = x;
        Y = y;
        _directionX = initialDirection == 1 ? 1 : 0;
        _directionY = initialDirection == 2 ? 1 : 0;
    }

    public void Move(int[,] maze, int columns, int rows, int playerX, int playerY)
    {
        int newX = X + _directionX;
        int newY = Y + _directionY;

        if (newX < 0 || newX >= columns ||
            newY < 0 || newY >= rows ||
            maze[newY, newX] == 1)
        {
            _directionX *= -1;
            _directionY *= -1;
            newX = X + _directionX;
            newY = Y + _directionY;
        }

        if (newX == playerX &&
            newY == playerY)
        {
            _directionX *= -1;
            _directionY *= -1;
            newX = X + _directionX;
            newY = Y + _directionY;
        }

        if (newX >= 0 && newX < columns &&
            newY >= 0 && newY < rows &&
            maze[newY, newX] == 0)
        {
            X = newX;
            Y = newY;
        }
    }
}
