using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompoundPattern.Observable
{
    public interface IQuackObservable
    {
        void registerObservator(IObservator observator);
        void notifyObservators();
    }
}
