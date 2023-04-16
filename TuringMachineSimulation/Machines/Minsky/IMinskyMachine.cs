using TuringMachineSimulation.Machines.Minsky.Counter;
using TuringMachineSimulation.Machines.Minsky.Operation;
using TuringMachineSimulation.Machines.Minsky.SemiGroup.DoubleCounter.Counter;
using TuringMachineSimulation.Machines.Simulations;

namespace TuringMachineSimulation.Machines.Minsky;

public interface IMinskyMachine<TMinskyMachineSimulation> : IMachine<TMinskyMachineSimulation>
    where TMinskyMachineSimulation : IMachineSimulation
{
    protected TMinskyMachineSimulation MainSimulation { get; set; }

    void ChangeConfigState(int stateOrder);

    void ChangeCounter(DoubleCounterMinskyMachineCounterType counterType,
        MinskyMachineCounterOperationType operationType);
}