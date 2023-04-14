using TuringMachineSimulation.Machines.Minsky.Counter;
using TuringMachineSimulation.Math.SemiGroups;

namespace TuringMachineSimulation.Machines.Configs;

public class DoubleCounterMinskyMachineSemiGroupConfig : 
    IDoubleCounterMinskyMachineConfig<MinskyMachineSemiGroupCounter, MathLetter>
{
    public MinskyMachineSemiGroupCounter FirstCounter { get; } = new MinskyMachineSemiGroupCounter(new MathLetter("a", index: "1"));
    public MinskyMachineSemiGroupCounter SecondCounter { get; } = new MinskyMachineSemiGroupCounter(new MathLetter("a", index: "2"));
    public MathLetter FirstCounterEmptyState { get; } = new MathLetter("A", index: "1");
    public MathLetter SecondCounterEmptyState { get; } = new MathLetter("A", index: "2");
    public MathLetter CurrentConfigState { get; } = new MathLetter("q", index: "1");
    
    public void SetStateOrder(int order)
    {
        if (CurrentConfigState.Index == null)
            throw new NullReferenceException($"State order letter doesn't have an index!");

        CurrentConfigState.Index = order.ToString();
    }

    public string Get()
    {
        return
            $"{FirstCounterEmptyState} " +
            $"{FirstCounter.MathLetter} " +
            $"{CurrentConfigState} " +
            $"{SecondCounter.MathLetter} " +
            $"{SecondCounterEmptyState}";
    }
}