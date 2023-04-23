using System;
using System.Diagnostics;
using System.Linq;
using TuringMachineSimulation.Machines.Minsky.Operation;
using TuringMachineSimulation.Machines.Minsky.SemiGroup.DoubleCounter.Counter;
using TuringMachineSimulation.Machines.Simulations;

namespace TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Node;

public class ApplyCounterOperationExecutableMinskyMachine : AbstractExecutableMinskyMachine
{
    private readonly DoubleCounterMinskyMachineCounterType _counterType;
    private readonly MinskyMachineCounterOperationType _operationType;
    private readonly int _countAppliedOperation;
    
    public ApplyCounterOperationExecutableMinskyMachine(
        DoubleCounterMinskyMachineCounterType counterType,
        MinskyMachineCounterOperationType operationType,
        int countAppliedOperation = 1)
    {
        _counterType = counterType;
        _operationType = operationType;
        _countAppliedOperation = countAppliedOperation;
    }

    protected override void OnExecuted(IMinskyMachine<IDoubleCounterMinskyMachineSimulation> minskyMachine, Action onCompleted = default)
    {
        if (_countAppliedOperation == 0)
        {
            TryLaunchNextExecutables(minskyMachine);
            
            IsCompleted = true;
            return;
        }

        if (_operationType == MinskyMachineCounterOperationType.Decrement)
        {
            int a = 0;
        }
        
        for (var i = 0; i < _countAppliedOperation; i++)
        {
            if (_operationType == MinskyMachineCounterOperationType.Decrement &&
                minskyMachine.IsCounterEmpty(_counterType))
            {
                TryLaunchNextExecutables(minskyMachine);
                IsCompleted = true;
                return;
            }
            
            minskyMachine.ChangeCounter(_counterType, _operationType);
        }
        
        switch (_operationType)
        {
            case MinskyMachineCounterOperationType.Increment:
            case MinskyMachineCounterOperationType.Decrement when !NextExecutables.Any():
                IsCompleted = true;
                return;
        }
    }

    private bool TryLaunchNextExecutables(IMinskyMachine<IDoubleCounterMinskyMachineSimulation> minskyMachine)
    {
        foreach (var executable in NextExecutables)
        {
            if (executable is StopExecutableMinskyMachine2C)
                return true;

            executable.Execute(minskyMachine);
        }

        return NextExecutables.Any();
    }
}