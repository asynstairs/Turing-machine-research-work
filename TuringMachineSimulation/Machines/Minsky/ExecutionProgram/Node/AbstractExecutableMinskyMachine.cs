namespace TuringMachineSimulation.Machines.Minsky;

public abstract class AbstractExecutableMinskyMachine
{
    public void Execute()
    {
        Console.WriteLine($"Executing node: {GetType().Name}.");
        OnExecuted();
    }
    
    protected abstract void OnExecuted();
}