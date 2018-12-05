using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompoundPattern.Observable;

namespace CompoundPattern.Ducks
{
    public class BaitDuck : IQuacking
    {

        public void Quack()
        {
            Console.WriteLine("Kwak!");
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
