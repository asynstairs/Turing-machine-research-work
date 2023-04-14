using TuringMachineSimulation.Machines.Minsky;
using TuringMachineSimulation.Math.SemiGroups;

namespace Entry
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var minskyMachine = new MinskyMachineSemiGroups();

            Console.WriteLine(minskyMachine.GetCurrentConfig());
            
            minskyMachine.ChangeCounter(DoubleCounterMinskyMachineCounterType.Left, MinskyMachineCounterOperationType.Increment);
            minskyMachine.ChangeCounter(DoubleCounterMinskyMachineCounterType.Left, MinskyMachineCounterOperationType.Increment);
            minskyMachine.ChangeCounter(DoubleCounterMinskyMachineCounterType.Left, MinskyMachineCounterOperationType.Increment);
            
            Console.WriteLine(minskyMachine.GetCurrentConfig());
            
            minskyMachine.ChangeConfigState(5);
            
            Console.WriteLine(minskyMachine.GetCurrentConfig());
            
            Console.WriteLine(minskyMachine.GetCounterValue(DoubleCounterMinskyMachineCounterType.Left));
            Console.WriteLine(minskyMachine.GetCounterValue(DoubleCounterMinskyMachineCounterType.Right));
        }
    }
}

