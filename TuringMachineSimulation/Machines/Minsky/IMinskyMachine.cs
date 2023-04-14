using TuringMachineSimulation.Machines.Minsky.Counter;
using TuringMachineSimulation.Machines.Simulation;

namespace TuringMachineSimulation.Machines.Minsky;

public interface IMinskyMachine<TMinskyMachineSimulation> : IMachine<TMinskyMachineSimulation>
    where TMinskyMachineSimulation : IMachineSimulation
{
    protected TMinskyMachineSimulation Simulation { get; set; }
}