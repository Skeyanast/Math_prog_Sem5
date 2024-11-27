using WinFormsApp1.Presentation.Common;

namespace WinFormsApp1.Presentation.Presenters.RunArguments;

public class DemoModePresenterRunArgs : IRunPresenterArgs
{
    public int PlayingFieldSize { get; }

    public DemoModePresenterRunArgs(int playingFieldSize)
    {
        PlayingFieldSize = playingFieldSize;
    }
}
