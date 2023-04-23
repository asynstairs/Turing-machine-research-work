using System;
using TuringMachineSimulation.Machines.Minsky.SemiGroup.DoubleCounter.Counter;
using TuringMachineSimulation.Machines.Minsky.SemiGroup.EmptyState;
using TuringMachineSimulation.Math.SemiGroups;

namespace TuringMachineSimulation.Machines.Minsky.SemiGroup.DoubleCounter.Config;

public class DoubleCounterMinskyMachineSemiGroupConfig : 
    IDoubleCounterMinskyMachineConfig<MinskyMachineSemiGroupCounter, EmptyStateSemiGroupMinskyMachine, MathLetter>
{
    public MinskyMachineSemiGroupCounter FirstCounter { get; } = new MinskyMachineSemiGroupCounter(new MathLetter("a", index: "1"));
    public MinskyMachineSemiGroupCounter SecondCounter { get; } = new MinskyMachineSemiGroupCounter(new MathLetter("a", index: "2"));
    public EmptyStateSemiGroupMinskyMachine FirstCounterEmptyState { get; } = new (index: "1");
    public EmptyStateSemiGroupMinskyMachine SecondCounterEmptyState { get; } = new (index: "2");
    public MathLetter CurrentConfigState { get; } = new MathLetter("q", index: "1");

    public void SetEmptyStateEnabled(EmptyStateSemiGroupMinskyMachineType semiGroupMinskyMachineType, bool isEnabled)
    {
        switch (semiGroupMinskyMachineType)
        {
            case EmptyStateSemiGroupMinskyMachineType.First:
                FirstCounterEmptyState.SetEnabled(isEnabled);
                break;
            case EmptyStateSemiGroupMinskyMachineType.Second:
                SecondCounterEmptyState.SetEnabled(isEnabled);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(semiGroupMinskyMachineType), semiGroupMinskyMachineType, null);
        }
    }

    public void SetStateOrder(int order)
    {
        if (CurrentConfigState.Index == null)
            throw new NullReferenceException($"State order letter doesn't have an index!");

        CurrentConfigState.Index = order.ToString();
    }

    public string GetRepresentation()
    {
        const string delimiter = @" ";
        
        var firstEmptyStateRepresentation = FirstCounterEmptyState.IsEnabled ? $"{FirstCounterEmptyState}" : string.Empty;
        var secondEmptyStateRepresentation = SecondCounterEmptyState.IsEnabled ? $"{SecondCounterEmptyState}" : string.Empty;
        
        return
            $"{firstEmptyStateRepresentation}" + delimiter +
            $"{FirstCounter.MathLetter}" + delimiter +
            $"{CurrentConfigState}" + delimiter +
            $"{SecondCounter.MathLetter} " + delimiter +
            $"{secondEmptyStateRepresentation}";
    }
}