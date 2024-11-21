using WinFormsApp1.Presentation.Common;

namespace WinFormsApp1.Presentation.Views;

public interface IGameModeView : IView
{
    event Action<int>? OnFieldCellClicked;
    event Action<int>? OnPlaceShipsClicked;
    event Action? OnFinishGameClicked;

    // Какая-то матричная структура поля 1
    // Какая-то матричная структура поля 2
    // Список ходов для истории
}
