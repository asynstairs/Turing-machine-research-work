using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Tkachev_TuringSimulation_WPF.Files;
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

        private readonly ExecutionGroupMinskyMachine _executionTree;

        private AbstractExecutableMinskyMachine _lastUsedExecutable;

        private ProgramEditingState _currentEditingState = ProgramEditingState.Default;

        private static readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private static int _currentStateOrder = 0;

        public MainWindow()
        {
            InitializeComponent();

            _executionTree = new ExecutionGroupMinskyMachine();
            
            Closing += HandleAppClose;
            
            StartConfig();
        }

        private void HandleAppClose(object? sender, CancelEventArgs e)
        {
            _cancellationTokenSource.Cancel();
            Closing -= HandleAppClose;
        }

        private void Reset()
        {
            ProgrammTextBox.Text = string.Empty;
            _executionTree.Reset();
            _programStringBuilder.Clear();
            _doubleCounterMinskyMachine = new MinskyMachineSemiGroups();
            _lastUsedExecutable = null;
            _currentStateOrder = 0;
            _currentEditingState = ProgramEditingState.Default;
            _cancellationTokenSource.Cancel();
        }

        private void StartButton_OnClick(object sender, RoutedEventArgs e)
        {
            ExecuteMinskyMachine();

            try
            {
                PrintProtocolAsync(_cancellationTokenSource.Token).ConfigureAwait(false);
            }
            catch (OperationCanceledException operationCanceledException) { }

            PrintCountersResults();
            
            Reset();
        }

        private void ExecuteMinskyMachine()
        {
            var temp = new ExecutionGroupMinskyMachine();
            
            temp.Add(new ApplyCounterOperationExecutableMinskyMachine(
                DoubleCounterMinskyMachineCounterType.First,
                MinskyMachineCounterOperationType.Increment,
                 Convert.ToInt32(ACounterTextBox.Text)));
            
            temp.Add(new ApplyCounterOperationExecutableMinskyMachine(
                DoubleCounterMinskyMachineCounterType.Second,
                MinskyMachineCounterOperationType.Increment,
                Convert.ToInt32(BCounterTextBox.Text)));
            
            temp.Add(_executionTree);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            temp.Execute(_doubleCounterMinskyMachine);
            stopwatch.Stop();

            ExecutionTimeLabel.Content = $"Execution time: {stopwatch.ElapsedMilliseconds} ms.";
        }

        private void PrintProgram()
        {
            ProgrammTextBox.Text = _programStringBuilder.ToString();
        }

        private void ApplyCounterOperation(
            ApplyCounterOperationExecutableMinskyMachine applyCounterOperation)
        {
            if (_currentEditingState == ProgramEditingState.AddingConditionalGroup)
            {
                _lastUsedExecutable.With(applyCounterOperation);
            }
            else
            {
                _executionTree.Add(applyCounterOperation);
                _lastUsedExecutable = applyCounterOperation;
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
                            MinskyMachineCounterOperationType.Increment));
                    break;
                case MinskyMachine2CProgramView.IncrementSecondCounter:
                    ApplyCounterOperation(new ApplyCounterOperationExecutableMinskyMachine(
                        DoubleCounterMinskyMachineCounterType.Second,
                        MinskyMachineCounterOperationType.Increment));
                    break;
                case MinskyMachine2CProgramView.DecrementFirstCounter:
                    ApplyCounterOperation(new ApplyCounterOperationExecutableMinskyMachine(
                            DoubleCounterMinskyMachineCounterType.First,
                            MinskyMachineCounterOperationType.Decrement));
                    break;
                case MinskyMachine2CProgramView.DecrementSecondCounter:
                    ApplyCounterOperation(new ApplyCounterOperationExecutableMinskyMachine(
                        DoubleCounterMinskyMachineCounterType.Second,
                        MinskyMachineCounterOperationType.Decrement));
                    break;
                case MinskyMachine2CProgramView.ConditionalTransition:
                    _currentEditingState = ProgramEditingState.AddingConditionalGroup;
                    OnStartedAddingGroup(isConditionalTransition: true);

                    if (print)
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
            if (_lastUsedExecutable is ApplyCounterOperationExecutableMinskyMachine executable)
            {
                if (executable.OperationType == MinskyMachineCounterOperationType.Increment)
                {
                    MessageBox.Show("Вы не можете добавить условный переход к оператору увелечения счетчика!" +
                                    "Условный переход возможен только для оператора уменьшения счетчика.", "Ошибка ввода!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Вы не можете применить условный переход " +
                                "не к оператору увеличения или уменьшения счетчиков!", "Ошибка ввода!");
                
                return;
            }
            
            AddProgramExecutable(MinskyMachine2CProgramView.ConditionalTransition);
        }

        private void CloseGroupButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_currentEditingState == ProgramEditingState.Default)
            {
                MessageBox.Show("Прежде чем закрыть группу, необходимо ее открыть." +
                                " Была не найдена открывающая скобка [.", "Ошибка ввода!");
                
                return;
            }

            if (_lastUsedExecutable is not ApplyCounterOperationExecutableMinskyMachine)
            {
                MessageBox.Show("Вы не можете закрыть группу условного перехода" +
                                ", не добавив операторов увеличения, уменьшения счетчиков по этому переходу. " +
                                "Добавьте их прежде закрытия группы.", "Ошибка ввода!");
                
                return;
            }

            AddProgramExecutable(MinskyMachine2CProgramView.EndGroup);
        }

        private void AddEndButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddProgramExecutable(MinskyMachine2CProgramView.StopNode);
        }

        private void ResetButton_OnClick(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void StartConfig()
        {
            AddProgramExecutable(MinskyMachine2CProgramView.DecrementFirstCounter);
            AddProgramExecutable(MinskyMachine2CProgramView.ConditionalTransition);
            AddProgramExecutable(MinskyMachine2CProgramView.StopNode);
            AddProgramExecutable(MinskyMachine2CProgramView.EndGroup);
            AddProgramExecutable(MinskyMachine2CProgramView.IncrementSecondCounter);
        }

        private void PrintCountersResults()
        {
            ResultACounterTextBox.Text = _doubleCounterMinskyMachine
                    .GetCounterValue(DoubleCounterMinskyMachineCounterType.First)
                    .ToString();
            
            ResultBCounterTextBox.Text = _doubleCounterMinskyMachine
                .GetCounterValue(DoubleCounterMinskyMachineCounterType.Second)
                .ToString();
        }

        private async Task PrintProtocolAsync(CancellationToken cancellationToken)
        {
            FormulaProtocol.Formula = _doubleCounterMinskyMachine.Configs.ToString();
            
            await GlobalPaths.ClearAllAsync();
        }
    }
}