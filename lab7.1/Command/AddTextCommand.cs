using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7._1.ConcreteCommand
{
    internal class AddTextCommand : ICommand
    {
        private Receiver _receiver;
        private string _text;
        private Stack<string> _addedTexts;

        public AddTextCommand(Receiver receiver, string text, Stack<string> addedTexts)
        {
            _receiver = receiver;
            _text = text;
            _addedTexts = addedTexts;
        }

        public void Execute()
        {
            _receiver.AddText(_text);
        }

        public void Undo() => _receiver.RemoveLastAddedText();
    }
}
