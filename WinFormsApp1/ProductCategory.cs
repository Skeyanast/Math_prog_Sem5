using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace WinFormsApp1;

internal class ProductCategory<TValue> : IDiagramCategory<TValue> where TValue : INumber<TValue>
{
    [StringLength(100, MinimumLength = 2)]
    public required string Name { get; set; }

    [IntegerValidator(MinValue = 0)]
    public required TValue Value { get; set; }

    public required Color Color { get; set; }

    public ProductCategory() { }

    [SetsRequiredMembers]
    public ProductCategory(string name, TValue value, Color color)
    {
        Name = name;
        Value = value;
        Color = color;
    }
}
