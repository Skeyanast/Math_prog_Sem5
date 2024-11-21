namespace WinFormsApp1.DomainModel;

/// <summary>
/// Represents the functionality of the game ship.
/// </summary>
public interface IShip
{
    event Action<IReadOnlyList<(int row, int column)>>? Destroy;

    (int row, int column) BaseCoordinate { get; }
    ShipOrientation Orientation { get; }
    int Size { get; }
    IReadOnlyList<(int row, int column)> PlacedCells { get; }
    IReadOnlyList<(int row, int column)> LivingCells { get; }

    void TakeHit((int row, int column) hitCoordinate);
}