using TuringMachineSimulation.Machines.Minsky.Operation;

namespace TuringMachineSimulation.Machines.Minsky.Counter;

public interface IMinskyMachineCounter
{
    public int Value { get; }

    bool TryApplyOperation(MinskyMachineCounterOperationType operationType);
}