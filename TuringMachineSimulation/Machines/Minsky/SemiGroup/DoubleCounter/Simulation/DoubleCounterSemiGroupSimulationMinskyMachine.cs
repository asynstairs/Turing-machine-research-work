using TuringMachineSimulation.Machines.Configs;
using TuringMachineSimulation.Machines.Minsky;
using TuringMachineSimulation.Machines.Minsky.EmptyState;
using TuringMachineSimulation.Machines.Simulations;

namespace TuringMachineSimulation.Machines.Simulation;

public class DoubleCounterSemiGroupSimulationMinskyMachine : IDoubleCounterMinskyMachineSimulation
{
    private readonly DoubleCounterMinskyMachineSemiGroupConfig _config
        = new DoubleCounterMinskyMachineSemiGroupConfig();

    void IDoubleCounterMinskyMachineSimulation.ChangeStateOrder(int order)
    {
        _config.SetStateOrder(order);
    }
    
    public void ApplyOperationOnCounter(MinskyMachineCounterOperationType operationType,
        DoubleCounterMinskyMachineCounterType counterType)
    {
        switch (counterType)
        {
            case DoubleCounterMinskyMachineCounterType.First:
                SetEmptyStateEnabled(EmptyStateSemiGroupMinskyMachineType.First, 
                    !_config.FirstCounter.TryApplyOperation(operationType));
                break;
            case DoubleCounterMinskyMachineCounterType.Second:
                SetEmptyStateEnabled(EmptyStateSemiGroupMinskyMachineType.Second, 
                    !_config.SecondCounter.TryApplyOperation(operationType));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(counterType), counterType, null);
        }
    }

    private void SetEmptyStateEnabled(EmptyStateSemiGroupMinskyMachineType emptyStateSemiGroupMinskyMachineType, bool isEnabled)
    {
        _config.SetEmptyStateEnabled(emptyStateSemiGroupMinskyMachineType, isEnabled);
    }

    string IMachineSimulation.GetConfigRepresentation()
    {
        return _config.GetRepresentation();
    }
}