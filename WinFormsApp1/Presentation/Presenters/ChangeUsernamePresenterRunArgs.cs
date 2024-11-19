using WinFormsApp1.Presentation.Common;

namespace WinFormsApp1.Presentation.Presenters;

public class ChangeUsernamePresenterRunArgs : IRunPresenterArgs
{
    public Action<string> ChangeUsernameCallback { get; }

    public ChangeUsernamePresenterRunArgs(Action<string> changeUsernameCallback)
    {
        ChangeUsernameCallback = changeUsernameCallback;
    }
}
