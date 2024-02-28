using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7._1.ConcreteCommand
{
    internal class RemoveTextCommand : ICommand
    {
        private Receiver _receiver;
        private string _removedText;
        private int _startIndex;

        public RemoveTextCommand(Receiver receiver, int startIndex, int length)
        {
            _receiver = receiver;
            _startIndex = startIndex;
            _removedText = _receiver.GetText().Substring(startIndex, length);
        }

        public void Execute() => _receiver.RemoveText(_startIndex, _removedText.Length);

        public void Undo() => _receiver.InsertText(_startIndex, _removedText);
    }
}
