using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Node;

public abstract class AbstractExecutableMinskyMachine
{
    public bool IsCompleted { get; protected set; }
    public ICollection<AbstractExecutableMinskyMachine> NextExecutables { get; set; } 
        = new List<AbstractExecutableMinskyMachine>();

    protected string LogAlso { get; set; } = default;
    
    public void Execute()
    {
        OnExecuted();

        using var writer = File.AppendText("log.log");
        writer.WriteLine($"Exec: {GetType().Name}, IsCom: {IsCompleted}, NextExecC: {NextExecutables.Count}, {LogAlso}");
    }
    
    protected abstract void OnExecuted();
}