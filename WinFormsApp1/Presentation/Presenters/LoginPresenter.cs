using WinFormsApp1.DomainModel;
using WinFormsApp1.Presentation.Common;
using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.Presentation.Presenters;

public class LoginPresenter : BasePresenter<ILoginView>
{
    private readonly ILoginService _service;

    public LoginPresenter(ILoginView view, ILoginService service, IApplicationController controller)
        : base(view, controller)
    {
        _service = service;

        View.LoginClicked += () => ProcessLogin(View.Username, View.Password);
    }

    private void ProcessLogin(string username, string password)
    {
        ArgumentNullException.ThrowIfNull(username);
        ArgumentNullException.ThrowIfNull(password);

        User user = new() { Name = username, Password = password };

        if (!_service.Login(user))
        {
            View.OnLoginError("Invalid username or password");
        }
        else
        {
            Controller.Run<MainPresenter, MainPresenterRunArgs>(new MainPresenterRunArgs(user));
            View.Close();
        }
    }
}
