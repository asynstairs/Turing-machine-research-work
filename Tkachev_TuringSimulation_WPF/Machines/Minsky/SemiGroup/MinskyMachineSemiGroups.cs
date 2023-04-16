using TuringMachineSimulation.Machines.Minsky.Operation;
using TuringMachineSimulation.Machines.Minsky.SemiGroup.DoubleCounter.Counter;
using TuringMachineSimulation.Machines.Minsky.SemiGroup.DoubleCounter.Simulation;
using TuringMachineSimulation.Machines.Simulations;

namespace TuringMachineSimulation.Machines.Minsky.SemiGroup;

public class MinskyMachineSemiGroups : IMinskyMachine<IDoubleCounterMinskyMachineSimulation>
{
    public IDoubleCounterMinskyMachineSimulation MainSimulation { get; set; } 
        = new DoubleCounterSemiGroupSimulationMinskyMachine();

    int IMinskyMachine<IDoubleCounterMinskyMachineSimulation>.GetCounterValue(DoubleCounterMinskyMachineCounterType counterType)
    {
        return MainSimulation.GetCounterValue(counterType);
    }

    void IMinskyMachine<IDoubleCounterMinskyMachineSimulation>.ChangeConfigState(int stateOrder)
    {
        MainSimulation.ChangeStateOrder(stateOrder);
    }

    void IMinskyMachine<IDoubleCounterMinskyMachineSimulation>.ChangeCounter(DoubleCounterMinskyMachineCounterType counterType, 
        MinskyMachineCounterOperationType operationType)
    {
        MainSimulation.ApplyOperationOnCounter(operationType, counterType);
    }

    bool IMinskyMachine<IDoubleCounterMinskyMachineSimulation>.IsCounterEmpty(DoubleCounterMinskyMachineCounterType counterType)
    {
        return MainSimulation.IsCounterEmpty(counterType);
    }

    string IMachine<IDoubleCounterMinskyMachineSimulation>.GetConfigRepresentation()
    {
        return MainSimulation.GetConfigRepresentation();
    }
}