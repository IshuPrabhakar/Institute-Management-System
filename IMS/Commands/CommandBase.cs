using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IMS.Commands
{
    public class CommandBase : ICommand
    {
        Action<object> executeMethod;
        Func<object, bool> canExecuteMethod;
        bool canExecuteCache;

        public CommandBase(Action<object> executeMethod)
        {
            this.executeMethod = executeMethod;
        }

        public CommandBase(Action<object> executeMethod, Func<object, bool> canexecuteMethod, bool canexecuteCache)
        {
            this.executeMethod = executeMethod;
            this.canExecuteMethod = canexecuteMethod;
            this.canExecuteCache = canexecuteCache;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested += value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            executeMethod(parameter);
        }
    }
}
