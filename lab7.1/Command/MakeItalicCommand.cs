using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7._1.ConcreteCommand
{
    internal class MakeItalicCommand : ICommand
    {
        private Receiver _receiver;
        private int _lenght;
        private int _startIndex;

        public MakeItalicCommand(Receiver receiver, int lenght, int startIndex)
        {
            _receiver = receiver;
            _lenght = lenght;
            _startIndex = startIndex;
        }

        public void Execute() => _receiver.MakeItalic(_startIndex, _lenght);

        public void Undo()
        {
            string text = _receiver.GetText();
            text = text.Replace("<i>", "").Replace("</i>", "");
            _receiver.SetText(text);
        }
    }
}
