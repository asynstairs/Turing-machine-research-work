using TuringMachineSimulation.Machines.Minsky.Operation;
using TuringMachineSimulation.Machines.Minsky.SemiGroup.DoubleCounter.Counter;
using TuringMachineSimulation.Machines.Simulations;

namespace TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Node.Parameters;

public struct ApplyDoubleCounterOperationExecutionNodeParameters : IExecutionNodeMinskyMachineParameters
{
    public DoubleCounterMinskyMachineCounterType CounterType { get; set; }
    public MinskyMachineCounterOperationType OperationType { get; set; }
    public IMinskyMachine<IDoubleCounterMinskyMachineSimulation> DoubleCounterMinskyMachine { get; set; }
}