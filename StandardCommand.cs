using System;
using System.Windows.Input;

namespace DailyProject
{
    public class StandardCommand : ICommand
    {
        readonly Action _onExecute = null;
        readonly Func<bool> _getCanExecute = null;

        public event EventHandler CanExecuteChanged;

        public StandardCommand(Action onExecute)
        {
            _onExecute = onExecute;
            _getCanExecute = () => true;
        }

        public StandardCommand(Action onExecute, Func<bool> getCanExecute)
        {
            _onExecute = onExecute;
            _getCanExecute = getCanExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _getCanExecute.Invoke();
        }

        public void Execute(object parameter)
        {
            _onExecute.Invoke();
        }
    }

}
