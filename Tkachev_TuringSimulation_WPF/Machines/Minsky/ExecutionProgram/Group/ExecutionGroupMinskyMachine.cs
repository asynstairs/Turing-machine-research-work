using System;
using System.Collections.Generic;
using System.Linq;
using TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Node;
using TuringMachineSimulation.Machines.Simulations;

namespace TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Group;

public class ExecutionGroupMinskyMachine : AbstractExecutableMinskyMachine
{
    private readonly ICollection<AbstractExecutableMinskyMachine> _executables
        = new List<AbstractExecutableMinskyMachine>();

    public void Reset()
    {
        _executables.Clear();
        IsCompleted = false;
    }

    public void Add(AbstractExecutableMinskyMachine executable)
    {
        _executables.Add(executable);
    }

    protected override void OnExecuted(IMinskyMachine<IDoubleCounterMinskyMachineSimulation> minskyMachine2C, 
        Action onCompleted = default)
    {
        var isStopped = false;
        
        while (!isStopped && _executables.Count(e => !e.IsCompleted) > 0)
        {
            foreach (var executable in _executables)
            {
                if (executable is StopExecutableMinskyMachine2C)
                {
                    isStopped = true;
                    break;
                }

                if (_executables.Count(e => !e.IsCompleted) == 0)
                    break;

                executable.Execute(minskyMachine2C);
            }
        }

        IsCompleted = true;
    }
}