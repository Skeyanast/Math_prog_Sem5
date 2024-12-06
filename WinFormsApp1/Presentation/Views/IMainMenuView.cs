using WinFormsApp1.Presentation.Common;

namespace WinFormsApp1.Presentation.Views;

public interface IMainMenuView : IView
{
    event Action? OnDemoModeClicked;
    event Action? OnGameModeClicked;

    int PlayingFieldSize { get; }

    void OnInvalidFieldSizeValue(string errorMessage);
}
