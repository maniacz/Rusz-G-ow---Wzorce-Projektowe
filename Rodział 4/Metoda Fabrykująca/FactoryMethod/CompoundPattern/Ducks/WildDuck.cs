using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompoundPattern.Observable;

namespace CompoundPattern.Ducks
{
    public class WildDuck : IQuacking
    {
        Observed observed;

        public WildDuck(Observed observed)
        {
            observed = new Observed(this);
        }

        public void Quack()
        {
            Console.WriteLine("Kwa! Kwa!");
            notifyObservators();
        }

        public void notifyObservators()
        {
            observed.notifyObservators();
        }

        public void registerObservator(IObservator observator)
        {
            observed.registerObservator(observator);
        }
    }
}
