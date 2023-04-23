using System;
using TuringMachineSimulation.Machines.Simulations;

namespace TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Node;

public class StopExecutableMinskyMachine2C : AbstractExecutableMinskyMachine
{
    public StopExecutableMinskyMachine2C()
    { }

    protected override void OnExecuted(IMinskyMachine<IDoubleCounterMinskyMachineSimulation> minskyMachine2C, 
        Action onCompleted = default)
    { }
}