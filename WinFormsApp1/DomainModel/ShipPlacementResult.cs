namespace WinFormsApp1.DomainModel;

/// <summary>
/// Represents the result of an attempt to place a
/// ship on the field. All except "Success" are failures.
/// </summary>
public enum ShipPlacementResult
{
    Success,
    NotEnoughCreationPoints,
    ShipOutOfFieldBounds,
    CollidedWithPlacedShips,
    WithinCollisionFreeZone
}
