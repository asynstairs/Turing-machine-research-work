using System;
using System.IO;
using System.Text;
using Tkachev_TuringSimulation_WPF.Files;
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

    private int _currentStateOrder = 0;
    
    public bool UseLog { get; set; }

    private readonly StringBuilder _configs;

    public DoubleCounterSemiGroupSimulationMinskyMachine(StringBuilder configs)
    {
        _configs = configs;
        SetEmptyStates();
        Log();
    }

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
        
        _config.SetStateOrder(_currentStateOrder++);

        SetEmptyStates();
        
        Log();
    }

    private void SetEmptyStates()
    {
        SetEmptyStateEnabled(EmptyStateSemiGroupMinskyMachineType.First, _config.FirstCounter.IsEmpty());
        SetEmptyStateEnabled(EmptyStateSemiGroupMinskyMachineType.Second, _config.SecondCounter.IsEmpty());
    }

    private void Log()
    {
        _configs.Append(_config.GetRepresentation() + @"\\");
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