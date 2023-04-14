using TuringMachineSimulation.Machines.Minsky;
using TuringMachineSimulation.Machines.Simulation;

namespace TuringMachineSimulation.Machines.Simulations;

public interface IMinskyMachineSimulation<TCounterMinskyMachineType>: IMachineSimulation
{
    bool TryApplyOperation(MinskyMachineCounterOperationType operationType, 
        TCounterMinskyMachineType counterType);
}