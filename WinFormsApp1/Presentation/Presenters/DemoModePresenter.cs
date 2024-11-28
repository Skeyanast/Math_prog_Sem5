using WinFormsApp1.DomainModel;
using WinFormsApp1.Presentation.Common;
using WinFormsApp1.Presentation.Presenters.RunArguments;
using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.Presentation.Presenters;

public class DemoModePresenter : BasePresenter<IDemoModeView, DemoModePresenterRunArgs>
{
    private DefaultPlayingField2D _playingField;
    private int _currentShotNumber = 0;

    public DemoModePresenter(IDemoModeView view, IApplicationController controller)
        : base(view, controller)
    {
        View.OnPlayingFieldGridCellClicked += OnFieldCellClicked;
        View.OnPlaceShipsClicked += OpenShipPlacementModalWindow;
        View.OnToResultsClicked += GoToResultsWindow;
    }

    public override void Run(DemoModePresenterRunArgs args)
    {
        _playingField = new DefaultPlayingField2D(args.PlayingFieldSize);

        View.PlayingFieldGridSize = _playingField.Size;
        View.PlayingFieldHorizontalNaming = _playingField.HorizontalNaming
            .Select(c => c.ToString())
            .ToList();
        View.PlayingFieldVerticalNaming = _playingField.VerticalNaming
            .Select(c => c.ToString())
            .ToList();
        View.PlayingFieldGridCellStatuses = _playingField.CellStatuses;

        View.Show();

        UpdatePlayingField();
    }

    private void UpdatePlayingField()
    {
        View.PlayingFieldGridInvalidate();
    }

    private void OnFieldCellClicked(int row, int column)
    {
        _playingField.Shoot((row, column));
        View.PlayingFieldGridCellStatuses = _playingField.CellStatuses;
        UpdatePlayingField();

        _currentShotNumber++;
        View.SetShotsFired(_currentShotNumber);
        View.ShotsHistory.Add($"Shot {_currentShotNumber}: {_playingField.HorizontalNaming[column]}{_playingField.VerticalNaming[row]}");
        if (_playingField.AllShipsDestroyed)
        {
            View.FinishGame();
        }
    }

    private void OpenShipPlacementModalWindow()
    {
        Controller.Run<ShipPlacementPresenter, ShipPlacementPresenterRunArgs>(
            new ShipPlacementPresenterRunArgs(
                1,
                _playingField,
                (playerNumber, playingField) => _playingField = playingField)
            );
        UpdatePlayingField();
    }

    private void GoToResultsWindow()
    {
        Controller.Run<ResultsPresenter, ResultsPresenterRunArgs>(new ResultsPresenterRunArgs(1, _currentShotNumber));
        View.Close();
    }
}
