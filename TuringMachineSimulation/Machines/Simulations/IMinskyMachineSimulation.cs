using TuringMachineSimulation.Machines.Minsky;
using TuringMachineSimulation.Machines.Simulation;

namespace TuringMachineSimulation.Machines.Simulations;

public interface IMinskyMachineSimulation<in TCounterMinskyMachineType>: IMachineSimulation
{
    void ApplyOperationOnCounter(MinskyMachineCounterOperationType operationType, 
        TCounterMinskyMachineType counterType);
}