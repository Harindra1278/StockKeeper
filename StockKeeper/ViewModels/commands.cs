using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StockKeeper.ViewModels
{
    public class Commands : ICommand
    {
        private Action<object> execute;
        private Func<object , bool> canExecute;
        public event EventHandler? CanExecuteChanged;

        public Commands(Action<object> execute, Func<object, bool> canExecute)
        {
           this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return canExecute != null || canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
           execute(parameter);
        }
    }
}
