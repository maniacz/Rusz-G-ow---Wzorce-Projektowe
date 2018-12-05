using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompoundPattern.Observable;

namespace CompoundPattern.CounterDecorator
{
    public class QuackCounterDecorator : IQuacking
    {
        IQuacking duck;
        static int quackCount;

        public QuackCounterDecorator(IQuacking duck)
        {
            this.duck = duck;
        }

        public void Quack()
        {
            duck.Quack();
            quackCount++;
        }

        public static int GetQuackCount()
        {
            return quackCount;
        }

        internal static void ResetQuackCounter()
        {
            Console.WriteLine("Reset licznika kwaknieć");
            quackCount = 0;
        }

        public void registerObservator(IObservator observator)
        {
            throw new NotImplementedException();
        }

        public void notifyObservators()
        {
            throw new NotImplementedException();
        }
    }
}
