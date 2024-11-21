using WinFormsApp1.Presentation.Common;
using WinFormsApp1.Presentation.Presenters.RunArguments;
using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.Presentation.Presenters;

public class ResultsPresenter : BasePresenter<IResultsView, ResultsPresenterRunArgs>
{
    public ResultsPresenter(IResultsView view, IApplicationController controller)
        : base(view, controller)
    {
        throw new NotImplementedException();
    }

    public override void Run(ResultsPresenterRunArgs args)
    {
        throw new NotImplementedException();
    }
}
