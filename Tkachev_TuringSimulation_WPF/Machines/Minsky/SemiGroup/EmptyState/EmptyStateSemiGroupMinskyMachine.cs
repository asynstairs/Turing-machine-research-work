using TuringMachineSimulation.Math.SemiGroups;

namespace TuringMachineSimulation.Machines.Minsky.SemiGroup.EmptyState;

public class EmptyStateSemiGroupMinskyMachine
{
    private MathLetter _mathLetterRepresentation;
    private readonly MathLetter _mathLetterIdentity;
    
    public bool IsEnabled => _mathLetterRepresentation.Power >= 1;

    public EmptyStateSemiGroupMinskyMachine(string index)
    {
        _mathLetterRepresentation = new MathLetter("A", index: index);
        _mathLetterIdentity = new MathLetter(_mathLetterRepresentation.Name, 1, _mathLetterRepresentation.Index);
    }

    public void SetEnabled(bool isEnabled)
    {
        if (IsEnabled == isEnabled)
            return;

        if (isEnabled)
            _mathLetterRepresentation *= _mathLetterIdentity;
        else
            _mathLetterRepresentation /= _mathLetterIdentity;
    }

    public override string ToString()
    {
        return $"{_mathLetterRepresentation.Name}_{_mathLetterRepresentation.Index}";
    }
}