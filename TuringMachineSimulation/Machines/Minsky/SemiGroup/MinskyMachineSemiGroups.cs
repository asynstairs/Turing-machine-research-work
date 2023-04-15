using TuringMachineSimulation.Machines.Simulation;
using TuringMachineSimulation.Machines.Simulations;

namespace TuringMachineSimulation.Machines.Minsky;

public class MinskyMachineSemiGroups : IMinskyMachine<IDoubleCounterMinskyMachineSimulation>
{
    public IDoubleCounterMinskyMachineSimulation MainSimulation { get; set; } 
        = new DoubleCounterSemiGroupSimulationMinskyMachine();

    public void ChangeConfigState(int stateOrder)
    {
        MainSimulation.ChangeStateOrder(stateOrder);
    }

    public void ChangeCounter(DoubleCounterMinskyMachineCounterType counterType, 
        MinskyMachineCounterOperationType operationType)
    {
        MainSimulation.ApplyOperationOnCounter(operationType, counterType);
    }

    public string GetConfigRepresentation()
    {
        return MainSimulation.GetConfigRepresentation();
    }
}