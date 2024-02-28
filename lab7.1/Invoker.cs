using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab7._1.ConcreteCommand;

namespace lab7._1
{
    internal class Invoker
    {
        private List<ICommand> _commands = new List<ICommand>();

        public void SetCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public void ExecuteCommand()
        {
            _commands.Last().Execute();
        }

        public void UndoLastCommand()
        {
            if (_commands.Count > 0)
            {
                var lastCommand = _commands.Last();
                lastCommand.Undo();
                _commands.Remove(lastCommand);
            }
            else
                Console.WriteLine("No commands to undo");
        }
    }
}
