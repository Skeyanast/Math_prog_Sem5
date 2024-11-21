using WinFormsApp1.Presentation.Common;

namespace WinFormsApp1.Presentation.Views;

public interface IShipPlacementView : IView
{
    event Action? AddShipClicked;
    event Action? CompletePlacementClicked;

    int ShipBaseRow { get; }
    int ShipBaseColumn { get; }
    int ShipOrientation { get; }
    int ShipSize { get; }
    int ShipCreationPoints { get; }
    // Какая-то матричная структура поля
    // Список кораблей 

    /*
    /// Будет вызываться при недопустимых параметрах создания
    */
    void OnInvalidShipCreationArguments(); // Что-то передать в параметры

    /*
    /// Будет вызываться при недостаточных очках для создания
    */
    void OnLackOfPlacementPoints(); // Что-то передать в параметры
}
