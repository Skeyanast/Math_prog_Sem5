using System.Collections.ObjectModel;
using WinFormsApp1.DomainModel;
using WinFormsApp1.Presentation.Common;

namespace WinFormsApp1.Presentation.Views;

public interface IDemoModeView : IView
{
    event Action<int, int>? OnPlayingFieldCellClicked;
    event Action? OnPlaceShipsClicked;
    event Action? OnToResultsClicked;

    int PlayingFieldGridSize { get; set; }
    IReadOnlyList<string> PlayingFieldHorizontalNaming { get; set; }
    IReadOnlyList<string> PlayingFieldVerticalNaming { get; set; }
    IReadOnlyList<IReadOnlyList<CellStatus>> PlayingFieldGridCellStatuses { get; set; }
    ObservableCollection<string> ShotsHistory { get; }

    void SetShotsFired(int number);
    void PlayingFieldGridInvalidate();
    void FinishGame();
}
