﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompoundPattern.Ducks
{
    public class WildDuck : IQuacking
    {
        public void Quack()
        {
            Console.WriteLine("Kwa! Kwa!");
        }
    }
}
