using TuringMachineSimulation.Machines.Configs;
using TuringMachineSimulation.Machines.Minsky;
using TuringMachineSimulation.Machines.Minsky.Counter;
using TuringMachineSimulation.Machines.Simulations;
using TuringMachineSimulation.Math.SemiGroups;

namespace TuringMachineSimulation.Machines.Simulation;

public class MinskyMachineSemiGroupSimulation : IDoubleCounterMinskyMachineSimulation
{
    private readonly DoubleCounterMinskyMachineSemiGroupConfig _config
        = new DoubleCounterMinskyMachineSemiGroupConfig();

    public bool TryApplyOperation(MinskyMachineCounterOperationType operationType, 
        DoubleCounterMinskyMachineCounterType counterType)
    {
        return counterType switch
        {
            DoubleCounterMinskyMachineCounterType.First => _config.FirstCounter.TryApplyOperation(operationType),
            DoubleCounterMinskyMachineCounterType.Second => _config.SecondCounter.TryApplyOperation(operationType),
            _ => throw new ArgumentOutOfRangeException(nameof(counterType), counterType, null)
        };
    }
}