using TuringMachineSimulation.Machines.Minsky.Parameters;
using TuringMachineSimulation.Machines.Simulations;

namespace TuringMachineSimulation.Machines.Minsky;

public class ApplyCounterOperationExecutableMinskyMachine : AbstractExecutableMinskyMachine
{
    private readonly DoubleCounterMinskyMachineCounterType _counterType;
    private readonly MinskyMachineCounterOperationType _operationType;
    private readonly IMinskyMachine<IDoubleCounterMinskyMachineSimulation> _doubleCounterMinskyMachine;
    private readonly int _countAppliedOperation;
    
    public ApplyCounterOperationExecutableMinskyMachine(
        DoubleCounterMinskyMachineCounterType counterType,
        MinskyMachineCounterOperationType operationType,
        IMinskyMachine<IDoubleCounterMinskyMachineSimulation> doubleCounterMinskyMachine,
        int countAppliedOperation = 1)
    {
        _counterType = counterType;
        _operationType = operationType;
        _countAppliedOperation = countAppliedOperation;
        _doubleCounterMinskyMachine = doubleCounterMinskyMachine;
    }

    protected override void OnExecuted()
    {
        for (int i = 0; i < _countAppliedOperation; i++)
        {
            _doubleCounterMinskyMachine.ChangeCounter(_counterType, _operationType);
        }
    }
}