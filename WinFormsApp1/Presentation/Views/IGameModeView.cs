using System.Collections.ObjectModel;
using WinFormsApp1.DomainModel;
using WinFormsApp1.Presentation.Common;

namespace WinFormsApp1.Presentation.Views;

public interface IGameModeView : IView
{
    event Action<int, int, int>? OnPlayingFieldCellClicked;
    event Action<int>? OnPlaceShipsClicked;
    event Action? OnToResultsClicked;

    int PlayingFieldGridSize { get; set; }
    IReadOnlyList<string> PlayingFieldHorizontalNaming { get; set; }
    IReadOnlyList<string> PlayingFieldVerticalNaming { get; set; }
    IReadOnlyList<IReadOnlyList<CellStatus>> Player1FieldGridCellStatuses { get; set; }
    IReadOnlyList<IReadOnlyList<CellStatus>> Player2FieldGridCellStatuses { get; set; }
    ObservableCollection<string> ShotsHistory { get; }

    void SetActivePlayer(int playerNumber);
    void SetShotsFired(int number);
    void PlayingFieldGridInvalidate(int fieldNumber);
    void FinishGame();
}
