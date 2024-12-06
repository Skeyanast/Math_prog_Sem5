using WinFormsApp1.DomainModel;
using WinFormsApp1.Presentation.Common;
using WinFormsApp1.Presentation.Presenters.RunArguments;
using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.Presentation.Presenters;

public class GameModePresenter : BasePresenter<IGameModeView, GameModePresenterRunArgs>
{
    private DefaultPlayingField2D _player1Field;
    private DefaultPlayingField2D _player2Field;
    private int _currentShotNumber = 1;
    private int _currentTurnPlayerNumber = 1;
    private int _winPlayerNumber;

    public GameModePresenter(IGameModeView view, IApplicationController controller)
        : base(view, controller)
    {
        View.OnPlayingFieldCellClicked += HandleFieldCellClicked;
        View.OnPlaceShipsClicked += OnPlaceShipsClicked;
        View.OnToResultsClicked += OnFinishGameClicked;
    }

    public override void Run(GameModePresenterRunArgs args)
    {
        _player1Field = new DefaultPlayingField2D(args.PlayingFieldSize);
        _player2Field = new DefaultPlayingField2D(args.PlayingFieldSize);

        View.PlayingFieldGridSize = _player1Field.Size;
        View.PlayingFieldHorizontalNaming = _player1Field.HorizontalNaming
            .Select(c => c.ToString())
            .ToList();
        View.PlayingFieldVerticalNaming = _player1Field.VerticalNaming
            .Select(c => c.ToString())
            .ToList();
        View.Player1FieldGridCellStatuses = _player1Field.CellStatuses;
        View.Player2FieldGridCellStatuses = _player2Field.CellStatuses;

        View.Show();

        UpdatePlayingField(1);
        UpdatePlayingField(2);
    }

    private void UpdatePlayingField(int fieldNumber)
    {
        View.PlayingFieldGridInvalidate(fieldNumber);
    }

    private void ChangeTurn(bool isHitted)
    {
        _currentShotNumber++;
        if (!isHitted)
        {
            _currentTurnPlayerNumber = (_currentTurnPlayerNumber % 2) + 1;
            View.SetActivePlayer(_currentTurnPlayerNumber);
        }
    }

    private void HandleFieldCellClicked(int row, int column, int fieldNumber)
    {
        DefaultPlayingField2D hittingField;
        bool isHitted;
        switch (fieldNumber)
        {
            case 1:
                hittingField = _player1Field;
                isHitted = hittingField.Shoot((row, column));
                View.Player1FieldGridCellStatuses = hittingField.CellStatuses;
                break;
            case 2:
                hittingField = _player2Field;
                isHitted = hittingField.Shoot((row, column));
                View.Player2FieldGridCellStatuses = hittingField.CellStatuses;
                break;
            default:
                throw new ArgumentException("Invalid field number.");
        }

        UpdatePlayingField(fieldNumber);

        View.SetShotsFired(_currentShotNumber);
        View.ShotsHistory.Add($"Player {_currentTurnPlayerNumber} - Shot {_currentShotNumber}: {hittingField.HorizontalNaming[column]}{hittingField.VerticalNaming[row]}; {(isHitted ? "Hit" : "Miss")}");

        if (hittingField.AllShipsDestroyed)
        {
            _winPlayerNumber = _currentTurnPlayerNumber;
            View.FinishGame();
            return;
        }

        ChangeTurn(isHitted);
    }

    private void OnPlaceShipsClicked(int fieldNumber)
    {
        DefaultPlayingField2D placingField = fieldNumber switch
        {
            1 => _player1Field,
            2 => _player2Field,
            _ => throw new ArgumentException("Invalid field number."),
        };
        Controller.Run<ShipPlacementPresenter, ShipPlacementPresenterRunArgs>(
            new ShipPlacementPresenterRunArgs(
                fieldNumber,
                placingField,
                (playerNumber, playerField) => placingField = playerField)
            );
        UpdatePlayingField(fieldNumber);
    }

    private void OnFinishGameClicked()
    {
        Controller.Run<ResultsPresenter, ResultsPresenterRunArgs>(new ResultsPresenterRunArgs(_winPlayerNumber, _currentShotNumber));
        View.Close();
    }
}
