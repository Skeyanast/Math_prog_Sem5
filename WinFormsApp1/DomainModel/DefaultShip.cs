using System.ComponentModel;
using System.Configuration;

namespace WinFormsApp1.DomainModel;

public class DefaultShip : IShip
{
    private readonly List<(int row, int column)> _placedCells = new();
    private readonly List<(int row, int column)> _livingCells = new();

    public event Action<IReadOnlyList<(int row, int column)>>? Destroy;

    public required (int row, int column) BaseCoordinate { get; init; }
    public required ShipOrientation Orientation { get; init; }

    [IntegerValidator(MinValue = 0)]
    public required int Size { get; init; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IReadOnlyList<(int row, int column)> PlacedCells => _placedCells;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IReadOnlyList<(int row, int column)> LivingCells => _livingCells;

    private bool ShipAlive => _livingCells.Count > 0;

    public DefaultShip()
    {
        switch (Orientation)
        {
            case ShipOrientation.Horizontal:
                int baseColumn = BaseCoordinate.column;
                for (int column = baseColumn; column < baseColumn + Size; column++)
                {
                    _placedCells.Add((BaseCoordinate.row, column));
                }
                break;
            case ShipOrientation.Vertical:
                int baseRow = BaseCoordinate.row;
                for (int row = baseRow; row < baseRow + Size; row++)
                {
                    _placedCells.Add((row, BaseCoordinate.column));
                }
                break;
            default:
                throw new ArgumentException("Orientation must be Horizontal or Vertical");
        }

        _livingCells = _placedCells;
    }

    public void TakeHit((int row, int column) hitCoordinate)
    {
        if (!_livingCells.Contains(hitCoordinate))
        {
            return;
        }

        _livingCells.Remove(hitCoordinate);

        if (!ShipAlive)
        {
            Destroy?.Invoke(_placedCells);
        }
    }
}
