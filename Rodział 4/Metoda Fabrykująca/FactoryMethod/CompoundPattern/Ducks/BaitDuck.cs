using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompoundPattern.Ducks
{
    public class BaitDuck : IQuacking
    {
        public void Quack()
        {
            Console.WriteLine("Kwak!");
        }
    }
}
