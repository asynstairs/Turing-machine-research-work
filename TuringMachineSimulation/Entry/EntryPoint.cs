using TuringMachineSimulation.Machines.Minsky;
using TuringMachineSimulation.Machines.Minsky.ExecutionProgram;
using TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Extensions;
using TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Group;
using TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Node;
using TuringMachineSimulation.Machines.Minsky.Parameters;
using TuringMachineSimulation.Machines.Simulations;
using TuringMachineSimulation.Math.SemiGroups;

namespace Entry
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            IMinskyMachine<IDoubleCounterMinskyMachineSimulation> minskyMachine 
                = new MinskyMachineSemiGroups();
            
            var minskyMachineExecutionProgram = new ExecutionGroupMinskyMachine()
                .Then(new ApplyCounterOperationExecutableMinskyMachine(
                    DoubleCounterMinskyMachineCounterType.First,
                    MinskyMachineCounterOperationType.Increment, 
                    minskyMachine, 30))
                .Then(new ApplyCounterOperationExecutableMinskyMachine(
                    DoubleCounterMinskyMachineCounterType.Second, 
                    MinskyMachineCounterOperationType.Increment,
                    minskyMachine, 30))
                .Then(new ChangeStateOrderExecutableDoubleCounterMinskyMachine(5, minskyMachine));

            minskyMachineExecutionProgram
                .OnComplete(() => Console.WriteLine(minskyMachine.GetConfigRepresentation()))
                .Execute();
        }
    }
}

