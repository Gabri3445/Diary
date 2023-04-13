using System;
using System.Windows.Input;

namespace Diary.App;

public class RelayCommand : ICommand
{
    #region Fields

    private readonly Action<object> _execute;
    private readonly Predicate<object>? _canExecute;

    #endregion

    #region Constructors
    public RelayCommand(Action<object> execute) : this(execute, null) { }

    public RelayCommand(Action<object> execute, Predicate<object> canExecute)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }
    #endregion

    #region ICommand Members
    public bool CanExecute(object? parameter)
    {
        return parameter != null && (_canExecute?.Invoke(parameter) ?? true);
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public void Execute(object? parameter)
    {
        if (parameter != null) _execute(parameter);
    }
    #endregion
}