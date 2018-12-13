using System;
using CompoundPattern.Observable;

namespace CompoundPattern.Ducks
{
    public class RubberDuck : IQuacking
    {
        Observed observed;

        public RubberDuck()
        {
            observed = new Observed(this);
        }

        public void Quack()
        {
            Console.WriteLine("Piszczę!");
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
