using CommandLine;
using TuringMachineSimulation.Machines.Minsky;
using TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Extensions;
using TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Group;
using TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Node;
using TuringMachineSimulation.Machines.Minsky.Operation;
using TuringMachineSimulation.Machines.Minsky.SemiGroup;
using TuringMachineSimulation.Machines.Minsky.SemiGroup.DoubleCounter.Counter;
using TuringMachineSimulation.Machines.Simulations;

namespace TuringMachineSimulation.Entry
{
    public class EntryPoint
    {
        // public static void Main(string[] args)
        // {
        //     IMinskyMachine<IDoubleCounterMinskyMachineSimulation> minskyMachine 
        //         = new MinskyMachineSemiGroups();
        //     
        //     var minskyMachineExecutionProgram = new ExecutionGroupMinskyMachine()
        //         .Then(new ApplyCounterOperationExecutableMinskyMachine(
        //             DoubleCounterMinskyMachineCounterType.First,
        //             MinskyMachineCounterOperationType.Increment, 
        //             minskyMachine, 30))
        //         .Then(new ApplyCounterOperationExecutableMinskyMachine(
        //             DoubleCounterMinskyMachineCounterType.Second, 
        //             MinskyMachineCounterOperationType.Increment,
        //             minskyMachine, 30))
        //         .Then(new ChangeStateOrderExecutableDoubleCounterMinskyMachine(5, minskyMachine));
        //
        //     minskyMachineExecutionProgram
        //         .OnComplete(() => Console.WriteLine(minskyMachine.GetConfigRepresentation()))
        //         .Execute();
        // }
        
        public class Options
        {
            [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
            public bool Verbose { get; set; }
        }

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    if (o.Verbose)
                    {
                        Console.WriteLine($"Verbose output enabled. Current Arguments: -v {o.Verbose}");
                        Console.WriteLine("Quick Start Example! App is in Verbose mode!");
                    }
                    else
                    {
                        Console.WriteLine($"Current Arguments: -v {o.Verbose}");
                        Console.WriteLine("Quick Start Example!");
                    }
                });
        }
    }
}

