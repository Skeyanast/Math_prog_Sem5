using WinFormsApp1.DomainModel;
using WinFormsApp1.Presentation.Common;

namespace WinFormsApp1.Presentation.Presenters;

public class MainPresenterRunArgs : IRunPresenterArgs
{
    public User User { get; }

    public MainPresenterRunArgs(User user)
    {
        User = user;
    }
}
