using System.Numerics;

namespace WinFormsApp1;

internal interface IDiagramCategory<TValue> where TValue : INumber<TValue>
{
    public string Name { get; set; }
    public TValue Value { get; set; }
    public Color Color { get; set; }
}
