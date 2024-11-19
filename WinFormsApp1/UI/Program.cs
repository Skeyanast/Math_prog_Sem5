using WinFormsApp1.DomainModel;
using WinFormsApp1.Presentation.Common;
using WinFormsApp1.Presentation.Presenters;
using WinFormsApp1.Presentation.Views;

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
            .RegisterView<ILoginView, LoginForm>()
            .RegisterView<IMainView, MainForm>()
            .RegisterView<IChangeUsernameView, ChangeUsernameForm>()
            .RegisterService<ILoginService, LoginService>()
            .RegisterInstance(new ApplicationContext());

        controller.Run<LoginPresenter>();
    }
}