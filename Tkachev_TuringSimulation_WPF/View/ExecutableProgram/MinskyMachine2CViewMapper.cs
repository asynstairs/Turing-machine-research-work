using System.Collections.Generic;

namespace Tkachev_TuringSimulation_WPF.View.ExecutableProgram;

public static class MinskyMachine2CViewMapper
{
    public static IDictionary<MinskyMachine2CProgramView, string> OperationStringViews
        = new Dictionary<MinskyMachine2CProgramView, string>()
        {
            [MinskyMachine2CProgramView.StartGroup] = "[",
            [MinskyMachine2CProgramView.EndGroup] = "]",
            [MinskyMachine2CProgramView.Delimiter] = " ",
            [MinskyMachine2CProgramView.StopNode] = "STOP",
            [MinskyMachine2CProgramView.IncrementFirstCounter] = "A+",
            [MinskyMachine2CProgramView.IncrementSecondCounter] = "B+",
            [MinskyMachine2CProgramView.DecrementFirstCounter] = "A-",
            [MinskyMachine2CProgramView.DecrementSecondCounter] = "B-",
            [MinskyMachine2CProgramView.ConditionalTransition] = "?=>",
            [MinskyMachine2CProgramView.NonConditionalTransition] = "=>",
        };
}