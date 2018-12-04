using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompoundPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            DuckSimulator duckSimulator = new DuckSimulator();
            //duckSimulator.Simulate();
            //duckSimulator.SimulateWithGooseAdapter();
            //duckSimulator.SimulateWithQuackCounterDecorator();
            //duckSimulator.SimulateUsingDuckFactory();
            duckSimulator.SimulateFlockComposite();
        }
    }
}
