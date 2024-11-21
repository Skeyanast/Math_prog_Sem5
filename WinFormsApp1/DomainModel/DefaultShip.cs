namespace WinFormsApp1.DomainModel;

public class DefaultShip : IShip
{
    private List<(int row, int column)> _placedCells = new();
    private List<(int row, int column)> _livingCells = new();

    public event Action<List<(int row, int column)>>? Destroy;

    public (int row, int column) BaseCoordinate { get; }
    public ShipOrientation Orientation { get; }
    public int Size { get; }

    public List<(int row, int column)> PlacedCells
    {
        get => _placedCells;
        private init => _placedCells = value;
    }

    public List<(int row, int column)> LivingCells
    {
        get => _livingCells;
        private init => _livingCells = value;
    }

    private bool ShipAlive => LivingCells.Count > 0;

    public DefaultShip((int row, int column) baseCoordinate, ShipOrientation orientation, int size)
    {
        BaseCoordinate = baseCoordinate;
        Orientation = orientation;
        Size = size;

        switch (orientation)
        {
            case ShipOrientation.Horizontal:
                int baseColumn = baseCoordinate.column;
                for (int column = baseColumn; column < baseColumn + size; column++)
                {
                    PlacedCells.Add((baseCoordinate.row, column));
                }
                break;
            case ShipOrientation.Vertical:
                int baseRow = baseCoordinate.row;
                for (int row = baseRow; row < baseRow + size; row++)
                {
                    PlacedCells.Add((row, baseCoordinate.column));
                }
                break;
            default:
                throw new ArgumentException("Orientation must be Horizontal or Vertical");
        }

        LivingCells = PlacedCells;
    }

    public void TakeHit((int row, int column) hitCoordinate)
    {
        if (!LivingCells.Contains(hitCoordinate))
        {
            return;
        }

        LivingCells.Remove(hitCoordinate);

        if (!ShipAlive)
        {
            Destroy?.Invoke(PlacedCells);
        }
    }
}
