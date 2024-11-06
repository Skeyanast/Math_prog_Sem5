using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace WinFormsApp1;

internal class Planet
{
    [StringLength(100, MinimumLength = 2)]
    public required string Name { get; set; }

    public required float Angle { get; set; }

    public required float Speed { get; set; }

    [IntegerValidator(MinValue = 0)]
    public required float PlanetRadius { get; init; }

    [IntegerValidator(MinValue = 0)]
    public required float OrbitRadius { get; init; }

    public Planet() { }

    [SetsRequiredMembers]
    public Planet(string name, float angle, float speed, float planetRadius, float orbitRadius)
    {
        Name = name;
        Angle = angle;
        Speed = speed;
        PlanetRadius = planetRadius;
        OrbitRadius = orbitRadius;
    }
}