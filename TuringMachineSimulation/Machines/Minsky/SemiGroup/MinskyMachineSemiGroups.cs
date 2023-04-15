using TuringMachineSimulation.Machines.Simulation;
using TuringMachineSimulation.Machines.Simulations;

namespace TuringMachineSimulation.Machines.Minsky;

public class MinskyMachineSemiGroups : IMinskyMachine<IDoubleCounterMinskyMachineSimulation>
{
    public IDoubleCounterMinskyMachineSimulation MainSimulation { get; set; } 
        = new DoubleCounterSemiGroupSimulationMinskyMachine();

    void IMinskyMachine<IDoubleCounterMinskyMachineSimulation>.ChangeConfigState(int stateOrder)
    {
        MainSimulation.ChangeStateOrder(stateOrder);
    }

    void IMinskyMachine<IDoubleCounterMinskyMachineSimulation>.ChangeCounter(DoubleCounterMinskyMachineCounterType counterType, 
        MinskyMachineCounterOperationType operationType)
    {
        MainSimulation.ApplyOperationOnCounter(operationType, counterType);
    }

    string IMachine<IDoubleCounterMinskyMachineSimulation>.GetConfigRepresentation()
    {
        return MainSimulation.GetConfigRepresentation();
    }
}