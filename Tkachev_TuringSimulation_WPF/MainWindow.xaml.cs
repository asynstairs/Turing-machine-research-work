using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Tkachev_TuringSimulation_WPF.View.ExecutableProgram;
using TuringMachineSimulation.Machines.Minsky;
using TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Extensions;
using TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Group;
using TuringMachineSimulation.Machines.Minsky.ExecutionProgram.Node;
using TuringMachineSimulation.Machines.Minsky.Operation;
using TuringMachineSimulation.Machines.Minsky.SemiGroup;
using TuringMachineSimulation.Machines.Minsky.SemiGroup.DoubleCounter.Counter;
using TuringMachineSimulation.Machines.Simulations;

namespace Tkachev_TuringSimulation_WPF
{
    public enum ProgramEditingState
    {
        AddingConditionalGroup,
        Default
    }
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly StringBuilder _programStringBuilder = new StringBuilder();

        private IMinskyMachine<IDoubleCounterMinskyMachineSimulation> _doubleCounterMinskyMachine 
            = new MinskyMachineSemiGroups();

        private readonly ExecutionGroupMinskyMachine _executionTree 
            = new ExecutionGroupMinskyMachine();

        private AbstractExecutableMinskyMachine _lastUsedExecutable;

        private ProgramEditingState _currentEditingState = ProgramEditingState.Default;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Reset()
        {
            ProgrammTextBox.Text = string.Empty;
            _executionTree.Clear();
            _programStringBuilder.Clear();
            _doubleCounterMinskyMachine = new MinskyMachineSemiGroups();
        }

        private void PrintProgram()
        {
            ProgrammTextBox.Text = _programStringBuilder.ToString();
        }

        private void ApplyCounterOperation(
            ApplyCounterOperationExecutableMinskyMachine incrementCounterExecutable)
        {
            if (_currentEditingState == ProgramEditingState.AddingConditionalGroup)
            {
                _lastUsedExecutable.With(incrementCounterExecutable);
            }
            else
            {
                _executionTree.Add(incrementCounterExecutable);
                _lastUsedExecutable = incrementCounterExecutable;
            }
        }

        private void AddProgramExecutable(MinskyMachine2CProgramView programView, bool print=true)
        {
            switch (programView)
            {
                case MinskyMachine2CProgramView.StartGroup:
                    break;
                case MinskyMachine2CProgramView.EndGroup:
                    _currentEditingState = ProgramEditingState.Default;
                    break;
                case MinskyMachine2CProgramView.Delimiter:
                    break;
                case MinskyMachine2CProgramView.StopNode:
                    if (_currentEditingState == ProgramEditingState.Default)
                    {
                        _executionTree.Add(new StopExecutableMinskyMachine2C());
                    }
                    else
                    {
                        _lastUsedExecutable.With(new StopExecutableMinskyMachine2C());
                    }
                    
                    break;
                case MinskyMachine2CProgramView.IncrementFirstCounter:
                    ApplyCounterOperation( new ApplyCounterOperationExecutableMinskyMachine(
                            DoubleCounterMinskyMachineCounterType.First,
                            MinskyMachineCounterOperationType.Increment,
                            _doubleCounterMinskyMachine));
                    break;
                case MinskyMachine2CProgramView.IncrementSecondCounter:
                    ApplyCounterOperation(new ApplyCounterOperationExecutableMinskyMachine(
                        DoubleCounterMinskyMachineCounterType.Second,
                        MinskyMachineCounterOperationType.Increment,
                        _doubleCounterMinskyMachine));
                    break;
                case MinskyMachine2CProgramView.DecrementFirstCounter:
                    ApplyCounterOperation(new ApplyCounterOperationExecutableMinskyMachine(
                            DoubleCounterMinskyMachineCounterType.First,
                            MinskyMachineCounterOperationType.Decrement,
                            _doubleCounterMinskyMachine));
                    break;
                case MinskyMachine2CProgramView.DecrementSecondCounter:
                    ApplyCounterOperation(new ApplyCounterOperationExecutableMinskyMachine(
                        DoubleCounterMinskyMachineCounterType.Second,
                        MinskyMachineCounterOperationType.Decrement,
                        _doubleCounterMinskyMachine));
                    break;
                case MinskyMachine2CProgramView.ConditionalTransition:
                    _currentEditingState = ProgramEditingState.AddingConditionalGroup;
                    OnStartedAddingGroup(isConditionalTransition: true);
                    PrintProgram();
                    return;
                    break;
                case MinskyMachine2CProgramView.NonConditionalTransition:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(programView), programView, null);
            }
            
            _programStringBuilder.Append(
                $"{MinskyMachine2CViewMapper.OperationStringViews[programView]}" +
                $"{MinskyMachine2CViewMapper.OperationStringViews
                    [MinskyMachine2CProgramView.Delimiter]}");
            
            if (print)
                PrintProgram();
        }

        private void OnStartedAddingGroup(bool isConditionalTransition)
        {
            _programStringBuilder.Insert(_programStringBuilder.Length - 3,
                $"{MinskyMachine2CViewMapper.OperationStringViews[MinskyMachine2CProgramView.StartGroup]}" +
                $"{MinskyMachine2CViewMapper.OperationStringViews
                    [MinskyMachine2CProgramView.Delimiter]}");
            
            _programStringBuilder.Insert(_programStringBuilder.Length - 1,
                $"{MinskyMachine2CViewMapper.OperationStringViews
                    [isConditionalTransition ? MinskyMachine2CProgramView.ConditionalTransition 
                        : MinskyMachine2CProgramView.NonConditionalTransition]}");
        }

        private void IncrementAButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddProgramExecutable(MinskyMachine2CProgramView.IncrementFirstCounter);
        }

        private void IncrementBButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddProgramExecutable(MinskyMachine2CProgramView.IncrementSecondCounter);
        }

        private void DecrementAButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddProgramExecutable(MinskyMachine2CProgramView.DecrementFirstCounter);
        }

        private void DecrementBButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddProgramExecutable(MinskyMachine2CProgramView.DecrementSecondCounter);
        }

        private void ConditionalTransitionButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddProgramExecutable(MinskyMachine2CProgramView.ConditionalTransition);
        }

        private void NonConditionalTransitionButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddProgramExecutable(MinskyMachine2CProgramView.NonConditionalTransition);
        }

        private void CloseGroupButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddProgramExecutable(MinskyMachine2CProgramView.EndGroup);
        }

        private void AddEndButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddProgramExecutable(MinskyMachine2CProgramView.StopNode);
        }

        private void StartButton_OnClick(object sender, RoutedEventArgs e)
        {
            var temp = new ExecutionGroupMinskyMachine();
            
            temp.Add(new ApplyCounterOperationExecutableMinskyMachine(
                DoubleCounterMinskyMachineCounterType.First,
                MinskyMachineCounterOperationType.Increment,
                _doubleCounterMinskyMachine,
                Convert.ToInt32(ACounterTextBox.Text)));
            
            temp.Add(new ApplyCounterOperationExecutableMinskyMachine(
                DoubleCounterMinskyMachineCounterType.Second, 
                MinskyMachineCounterOperationType.Increment,
                _doubleCounterMinskyMachine,
                Convert.ToInt32(BCounterTextBox.Text)));
            
            temp.Add(_executionTree);

            temp.Execute();
            
            ProtocolTextBox.Text = _doubleCounterMinskyMachine.GetConfigRepresentation();

            Reset();
        }

        private void ResetButton_OnClick(object sender, RoutedEventArgs e)
        {
            Reset();
        }
    }
}