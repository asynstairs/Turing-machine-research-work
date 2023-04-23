using System.Text;
using TuringMachineSimulation.Machines.Minsky.Counter;
using TuringMachineSimulation.Machines.Minsky.Operation;
using TuringMachineSimulation.Machines.Minsky.SemiGroup.DoubleCounter.Counter;
using TuringMachineSimulation.Machines.Simulations;

namespace TuringMachineSimulation.Machines.Minsky;

public interface IMinskyMachine<TMinskyMachineSimulation> : IMachine<TMinskyMachineSimulation>
    where TMinskyMachineSimulation : IMachineSimulation
{
    public StringBuilder Configs { get; }
    
    protected TMinskyMachineSimulation MainSimulation { get; }

    int GetCounterValue(DoubleCounterMinskyMachineCounterType counterType);

    void ChangeConfigState(int stateOrder);

    void ChangeCounter(DoubleCounterMinskyMachineCounterType counterType,
        MinskyMachineCounterOperationType operationType);

    bool IsCounterEmpty(DoubleCounterMinskyMachineCounterType counterType);
}