using WinFormsApp1.DomainModel;
using WinFormsApp1.Presentation.Common;

namespace WinFormsApp1.Presentation.Views;

public interface IGameModeView : IView
{
    event Action<int, int>? OnPlayingFieldGridCellClicked;
    event Action? OnPlaceShipsClicked;
    event Action? OnFinishGameClicked;

    int PlayingFieldGridSize { get; set; }
    List<string> ShootsHistory { get; set; }

    // double that props mb
    List<string> PlayingFieldHorizontalNaming { get; set; }
    List<string> PlayingFieldVerticalNaming { get; set; }
    IReadOnlyList<IReadOnlyList<CellStatus>> PlayingFieldGridCellStatuses { get; set; }


    void PlayingFieldGridInvalidate();
}
