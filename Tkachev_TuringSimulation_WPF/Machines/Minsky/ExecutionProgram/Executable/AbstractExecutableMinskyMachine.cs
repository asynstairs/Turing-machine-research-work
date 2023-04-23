using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using TuringMachineSimulation.Machines.Simulations;

namespace TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Node;

public abstract class AbstractExecutableMinskyMachine
{
    public bool IsCompleted { get; protected set; }
    public ICollection<AbstractExecutableMinskyMachine> NextExecutables { get; set; } 
        = new List<AbstractExecutableMinskyMachine>();
    

    public void Execute(IMinskyMachine<IDoubleCounterMinskyMachineSimulation> minskyMachine2C, Action onCompleted = default)
    {
        OnExecuted(minskyMachine2C);
        onCompleted?.Invoke();
    }
    
    protected abstract void OnExecuted(IMinskyMachine<IDoubleCounterMinskyMachineSimulation> minskyMachine2C, Action onCompleted = default);
}