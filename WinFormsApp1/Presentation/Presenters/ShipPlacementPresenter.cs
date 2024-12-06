using WinFormsApp1.DomainModel;
using WinFormsApp1.Presentation.Common;
using WinFormsApp1.Presentation.Presenters.RunArguments;
using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.Presentation.Presenters;

public class ShipPlacementPresenter : BasePresenter<IShipPlacementView, ShipPlacementPresenterRunArgs>
{
    private int _playerNumber;
    private DefaultPlayingField2D _playingField;
    private Action<int, DefaultPlayingField2D> _placeShipsCallback;
    private int _currentShipPlaced = 0;

    public ShipPlacementPresenter(IShipPlacementView view, IApplicationController controller)
        : base(view, controller)
    {
        View.OnPlaceShipGridCellClicked += HandlePlaceShipOnGridCell;
        View.OnCompletePlacementClicked += OnCompletePlacementClicked;
    }

    public override void Run(ShipPlacementPresenterRunArgs args)
    {
        _playerNumber = args.PlayerNumber;
        _playingField = args.PlayingField;
        _placeShipsCallback = args.PlaceShipsCallback;

        View.PlayingFieldGridSize = _playingField.Size;
        View.PlayingFieldHorizontalNaming = _playingField.HorizontalNaming
            .Select(c => c.ToString())
            .ToList();
        View.PlayingFieldVerticalNaming = _playingField.VerticalNaming
            .Select(c => c.ToString())
            .ToList();
        View.PlayingFieldGridCellStatuses = _playingField.CellStatuses;
        View.SetRemainingPlacementPoints(_playingField.RemainingShipPoints, _playingField.MaxShipPoints);
        View.SetPlayerNumber(_playerNumber);

        UpdatePlayingField();

        View.Show();
    }

    private void UpdatePlayingField()
    {
        View.PlacementFieldGridInvalidate();
    }

    private void HandlePlaceShipOnGridCell(int row, int column)
    {
        ShipPlacementResult shipPlacementResult = _playingField.PlaceShip((row, column), View.ShipOrientation, View.ShipSize);
        View.ProcessShipCreationResult(shipPlacementResult);
        if (shipPlacementResult == ShipPlacementResult.Success)
        {
            _currentShipPlaced++;
            View.PlayingFieldGridCellStatuses = _playingField.CellStatuses;
            UpdatePlayingField();

            View.SetRemainingPlacementPoints(_playingField.RemainingShipPoints, _playingField.MaxShipPoints);
            View.PlacedShips.Add($"{_currentShipPlaced}: {_playingField.HorizontalNaming[column]}{_playingField.VerticalNaming[row]}; {View.ShipOrientation}; {View.ShipSize}");
            if (_playingField.RemainingShipPoints == 0)
            {
                View.FinishPlacement();
            }
        }
    }

    private void OnCompletePlacementClicked()
    {
        _placeShipsCallback?.Invoke(_playerNumber, _playingField);
        View.Close();
    }
}
