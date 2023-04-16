namespace TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Node;

public abstract class AbstractExecutableMinskyMachine
{
    protected Action? OnCompleted { get; private set; } = null;

    public void SetActionOnCompleted(Action onCompleted)
    {
        OnCompleted = onCompleted;
    }

    public void Execute()
    {
        OnExecuted();
        OnCompleted?.Invoke();
    }
    
    protected abstract void OnExecuted();
}