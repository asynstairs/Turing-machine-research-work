using TuringMachineSimulation.Machines.Minsky;

namespace TuringMachineSimulation.Machines.Simulations;

public interface IDoubleCounterMinskyMachineSimulation : 
    IMinskyMachineSimulation<DoubleCounterMinskyMachineCounterType>
{
    void ApplyOperationOnCounter(MinskyMachineCounterOperationType operationType,
        DoubleCounterMinskyMachineCounterType counterType);

    void ChangeStateOrder(int order);
}