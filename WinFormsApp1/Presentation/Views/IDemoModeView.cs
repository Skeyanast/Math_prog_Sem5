using WinFormsApp1.Presentation.Common;

namespace WinFormsApp1.Presentation.Views;

public interface IDemoModeView : IView
{
    event Action? OnFieldCellClicked;
    event Action? OnPlaceShipsClicked;
    event Action? OnFinishGameClicked;

    // Какая-то матричная структура поля
    // Список ходов для истории

}
