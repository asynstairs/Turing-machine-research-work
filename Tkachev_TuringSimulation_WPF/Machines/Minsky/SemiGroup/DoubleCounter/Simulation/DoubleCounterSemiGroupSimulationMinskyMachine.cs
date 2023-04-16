using System;
using System.IO;
using TuringMachineSimulation.Machines.Minsky.Operation;
using TuringMachineSimulation.Machines.Minsky.SemiGroup.DoubleCounter.Config;
using TuringMachineSimulation.Machines.Minsky.SemiGroup.DoubleCounter.Counter;
using TuringMachineSimulation.Machines.Minsky.SemiGroup.EmptyState;
using TuringMachineSimulation.Machines.Simulations;

namespace TuringMachineSimulation.Machines.Minsky.SemiGroup.DoubleCounter.Simulation;

public class DoubleCounterSemiGroupSimulationMinskyMachine : IDoubleCounterMinskyMachineSimulation
{
    private readonly DoubleCounterMinskyMachineSemiGroupConfig _config
        = new DoubleCounterMinskyMachineSemiGroupConfig();

    void IDoubleCounterMinskyMachineSimulation.ChangeStateOrder(int order)
    {
        _config.SetStateOrder(order);
    }

    public bool IsCounterEmpty(DoubleCounterMinskyMachineCounterType counterType)
    {
        return counterType switch
        {
            DoubleCounterMinskyMachineCounterType.First => _config.FirstCounter.IsEmpty(),
            DoubleCounterMinskyMachineCounterType.Second => _config.SecondCounter.IsEmpty(),
            _ => throw new ArgumentOutOfRangeException(nameof(counterType), counterType, null)
        };
    }

    int IDoubleCounterMinskyMachineSimulation.GetCounterValue(DoubleCounterMinskyMachineCounterType counterType)
    {
        return counterType switch
        {
            DoubleCounterMinskyMachineCounterType.First => _config.FirstCounter.Value,
            DoubleCounterMinskyMachineCounterType.Second => _config.SecondCounter.Value,
            _ => throw new ArgumentOutOfRangeException(nameof(counterType), counterType, null)
        };
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
        
        Log();
    }

    private void Log(string logAlso = default)
    {
        using var writer = File.AppendText("Config.log");
        writer.WriteLine(_config.GetRepresentation() + logAlso);
    }

    private void SetEmptyStateEnabled(EmptyStateSemiGroupMinskyMachineType emptyStateSemiGroupMinskyMachineType, bool isEnabled)
    {
        _config.SetEmptyStateEnabled(emptyStateSemiGroupMinskyMachineType, isEnabled);

        var emptyStateLog = isEnabled ? $"[set empty state]" : string.Empty;
        
        Log(emptyStateLog);
    }

    string IMachineSimulation.GetConfigRepresentation()
    {
        return _config.GetRepresentation();
    }
}