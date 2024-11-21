using WinFormsApp1.Presentation.Common;
using WinFormsApp1.Presentation.Presenters.RunArguments;
using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.Presentation.Presenters;

public class GameModePresenter : BasePresenter<IGameModeView, GameModePresenterRunArgs>
{
    public GameModePresenter(IGameModeView view, IApplicationController controller)
        : base(view, controller)
    {
        throw new NotImplementedException();
    }

    public override void Run(GameModePresenterRunArgs args)
    {
        throw new NotImplementedException();
    }
}
