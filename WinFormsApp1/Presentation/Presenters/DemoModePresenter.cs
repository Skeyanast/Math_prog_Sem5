using WinFormsApp1.Presentation.Common;
using WinFormsApp1.Presentation.Presenters.RunArguments;
using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.Presentation.Presenters;

public class DemoModePresenter : BasePresenter<IDemoModeView, DemoModePresenterRunArgs>
{
    public DemoModePresenter(IDemoModeView view, IApplicationController controller)
        : base(view, controller)
    {
        throw new NotImplementedException();
    }

    public override void Run(DemoModePresenterRunArgs args)
    {
        throw new NotImplementedException();
    }
}
