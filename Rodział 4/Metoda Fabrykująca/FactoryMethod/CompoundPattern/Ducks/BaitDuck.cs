using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompoundPattern.Observable;

namespace CompoundPattern.Ducks
{
    public class BaitDuck : IQuacking
    {
        Observed observed;

        public BaitDuck()
        {
            observed = new Observed(this);
        }

        public void Quack()
        {
            Console.WriteLine("Kwak!");
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
