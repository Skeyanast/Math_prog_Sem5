namespace WinFormsApp1.DomainModel;

/// <summary>
/// Represents the functionality of a two-dimensional playing field.
/// </summary>
public interface IPlayingField2D
{
    IPlayingCell this[int row, int column] { get; set; }
    IReadOnlyList<IShip> Ships { get; }
    IReadOnlyList<char> HorizontalNaming { get; }
    IReadOnlyList<int> VerticalNaming { get; }
    IReadOnlyList<IReadOnlyList<CellStatus>> CellStatuses { get; }
    int Size { get; }
    int ShipsCount { get; }
    bool AllShipsDestroyed { get; }
    int MaxShipPoints { get; }
    int RemainingShipPoints { get; }

    ShipPlacementResult PlaceShip((int row, int column) baseCoordinate, ShipOrientation orientation, int size);
    bool Shoot((int row, int column) shootCoordinate);
}
