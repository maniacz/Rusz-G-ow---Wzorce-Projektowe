using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
