using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Extensions;
using TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Node;

namespace TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Group;

public class ExecutionGroupMinskyMachine : AbstractExecutableMinskyMachine
{
    private readonly ICollection<AbstractExecutableMinskyMachine> _executables
        = new List<AbstractExecutableMinskyMachine>();

    public void Clear()
    {
        _executables.Clear();
    }
    
    public void Add(AbstractExecutableMinskyMachine executable)
    {
        _executables.Add(executable);
    }
    
    protected override void OnExecuted()
    {
        var isStopped = false;
        
        do
        {
            foreach (var executable in _executables)
            {
                if (executable is StopExecutableMinskyMachine2C)
                {
                    isStopped = true;
                    break;
                }
                
                executable.Execute();
            }
        } while (!isStopped && _executables.Count(e => !e.IsCompleted) > 0);

        IsCompleted = true;
    }
}