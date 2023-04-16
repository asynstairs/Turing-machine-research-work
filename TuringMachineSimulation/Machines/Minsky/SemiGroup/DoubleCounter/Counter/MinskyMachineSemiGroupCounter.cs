using TuringMachineSimulation.Machines.Minsky.Counter;
using TuringMachineSimulation.Machines.Minsky.Operation;
using TuringMachineSimulation.Math.SemiGroups;

namespace TuringMachineSimulation.Machines.Minsky.SemiGroup.DoubleCounter.Counter;

public class MinskyMachineSemiGroupCounter : IMinskyMachineCounter
{
    private readonly MathLetter _mathLetterIdentity;
    
    public MathLetter MathLetter { get; private set; }

    public MinskyMachineSemiGroupCounter(MathLetter mathLetter)
    {
        MathLetter = mathLetter;
        _mathLetterIdentity = new MathLetter(MathLetter.Name, 1, MathLetter.Index);
    }

    public int Value
    {
        get => MathLetter.Power;
    }

    public bool TryApplyOperation(MinskyMachineCounterOperationType operationType)
    {
        switch (operationType)
        {
            case MinskyMachineCounterOperationType.Increment:
                MathLetter *= _mathLetterIdentity;
                return true;
            case MinskyMachineCounterOperationType.Decrement:
                if (MathLetter.Power == 0)
                    return false;
                MathLetter /= _mathLetterIdentity;
                return true;
            default:
                throw new ArgumentOutOfRangeException(nameof(operationType), operationType, null);
        }
    }
}