using WinFormsApp1.Presentation.Common;
using WinFormsApp1.Presentation.Presenters.RunArguments;
using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.Presentation.Presenters;

public class ShipPlacementPresenter : BasePresenter<IShipPlacementView, ShipPlacementPresenterRunArgs>
{
    public ShipPlacementPresenter(IShipPlacementView view, IApplicationController controller)
        : base(view, controller)
    {
        throw new NotImplementedException();
    }

    public override void Run(ShipPlacementPresenterRunArgs args)
    {
        throw new NotImplementedException();
    }
}
