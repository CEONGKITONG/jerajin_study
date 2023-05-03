using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFCommandExam
{
    class RelayCommand : ICommand
    {

        Func<object, bool> canExecute;
        Action<object> executeAction;

        //public event EventHandler CanExecuteChanged;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        public bool CanExecute(object parameter)
        {
            if (parameter?.ToString().Length == 0)
                return false;

            bool result = this.canExecute == null ? true : this.canExecute.Invoke(parameter);

            return result;
        }

        public void Execute(object parameter)
        {
            this.executeAction.Invoke(parameter);
        }


        public RelayCommand(Action<object> executeAction) : this(executeAction, null)
        {

        }

        public RelayCommand(Action<object> executeAction, Func<object, bool> canExecute)
        {
            this.executeAction = executeAction ?? throw new ArgumentNullException("Execute Action was null for ICommand");
            this.canExecute = canExecute;


        }

    }
}
