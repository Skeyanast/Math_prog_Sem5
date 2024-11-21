namespace WinFormsApp1.DomainModel;

public class DefaultPlayingField2D : IPlayingField2D
{
    private readonly List<List<IPlayingCell>> _grid = new();
    private readonly List<IShip> _ships = new();
    private readonly List<char> _horizontalNaming = new();
    private readonly List<int> _verticalNaming = new();

    public IPlayingCell this[int row, int column]
    {
        get
        {
            if (row >= 0 &&
                column >= 0 &&
                row < _grid.Count &&
                column < _grid[row].Count)
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
                _grid[row][column] = value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }

    public IReadOnlyList<IShip> Ships => _ships;
    public IReadOnlyList<char> HorizontalNaming => _horizontalNaming;
    public IReadOnlyList<int> VerticalNaming => _verticalNaming;

    public IReadOnlyList<(int row, int column)> AllPlacedCells
    {
        get
        {
            return _ships.SelectMany(s => s.PlacedCells).ToList();
        }
    }

    public int Size { get; }
    public int ShipsCount => _ships.Count;
    public bool AllShipsDestroyed => _ships.Count == 0;
    public int MaxShipPoints { get; }
    public int RemainingShipPoints { get; private set; }

    public DefaultPlayingField2D(int size)
    {
        Size = size;
        MaxShipPoints = (int)Math.Floor(Math.Pow(Size, 2) / 5);
        RemainingShipPoints = MaxShipPoints;

        for (int row = 0; row < Size; row++)
        {
            List<IPlayingCell> newRow = new List<IPlayingCell>();
            for (int column = 0; column < Size; column++)
            {
                newRow.Add(new DefaultPlayingCell());
            }
            _grid.Add(newRow);
        }

        _horizontalNaming = new List<char>(size);
        _verticalNaming = new List<int>(size);
        for (int i = 0; i < Size; i++)
        {
            _horizontalNaming.Add((char)('A' + i));
            _verticalNaming.Add(i + 1);
        }
    }

    public ShipPlacementResult PlaceShip((int row, int column) baseCoordinate, ShipOrientation orientation, int size)
    {
        DefaultShip newShip = new()
        {
            BaseCoordinate = baseCoordinate,
            Orientation = orientation,
            Size = size
        };

        ShipPlacementResult checkingConditionsResult = SatisfiesCreationConditions(newShip);
        if (checkingConditionsResult != ShipPlacementResult.Success)
        {
            return checkingConditionsResult;
        }

        _ships.Add(newShip);

        newShip.Destroy += OnShipDestroy;

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
            if (!ShipInFieldBounds(newShip))
            {
                return ShipPlacementResult.ShipOutOfFieldBounds;
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
            IShip hittedShip = _ships.First(ship => ship.PlacedCells.Contains(shootCoordinate));
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

    private bool CreationPointsEnough(int shipSize) => RemainingShipPoints >= shipSize;

    private bool ShipInFieldBounds(IShip ship)
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
        try
        {
            var _ = this[cell.row, cell.column];
            return true;
        }
        catch (IndexOutOfRangeException)
        {
            return false;
        }
    }

    private bool CollidedWithPlacedShips(IReadOnlyList<(int row, int column)> newShipPlacedCells)
    {
        return newShipPlacedCells.Intersect(AllPlacedCells).Any();
    }

    private bool WithinCollisionFreeZone(IReadOnlyList<(int row, int column)> newShipPlacedCells)
    {
        List<(int row, int column)> noCollisionsArea = new();
        foreach (IShip placedShip in _ships)
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

    private void OnShipDestroy(IReadOnlyList<(int row, int column)> shipPlacedCells)
    {
        List<(int row, int column)> shipOuterArea = new();
        (int row, int column) firstCell = shipPlacedCells[0];
        (int row, int column) lastCell = shipPlacedCells[^1];
        for (int row = firstCell.row - 1; row <= lastCell.row + 1; row++)
        {
            for (int column = firstCell.column - 1; column <= lastCell.column + 1; column++)
            {
                shipOuterArea.Add((row, column));
            }
        }
        shipOuterArea = shipOuterArea
            .Except(shipPlacedCells)
            .Where(CellInBounds)
            .ToList();

        foreach ((int row, int column) in shipOuterArea)
        {
            _grid[row][column].Hit();
        }
    }
}
