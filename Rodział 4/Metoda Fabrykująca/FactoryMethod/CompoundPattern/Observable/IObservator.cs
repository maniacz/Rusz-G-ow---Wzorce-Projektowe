using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompoundPattern.Observable
{
    public interface IObservator
    {
        void Update(IQuackObservable duck);
    }
}
