using WinFormsApp1.Presentation.Common;

namespace WinFormsApp1.Presentation.Views;

public interface IMainView : IView
{
    event Action ChangeUsernameClickedButton;

    void SetUserInfo(string username, string password);
}
