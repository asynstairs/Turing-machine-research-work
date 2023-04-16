using TuringMachineSimulation.Machines.Simulations;

namespace TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Node;

public class ChangeStateOrderExecutableDoubleCounterMinskyMachine : AbstractExecutableMinskyMachine
{
    private readonly int _order;
    private readonly IMinskyMachine<IDoubleCounterMinskyMachineSimulation> _doubleCounterMinskyMachine;

    public ChangeStateOrderExecutableDoubleCounterMinskyMachine(
        int order,
        IMinskyMachine<IDoubleCounterMinskyMachineSimulation> doubleCounterMinskyMachine)
    {
        _order = order;
        _doubleCounterMinskyMachine = doubleCounterMinskyMachine;
    }

    protected override void OnExecuted()
    {
        _doubleCounterMinskyMachine.ChangeConfigState(_order);
    }
}