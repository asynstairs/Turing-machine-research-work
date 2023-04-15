using System.Collections;
using TuringMachineSimulation.Machines.Minsky.Parameters;

namespace TuringMachineSimulation.Machines.Minsky.ExecutionProgram;

public class MinskyMachineExecutionProgram
{
    private readonly ICollection<AbstractExecutableMinskyMachine> _nodes 
        = new List<AbstractExecutableMinskyMachine?>();

    public void Add(AbstractExecutableMinskyMachine node)
    {
        Console.WriteLine($"Added node: {node.GetType().Name}.");
        _nodes.Add(node);
    }

    public void Execute()
    {
        foreach (var node in _nodes)
        {
            Console.WriteLine($"Execute node: {node}");
            node.Execute();
        }
    }
}