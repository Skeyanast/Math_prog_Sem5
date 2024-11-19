using WinFormsApp1.DomainModel;
using WinFormsApp1.Presentation.Common;
using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.Presentation.Presenters;

public class MainPresenter : BasePresenter<IMainView, MainPresenterRunArgs>
{
    private User _user;

    public MainPresenter(IMainView view, IApplicationController controller)
        : base(view, controller)
    {
        View.ChangeUsernameClickedButton += ChangeUsername;
    }

    public override void Run(MainPresenterRunArgs args)
    {
        _user = args.User;
        UpdateUserInfo();
        View.Show();
    }

    private void ChangeUsername()
    {
        Controller.Run<ChangeUsernamePresenter, ChangeUsernamePresenterRunArgs>(new ChangeUsernamePresenterRunArgs((username) => _user.Name = username));
        UpdateUserInfo();
    }

    private void UpdateUserInfo()
    {
        View.SetUserInfo(_user.Name, new string('*', _user.Password.Length));
    }
}
