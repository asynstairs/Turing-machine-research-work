using TuringMachineSimulation.Machines.Simulations;

namespace TuringMachineSimulation.Machines;

public interface IMachine<TMachineSimulation>
    where TMachineSimulation : IMachineSimulation
{
    string GetConfigRepresentation();
}