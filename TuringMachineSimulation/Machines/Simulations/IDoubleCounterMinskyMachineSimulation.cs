using TuringMachineSimulation.Machines.Minsky;

namespace TuringMachineSimulation.Machines.Simulations;

public interface IDoubleCounterMinskyMachineSimulation : IMinskyMachineSimulation<DoubleCounterMinskyMachineCounterType>
{
    bool TryApplyOperation(MinskyMachineCounterOperationType operationType,
        DoubleCounterMinskyMachineCounterType counterType);
}