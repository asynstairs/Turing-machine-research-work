namespace TuringMachineSimulation.Machines.Configs;

public interface IDoubleCounterMinskyMachineConfig<TCounter, TState> : IMachineConfig
{
    TCounter FirstCounter { get; }
    TCounter SecondCounter { get; }
    
    TState FirstCounterEmptyState { get; }
    TState SecondCounterEmptyState { get; }
    TState CurrentConfigState { get; }

    void SetStateOrder(int order);
}