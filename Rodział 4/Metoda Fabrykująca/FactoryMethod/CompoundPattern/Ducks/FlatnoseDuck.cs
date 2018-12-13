using System;
using CompoundPattern.Observable;

namespace CompoundPattern.Ducks
{
    public class FlatnoseDuck : IQuacking
    {
        Observed observed;

        public FlatnoseDuck()
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

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
