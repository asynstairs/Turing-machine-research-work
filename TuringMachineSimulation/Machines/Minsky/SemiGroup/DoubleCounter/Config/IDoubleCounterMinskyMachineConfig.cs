namespace TuringMachineSimulation.Machines.Configs;

public interface IDoubleCounterMinskyMachineConfig<TCounter, TEmptyState, TConfigState> : IMachineConfig
{
    TCounter FirstCounter { get; }
    TCounter SecondCounter { get; }
    
    TEmptyState FirstCounterEmptyState { get; }
    TEmptyState SecondCounterEmptyState { get; }
    TConfigState CurrentConfigState { get; }

    void SetStateOrder(int order);
}