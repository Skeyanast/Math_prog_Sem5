namespace WinFormsApp1.DomainModel;

public class DefaultPlayingCell : IPlayingCell
{
    public CellStatus Status { get; private set; }

    public DefaultPlayingCell()
    {
        Status = CellStatus.Water;
    }

    public void PlaceShip()
    {
        Status = CellStatus.Ship;
    }

    public void Hit()
    {
        switch (Status)
        {
            case CellStatus.Ship:
                Status = CellStatus.Hit;
                break;
            case CellStatus.Water:
                Status = CellStatus.Miss;
                break;
        }
    }
}
