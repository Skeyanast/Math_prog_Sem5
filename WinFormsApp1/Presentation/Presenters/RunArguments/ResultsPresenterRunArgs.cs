using WinFormsApp1.Presentation.Common;

namespace WinFormsApp1.Presentation.Presenters.RunArguments;

public class ResultsPresenterRunArgs : IRunPresenterArgs
{
    public int WinPlayerNumber { get; }
    public int ShotCount { get; }

    public ResultsPresenterRunArgs(int winPlayerNumber, int shotCount)
    {
        WinPlayerNumber = winPlayerNumber;
        ShotCount = shotCount;
    }
}
