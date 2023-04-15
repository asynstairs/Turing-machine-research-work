using TuringMachineSimulation.Machines.Simulations;

namespace TuringMachineSimulation.Machines.Minsky.Parameters;

public struct ApplyDoubleCounterOperationExecutionNodeParameters : IExecutionNodeMinskyMachineParameters
{
    public DoubleCounterMinskyMachineCounterType CounterType { get; set; }
    public MinskyMachineCounterOperationType OperationType { get; set; }
    public IMinskyMachine<IDoubleCounterMinskyMachineSimulation> DoubleCounterMinskyMachine { get; set; }
}