using TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Group;

namespace TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Extensions;

public static class MinskyMachineExecutionProgramExtensions
{
    public static ExecutionGroupMinskyMachine Then(this ExecutionGroupMinskyMachine group, AbstractExecutableMinskyMachine executable)
    {
        group.Add(executable);
        return group;
    }
}