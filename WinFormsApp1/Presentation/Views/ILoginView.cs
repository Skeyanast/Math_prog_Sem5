using WinFormsApp1.Presentation.Common;

namespace WinFormsApp1.Presentation.Views;

public interface ILoginView : IView
{
    event Action? LoginClicked;

    string Username { get; }
    string Password { get; }

    void OnLoginError(string errorMessage);
}
