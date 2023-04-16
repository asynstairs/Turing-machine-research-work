using System;
using TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Group;
using TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Node;

namespace TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Extensions;

public static class MinskyMachineExecutionProgramExtensions
{
    public static ExecutionGroupMinskyMachine Then(this ExecutionGroupMinskyMachine group, AbstractExecutableMinskyMachine executable)
    {
        group.Add(executable);
        return group;
    }
    
    public static AbstractExecutableMinskyMachine With(this AbstractExecutableMinskyMachine executable,
        AbstractExecutableMinskyMachine targetExecutable)
    {
        executable.NextExecutables.Add(targetExecutable);
        return executable;
    }
}