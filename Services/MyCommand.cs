using System;
using System.Windows.Input;

namespace WpfDesignerAss.Services
{
    class MyCommand : ICommand
    {
        private Action _action;
        public MyCommand(Action action) => this._action = action;

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => _action?.Invoke();
    }
}