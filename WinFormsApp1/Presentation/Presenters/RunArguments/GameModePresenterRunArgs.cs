using WinFormsApp1.Presentation.Common;

namespace WinFormsApp1.Presentation.Presenters.RunArguments;

public class GameModePresenterRunArgs : IRunPresenterArgs
{
    public int PlayingFieldSize { get; }

    public GameModePresenterRunArgs(int playingFieldSize)
    {
        PlayingFieldSize = playingFieldSize;
    }
}
