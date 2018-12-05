using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompoundPattern.Observable;

namespace CompoundPattern
{
    public interface IQuacking : IQuackObservable
    {
        void Quack();
    }
}
