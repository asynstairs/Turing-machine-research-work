using System;
using TuringMachineSimulation.Math.SemiGroups;

namespace TuringMachineSimulation.Machines.Minsky.SemiGroup.DoubleCounter.Config.State;

public class ConfigStateSemiGroupMinskyMachine : MathLetter
{
    protected override string PowerPresentation => string.Empty;

    public ConfigStateSemiGroupMinskyMachine(string name, string? index = default)
        : base(name, 1, index)
    { }
}