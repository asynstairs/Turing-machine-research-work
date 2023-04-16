using System.Collections;
using TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Extensions;
using TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Node;

namespace TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Group;

public class ExecutionGroupMinskyMachine : AbstractExecutableMinskyMachine
{
    private readonly ICollection<AbstractExecutableMinskyMachine> _executables
        = new List<AbstractExecutableMinskyMachine>();

    public void Add(AbstractExecutableMinskyMachine executable)
    {
        _executables.Add(executable);
    }
    
    protected override void OnExecuted()
    {
        if (_executables.Count == 0)
            throw new NullReferenceException($"No executables added to the group!");
        
        foreach (var executable in _executables)
        {
            executable.OnComplete(OnCompleted).Execute();
        }
    }
}