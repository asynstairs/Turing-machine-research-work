using System.Diagnostics;
using TuringMachineSimulation.Machines.Minsky.Operation;
using TuringMachineSimulation.Machines.Minsky.SemiGroup.DoubleCounter.Counter;
using TuringMachineSimulation.Machines.Simulations;

namespace TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Node;

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

        LogAlso = $"OpType: {operationType}, CType: {counterType}, Val: {doubleCounterMinskyMachine.GetCounterValue(counterType)}";
    }

    protected override void OnExecuted()
    {
        for (int i = 0; i < _countAppliedOperation; i++)
        {
            if (_operationType == MinskyMachineCounterOperationType.Decrement &&
                _doubleCounterMinskyMachine.IsCounterEmpty(_counterType))
            {
                if (NextExecutables != null)
                {
                    foreach (var executable in NextExecutables)
                    {
                        if (executable is StopExecutableMinskyMachine2C)
                            break;
                        
                        executable.Execute();
                    }
                }

                IsCompleted = true;
                return;
            }

            if (_operationType == MinskyMachineCounterOperationType.Increment || NextExecutables == null)
            {
                IsCompleted = true;
            }
                
            _doubleCounterMinskyMachine.ChangeCounter(_counterType, _operationType);
        }
    }
}