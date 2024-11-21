using WinFormsApp1.Presentation.Views;

namespace WinFormsApp1.UI;

public partial class ShipPlacementForm : Form, IShipPlacementView
{
    public event Action? AddShipClicked;
    public event Action? RemoveShipClicked;
    public event Action? CompletePlacementClicked;

    public int ShipBaseRow => throw new NotImplementedException();
    public int ShipBaseColumn => throw new NotImplementedException();
    public int ShipOrientation => throw new NotImplementedException();
    public int ShipSize => throw new NotImplementedException();
    public int ShipCreationPoints => throw new NotImplementedException();

    public ShipPlacementForm()
    {
        InitializeComponent();
    }

    public void OnInvalidShipCreationArguments()
    {
        throw new NotImplementedException();
    }

    public void OnLackOfPlacementPoints()
    {
        throw new NotImplementedException();
    }
}
