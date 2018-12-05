using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompoundPattern.Observable;

namespace CompoundPattern.Ducks
{
    public class FlatnoseDuck : IQuacking
    {
        public void Quack()
        {
            Console.WriteLine("Kwa! Kwa!");
        }

        public void notifyObservators()
        {
            throw new NotImplementedException();
        }

        public void registerObservator(IObservator observator)
        {
            throw new NotImplementedException();
        }
    }
}
