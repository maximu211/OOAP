using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7._1.ConcreteCommand
{
    internal interface ICommand
    {
        void Execute();
        void Undo();
    }
}
