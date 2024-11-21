namespace WinFormsApp1.DomainModel;

/// <summary>
/// Represents a simple cell of the playing field.
/// </summary>
public interface IPlayingCell
{
    CellStatus Status { get; }

    void PlaceShip();
    void Hit();
}
