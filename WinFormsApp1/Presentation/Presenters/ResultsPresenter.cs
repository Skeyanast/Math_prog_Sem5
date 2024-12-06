using WinFormsApp1.Presentation.Common;
using WinFormsApp1.Presentation.Presenters.RunArguments;
using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.Presentation.Presenters;

public class ResultsPresenter : BasePresenter<IResultsView, ResultsPresenterRunArgs>
{
    public ResultsPresenter(IResultsView view, IApplicationController controller)
        : base(view, controller)
    {
        View.OnReturnToMainMenuClicked += OnReturnToMainMenuClicked;
    }

    public override void Run(ResultsPresenterRunArgs args)
    {
        View.WinPlayerNumber = args.WinPlayerNumber;
        View.ShotCount = args.ShotCount;
        View.SetResults();
        View.Show();
    }

    private void OnReturnToMainMenuClicked()
    {
        Controller.Run<MainMenuPresenter>();
        View.Close();
    }
}
