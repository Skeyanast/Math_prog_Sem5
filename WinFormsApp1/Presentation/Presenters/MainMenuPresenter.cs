using WinFormsApp1.Presentation.Common;
using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.Presentation.Presenters;

public class MainMenuPresenter : BasePresenter<IMainMenuView>
{
    public MainMenuPresenter(IMainMenuView view, IApplicationController controller)
        : base(view, controller)
    {
        throw new NotImplementedException();
    }
}
