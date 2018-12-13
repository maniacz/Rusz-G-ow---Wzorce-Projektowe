using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompoundPattern.Observable
{
    public class Quakologist : IObservator
    {
        public void Update(IQuackObservable duck)
        {
            Console.WriteLine("Kwakolog: " + duck.ToString() + " kwaknęła");
        }
    }
}
