namespace WinFormsApp1.DomainModel;

public class PlayingField2D<TCell> : IPlayingField2D<TCell>
    where TCell : class, IPlayingCell, new()
{
    private readonly List<List<TCell>> _grid;

    public IPlayingCell this[int row, int column]
    {
        get
        {
            if (row >= 0 && row < _grid.Count
                && column >= 0 && column < _grid[row].Count)
            {
                return _grid[row][column];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        set
        {
            if (row >= 0 && row < _grid.Count
                && column >= 0 && column < _grid[row].Count)
            {
                _grid[row][column] = (TCell)value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }

    public List<IShip> Ships { get; private set; } = new();

    public List<(int row, int column)> AllPlacedCells
    {
        get
        {
            return Ships.SelectMany(s => s.PlacedCells).ToList();
        }
    }

    public int ShipsCount => Ships.Count;

    public bool AllShipsDestroyed => Ships.Count == 0;

    public List<char> HorizontalNaming { get; init; }
    public List<int> VerticalNaming { get; init; }
    public int Size { get; init; }
    public int MaxShipPoints { get; init; }
    public int RemainingShipPoints { get; private set; }

    public PlayingField2D(int size)
    {
        Size = size;
        MaxShipPoints = (int)Math.Floor(Math.Pow(Size, 2) / 5);
        RemainingShipPoints = MaxShipPoints;

        _grid = new List<List<TCell>>();
        for (int row = 0; row < Size; row++)
        {
            List<TCell> newRow = new List<TCell>();
            for (int column = 0; column < Size; column++)
            {
                newRow.Add(new TCell());
            }
            _grid.Add(newRow);
        }

        HorizontalNaming = new List<char>(size);
        VerticalNaming = new List<int>(size);
        for (int i = 0; i < Size; i++)
        {
            HorizontalNaming.Add((char)('A' + i));
            VerticalNaming.Add(i + 1);
        }
    }

    public ShipPlacementResult PlaceShip((int row, int column) baseCoordinate, ShipOrientation orientation, int size)
    {
        IShip newShip = new DefaultShip(baseCoordinate, orientation, size);

        ShipPlacementResult checkingConditionsResult = SatisfiesCreationConditions(newShip);
        if (checkingConditionsResult != ShipPlacementResult.Success)
        {
            return checkingConditionsResult;
        }

        Ships.Add(newShip);
        foreach ((int row, int column) in newShip.PlacedCells)
        {
            _grid[row][column].PlaceShip();
        }
        RemainingShipPoints -= newShip.Size;

        return ShipPlacementResult.Success;

        ShipPlacementResult SatisfiesCreationConditions(IShip ship)
        {
            // Checking if has enough points for creation
            if (!CreationPointsEnough(newShip.Size))
            {
                return ShipPlacementResult.NotEnoughCreationPoints;
            }

            // Checking if all ship cells are within the field
            if (!ShipInBounds(newShip))
            {
                return ShipPlacementResult.ShipOutOfBounds;
            }

            // Checking if cells are collided with placed ship sells
            if (CollidedWithPlacedShips(newShip.PlacedCells))
            {
                return ShipPlacementResult.CollidedWithPlacedShips;
            }

            // Checking if the ship is in a collision-free zone
            if (WithinCollisionFreeZone(newShip.PlacedCells))
            {
                return ShipPlacementResult.WithinCollisionFreeZone;
            }

            // Continue the logic
            return ShipPlacementResult.Success;
        }
    }

    public bool Shoot((int row, int column) shootCoordinate)
    {
        if (AllPlacedCells.Contains(shootCoordinate))
        {
            IShip hittedShip = Ships.First(ship => ship.PlacedCells.Contains(shootCoordinate));
            hittedShip.TakeHit(shootCoordinate);
            _grid[shootCoordinate.row][shootCoordinate.column].Hit();
            return true;
        }
        else
        {
            _grid[shootCoordinate.row][shootCoordinate.column].Hit();
            return false;
        }
    }

    private bool CreationPointsEnough(int size) => RemainingShipPoints >= size;

    private bool ShipInBounds(IShip ship)
    {
        foreach ((int row, int column) placedCell in ship.PlacedCells)
        {
            if (!CellInBounds(placedCell))
            {
                return false;
            }
        }
        return true;
    }

    private bool CellInBounds((int row, int column) cell)
    {
        if (cell.row >= 0
            && cell.column >= 0
            && cell.row < Size
            && cell.column < Size)
        {
            return true;
        }
        return false;
    }

    private bool CollidedWithPlacedShips(List<(int row, int column)> newShipPlacedCells)
    {
        return newShipPlacedCells.Intersect(AllPlacedCells).Any();
    }

    private bool WithinCollisionFreeZone(List<(int row, int column)> newShipPlacedCells)
    {
        List<(int row, int column)> noCollisionsArea = new();
        foreach (IShip placedShip in Ships)
        {
            List<(int row, int column)> shipOuterArea = new();
            (int row, int column) firstCell = placedShip.PlacedCells[0];
            (int row, int column) lastCell = placedShip.PlacedCells[^1];
            for (int row = firstCell.row - 1; row <= lastCell.row + 1; row++)
            {
                for (int column = firstCell.column - 1; column <= lastCell.column + 1; column++)
                {
                    shipOuterArea.Add((row, column));
                }
            }
            shipOuterArea = shipOuterArea
                .Except(placedShip.PlacedCells)
                .Where(CellInBounds)
                .ToList();
            noCollisionsArea.Concat(shipOuterArea).ToList();
        }

        return newShipPlacedCells.Intersect(noCollisionsArea).Any();
    }
}
