using WinFormsApp1.Presentation.Common;

namespace WinFormsApp1.Presentation.Views;

public interface IChangeUsernameView : IView
{
    event Action? SaveClicked;

    string Username { get; }
}