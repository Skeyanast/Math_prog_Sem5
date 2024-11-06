using System.Collections.ObjectModel;

namespace WinFormsApp1;

internal class PieDiagram
{
    private string _name;
    private ObservableCollection<IDiagramCategory<int>> _data;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public ObservableCollection<IDiagramCategory<int>> Data
    {
        get => _data;
        set => _data = value;
    }

    public ObservableCollection<float> RelativeData
    {
        get
        {
            var relatives = Data.Select(CalculateRelativeData).ToList();
            return new ObservableCollection<float>(relatives);
        }
    }

    public int Total
    {
        get => Data.Sum(category => category.Value);
    }

    public PieDiagram(string name, ObservableCollection<IDiagramCategory<int>> productCategoriesData)
    {
        _name = name;
        _data = productCategoriesData;
    }

    public float CalculateRelativeData(IDiagramCategory<int> category)
    {
        if (Total == 0)
        {
            return 0;
        }

        float relativeData = category.Value / (float)Total;
        return relativeData;
    }
}
