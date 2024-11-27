using WinFormsApp1.DomainModel;
using WinFormsApp1.Presentation.Common;

namespace WinFormsApp1.Presentation.Presenters.RunArguments;

public class ShipPlacementPresenterRunArgs : IRunPresenterArgs
{
    public int PlayerNumber { get; }
    public DefaultPlayingField2D PlayingField { get; }
    public Action<int, DefaultPlayingField2D> PlaceShipsCallback { get; }

    public ShipPlacementPresenterRunArgs(int playerNumber, DefaultPlayingField2D playingField, Action<int, DefaultPlayingField2D> placeShipsCallback)
    {
        PlayerNumber = playerNumber;
        PlayingField = playingField;
        PlaceShipsCallback = placeShipsCallback;
    }
}
