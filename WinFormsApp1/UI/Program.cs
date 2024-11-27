using WinFormsApp1.DomainModel;
using WinFormsApp1.Presentation.Common;
using WinFormsApp1.Presentation.Views;
using WinFormsApp1.Presentation.Presenters;

namespace WinFormsApp1.UI;

internal static class Program
{
    public static readonly ApplicationContext Context = new();

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        
        IApplicationController controller = new ApplicationController(new LightInjectAdapter())
            .RegisterView<IMainMenuView, MainMenuForm>()
            .RegisterView<IDemoModeView, DemoModeForm>()
            .RegisterView<IGameModeView, GameModeForm>()
            .RegisterView<IShipPlacementView, ShipPlacementForm>()
            .RegisterView<IResultsView, ResultsForm>()
            .RegisterInstance(new ApplicationContext());

        controller.Run<MainMenuPresenter>();
    }
}