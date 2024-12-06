using System.Collections.ObjectModel;
using WinFormsApp1.DomainModel;
using WinFormsApp1.Presentation.Common;

namespace WinFormsApp1.Presentation.Views;

public interface IShipPlacementView : IView
{
    event Action<int, int>? OnPlaceShipGridCellClicked;
    event Action? OnCompletePlacementClicked;

    int PlayingFieldGridSize { get; set; }
    IReadOnlyList<string> PlayingFieldHorizontalNaming { get; set; }
    IReadOnlyList<string> PlayingFieldVerticalNaming { get; set; }
    IReadOnlyList<IReadOnlyList<CellStatus>> PlayingFieldGridCellStatuses { get; set; }
    ObservableCollection<string> PlacedShips { get; }
    ShipOrientation ShipOrientation { get; }
    int ShipSize { get; }

    void PlacementFieldGridInvalidate();
    void ProcessShipCreationResult(ShipPlacementResult shipPlacementResult);
    void SetRemainingPlacementPoints(int remainingPoints, int maxPoints);
    void SetPlayerNumber(int playerNumber);
    void FinishPlacement();
}
