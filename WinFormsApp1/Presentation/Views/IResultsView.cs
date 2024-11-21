using WinFormsApp1.Presentation.Common;

namespace WinFormsApp1.Presentation.Views;

public interface IResultsView : IView
{
    event Action? OnReturnToMainMenuClicked;
}
