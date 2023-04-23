namespace TuringMachineSimulation.Machines.Simulations;

public interface IMachineSimulation
{
    bool UseLog { get; }
    
    string GetConfigRepresentation();
}