using TuringMachineSimulation.Machines.Minsky;
using TuringMachineSimulation.Math.SemiGroups;

namespace Entry
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var minskyMachine = new MinskyMachineSemiGroups();
            
            Console.WriteLine(minskyMachine.GetConfigRepresentation());
            
            minskyMachine.ChangeCounter(DoubleCounterMinskyMachineCounterType.First, 
                MinskyMachineCounterOperationType.Increment);

            Console.WriteLine(minskyMachine.GetConfigRepresentation());
            
            minskyMachine.ChangeCounter(DoubleCounterMinskyMachineCounterType.Second, 
                MinskyMachineCounterOperationType.Increment);
            
            Console.WriteLine(minskyMachine.GetConfigRepresentation());
            
            minskyMachine.ChangeCounter(DoubleCounterMinskyMachineCounterType.Second, 
                MinskyMachineCounterOperationType.Decrement);
            
            Console.WriteLine(minskyMachine.GetConfigRepresentation());
            
             
            minskyMachine.ChangeCounter(DoubleCounterMinskyMachineCounterType.Second, 
                MinskyMachineCounterOperationType.Decrement);
            
            Console.WriteLine(minskyMachine.GetConfigRepresentation());
            
             
            minskyMachine.ChangeCounter(DoubleCounterMinskyMachineCounterType.Second, 
                MinskyMachineCounterOperationType.Decrement);
            
            Console.WriteLine(minskyMachine.GetConfigRepresentation());
            
            minskyMachine.ChangeCounter(DoubleCounterMinskyMachineCounterType.Second, 
                MinskyMachineCounterOperationType.Increment);
            
            Console.WriteLine(minskyMachine.GetConfigRepresentation());
            
            minskyMachine.ChangeCounter(DoubleCounterMinskyMachineCounterType.Second, 
                MinskyMachineCounterOperationType.Increment);
            
            Console.WriteLine(minskyMachine.GetConfigRepresentation());
            
            minskyMachine.ChangeCounter(DoubleCounterMinskyMachineCounterType.First, 
                MinskyMachineCounterOperationType.Decrement);
            
            Console.WriteLine(minskyMachine.GetConfigRepresentation());
            
            minskyMachine.ChangeCounter(DoubleCounterMinskyMachineCounterType.First, 
                MinskyMachineCounterOperationType.Decrement);
            
            Console.WriteLine(minskyMachine.GetConfigRepresentation());
            
            minskyMachine.ChangeCounter(DoubleCounterMinskyMachineCounterType.Second, 
                MinskyMachineCounterOperationType.Decrement);
            
            Console.WriteLine(minskyMachine.GetConfigRepresentation());
            
            minskyMachine.ChangeCounter(DoubleCounterMinskyMachineCounterType.Second, 
                MinskyMachineCounterOperationType.Decrement);
            
            Console.WriteLine(minskyMachine.GetConfigRepresentation());
            
            minskyMachine.ChangeCounter(DoubleCounterMinskyMachineCounterType.Second, 
                MinskyMachineCounterOperationType.Decrement);
            
            Console.WriteLine(minskyMachine.GetConfigRepresentation());
            
            minskyMachine.ChangeConfigState(2);
            
            Console.WriteLine(minskyMachine.GetConfigRepresentation());
            
            minskyMachine.ChangeConfigState(3);
            
            Console.WriteLine(minskyMachine.GetConfigRepresentation());
            
            minskyMachine.ChangeConfigState(4);
            
            Console.WriteLine(minskyMachine.GetConfigRepresentation());
             
            // minskyMachine.ChangeCounter(DoubleCounterMinskyMachineCounterType.First, 
            //     MinskyMachineCounterOperationType.Increment);
            //
            // Console.WriteLine(minskyMachine.GetConfigRepresentation());
            //
            //  
            // minskyMachine.ChangeCounter(DoubleCounterMinskyMachineCounterType.First, 
            //     MinskyMachineCounterOperationType.Increment);
            //
            // Console.WriteLine(minskyMachine.GetConfigRepresentation());
            //
            //  
            // minskyMachine.ChangeCounter(DoubleCounterMinskyMachineCounterType.Second, 
            //     MinskyMachineCounterOperationType.Increment);
            //
            // Console.WriteLine(minskyMachine.GetConfigRepresentation());
            //
            // minskyMachine.ChangeCounter(DoubleCounterMinskyMachineCounterType.Second, 
            //     MinskyMachineCounterOperationType.Increment);
            //
            // Console.WriteLine(minskyMachine.GetConfigRepresentation());
            //
            // minskyMachine.ChangeCounter(DoubleCounterMinskyMachineCounterType.Second, 
            //     MinskyMachineCounterOperationType.Decrement);
            //
            // Console.WriteLine(minskyMachine.GetConfigRepresentation());
            //
            // minskyMachine.ChangeCounter(DoubleCounterMinskyMachineCounterType.Second, 
            //     MinskyMachineCounterOperationType.Decrement);
            //
            // Console.WriteLine(minskyMachine.GetConfigRepresentation());
        }
    }
}

