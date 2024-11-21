namespace WinFormsApp1.DomainModel;

/// <summary>
/// Represents the functionality of a two-dimensional playing field.
/// </summary>
/// <typeparam name="TCell"></typeparam>
public interface IPlayingField2D<TCell>
    where TCell : class, IPlayingCell, new()
{
    IPlayingCell this[int row, int column] { get; set; }
    List<IShip> Ships { get; }
    List<char> HorizontalNaming { get; }
    List<int> VerticalNaming { get; }
    int Size { get; }
    int ShipsCount { get; }
    int MaxShipPoints { get; }
    int RemainingShipPoints { get; }
    bool AllShipsDestroyed { get; }

    ShipPlacementResult PlaceShip((int row, int column) baseCoordinate, ShipOrientation orientation, int size);
    bool Shoot((int row, int column) shootCoordinate);
}
