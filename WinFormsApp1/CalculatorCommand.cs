using System.Windows.Input;

namespace WinFormsApp1;

internal class CalculatorCommand : ICommand
{
    private readonly Action<object?> _action;
    
    public event EventHandler? CanExecuteChanged;

    public CalculatorCommand(Action<object?> action)
    {
        _action = action;
    }

    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter) => _action?.Invoke(parameter);
}
