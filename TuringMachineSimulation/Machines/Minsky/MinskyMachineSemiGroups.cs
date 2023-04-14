using TuringMachineSimulation.Machines.Minsky.Counter;
using TuringMachineSimulation.Machines.Simulation;
using TuringMachineSimulation.Math.SemiGroups;

namespace TuringMachineSimulation.Machines.Minsky;

public class MinskyMachineSemiGroups : IMinskyMachine<MinskyMachineSemiGroupSimulation>
{
    public MinskyMachineSemiGroupSimulation Simulation { get; set; }

    public void ChangeConfigState(int stateOrder)
    {
        var stateElement =
            _config.Elements.Find(element => element == _configState);

        if (stateElement == default)
            throw new NullReferenceException($"Couldn't find a config state!");
        
        var stateElementPosition = _config.Elements.IndexOf(stateElement);
        stateElement.Index = stateOrder.ToString();

        _config.Elements.RemoveAt(stateElementPosition);
        _config.Elements.Insert(stateElementPosition, stateElement);
    }

    public void ChangeCounter(DoubleCounterMinskyMachineCounterType counterType, MinskyMachineCounterOperationType operationType)
    {
        switch (counterType)
        {
            case DoubleCounterMinskyMachineCounterType.Left:
                ApplyCounterOperation(_leftCounter, operationType);
                break;
            case DoubleCounterMinskyMachineCounterType.Right:
                ApplyCounterOperation(_rightCounter, operationType);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(counterType), counterType, null);
        }
    }

    private void ApplyCounterOperation(MathLetter counter, MinskyMachineCounterOperationType operationType)
    {
        switch (operationType)
        {
            case MinskyMachineCounterOperationType.Increment:
                counter.Power++;
                break;
            case MinskyMachineCounterOperationType.Decrement:
                counter.Power--;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(operationType), operationType, null);
        }
        
        _config.Add(counter);
    }

    public string GetCurrentConfig()
    {
        return _config.ToString();
    }
}