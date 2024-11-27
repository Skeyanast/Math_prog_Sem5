using WinFormsApp1.Presentation.Common;
using WinFormsApp1.Presentation.Presenters.RunArguments;
using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.Presentation.Presenters;

public class MainMenuPresenter : BasePresenter<IMainMenuView>
{
    private readonly int _playingFieldSizeMinValue = 4;
    private readonly int _playingFieldSizeMaxValue = 10;

    private delegate void ModeRunCommand(int playingFieldSize);

    public MainMenuPresenter(IMainMenuView view, IApplicationController controller)
        : base(view, controller)
    {

        View.DemoModeClicked += () => LoadMode(View.PlayingFieldSize, DemoModeRunCommand);
        View.GameModeClicked += () => LoadMode(View.PlayingFieldSize, GameModeRunCommand);
    }

    private void LoadMode(int playingFieldSize, ModeRunCommand runCommand)
    {
        if (ValidatePlayingFieldSize(playingFieldSize))
        {
            runCommand.Invoke(playingFieldSize);
            View.Close();
        }
        else
        {
            View.OnInvalidFieldSizeValue("Invalid size of playing field.");
        }
    }

    private void DemoModeRunCommand(int playingFieldSize)
    {
        Controller.Run<DemoModePresenter, DemoModePresenterRunArgs>(new DemoModePresenterRunArgs(playingFieldSize));
    }

    private void GameModeRunCommand(int playingFieldSize)
    {
        Controller.Run<GameModePresenter, GameModePresenterRunArgs>(new GameModePresenterRunArgs(playingFieldSize));
    }

    private bool ValidatePlayingFieldSize(int playingFieldSize)
    {
        return playingFieldSize >= _playingFieldSizeMinValue && playingFieldSize <= _playingFieldSizeMaxValue;
    }
}
