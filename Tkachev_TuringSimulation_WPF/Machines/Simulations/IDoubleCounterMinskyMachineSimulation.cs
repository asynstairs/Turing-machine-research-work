using TuringMachineSimulation.Machines.Minsky;
using TuringMachineSimulation.Machines.Minsky.Operation;
using TuringMachineSimulation.Machines.Minsky.SemiGroup.DoubleCounter.Counter;

namespace TuringMachineSimulation.Machines.Simulations;

public interface IDoubleCounterMinskyMachineSimulation : 
    IMinskyMachineSimulation<DoubleCounterMinskyMachineCounterType>
{
    int GetCounterValue(DoubleCounterMinskyMachineCounterType counterType);
    
    void ApplyOperationOnCounter(MinskyMachineCounterOperationType operationType,
        DoubleCounterMinskyMachineCounterType counterType);

    void ChangeStateOrder(int order);

    bool IsCounterEmpty(DoubleCounterMinskyMachineCounterType counterType);
}