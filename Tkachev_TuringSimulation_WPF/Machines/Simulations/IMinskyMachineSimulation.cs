using TuringMachineSimulation.Machines.Minsky;
using TuringMachineSimulation.Machines.Minsky.Operation;

namespace TuringMachineSimulation.Machines.Simulations;

public interface IMinskyMachineSimulation<in TCounterMinskyMachineType>: IMachineSimulation
{
    void ApplyOperationOnCounter(MinskyMachineCounterOperationType operationType, 
        TCounterMinskyMachineType counterType);
}