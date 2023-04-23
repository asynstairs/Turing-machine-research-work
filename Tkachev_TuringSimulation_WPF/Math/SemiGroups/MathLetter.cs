namespace TuringMachineSimulation.Math.SemiGroups;

public class MathLetter
{
    public int Power { get; set; }
    
    protected virtual string PowerPresentation => @"^{" + Power + @"}";
    
    private string IndexPresentation => @"_{" + Index + @"}";
    
    public string? Index { get; set; } = string.Empty;
    
    public string Name { get; init; }

    public MathLetter(string name, int power = 0, string? index = default)
    {
        Name = name;

        Power = power;
        
        Index = index is null ? string.Empty :  @"{" + index + @"}";
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
        return $"{Name}{IndexPresentation}{PowerPresentation}";
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