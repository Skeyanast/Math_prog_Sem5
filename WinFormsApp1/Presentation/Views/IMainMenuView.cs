using WinFormsApp1.Presentation.Common;

namespace WinFormsApp1.Presentation.Views;

public interface IMainMenuView : IView
{
    event Action? DemoModeClicked;
    event Action? GameModeClicked;

    int PlayingFieldSize { get; }

    void OnInvalidFieldSizeValue(string errorMessage);
}
