using TuringMachineSimulation.Machines.Minsky.Counter;
using TuringMachineSimulation.Machines.Simulation;

namespace TuringMachineSimulation.Machines.Minsky;

public interface IMinskyMachine<TMinskyMachineSimulation> : IMachine<TMinskyMachineSimulation>
    where TMinskyMachineSimulation : IMachineSimulation
{
    protected TMinskyMachineSimulation MainSimulation { get; set; }

    void ChangeConfigState(int stateOrder);

    void ChangeCounter(DoubleCounterMinskyMachineCounterType counterType,
        MinskyMachineCounterOperationType operationType);
}