using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7._1
{
    internal class Receiver
    {
        private string _text = "";
        private StringBuilder _sb = new StringBuilder();
        private Stack<string> _addedTexts = new Stack<string>();

        public void AddText(string text)
        {
            _text = _sb.Append(text).ToString();
            _addedTexts.Push(text);
        }

        public void RemoveLastAddedText()
        {
            if (_addedTexts.Count > 0)
            {
                var lastAddedText = _addedTexts.Pop();
                _text = _text.Substring(0, _text.Length - lastAddedText.Length);
            }
            else
            {
                Console.WriteLine("No text to remove");
            }
        }

        public void RemoveText(int startIndex, int lenght) =>
            _text = _text.Remove(startIndex, lenght);

        public void InsertText(int index, string text) => _text = _text.Insert(index, text);

        public void MakeItalic(int startIndex, int lenght)
        {
            _text = _text.Insert(startIndex, "<i>");
            _text = _text.Insert(startIndex + lenght + 3, "</i>");
        }

        public string GetText() => _text;

        public void SetText(string text) => _text = text;
    }
}
