namespace TuringMachineSimulation.Math.SemiGroups;

public class MathLetter
{
    private const string _indexPrefix = @"_";
    private const string _powerPrefix = @"^";
    private const int _defaultPower = 0;
    
    public int Power { get;  set; }
    public string? Index { get; set; }
    
    public string Name { get; init; }

    public MathLetter(string name, int power = _defaultPower, string? index = default)
    {
        Name = name;
        Power = power;
        Index = index;
    }

    public bool IsNameEqualTo(MathLetter mathLetter)
    {
        return Name == mathLetter.Name && Index == mathLetter.Index;
    }
    
    public static bool operator == (MathLetter origin, MathLetter other)
    {
        return origin.Name == other.Name && origin.Index == other.Index && origin.Power == other.Power;
    }

    public static bool operator !=(MathLetter origin, MathLetter other)
    {
        return !(origin == other);
    }

    public override string ToString()
    {
        var indexView = Index != default ? $"{_indexPrefix}{Index}" : string.Empty;
        var powerView = Power != _defaultPower ? $"{_powerPrefix}{Power}" : string.Empty;
        return $"{Name}{indexView}{powerView}";
    }

    public static MathLetter operator *(MathLetter origin, MathLetter other)
    {
        origin.Power += other.Power;
        return origin;
    }

    public static MathLetter operator /(MathLetter origin, MathLetter other)
    {
        origin.Power -= other.Power;
        return origin;
    }
    
}