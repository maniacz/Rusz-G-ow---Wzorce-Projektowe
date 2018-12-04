using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompoundPattern.CounterDecorator;
using CompoundPattern.Ducks;

namespace CompoundPattern.DuckFactories
{
    class CountingQuakDuckFactory : DuckAbstractFactory
    {
        public override IQuacking CreateWildDuck()
        {
            return new QuackCounterDecorator(new WildDuck());
        }

        public override IQuacking CreateFlatnoseDuck()
        {
            return new QuackCounterDecorator(new FlatnoseDuck());
        }

        public override IQuacking CreateBaitDuck()
        {
            return new QuackCounterDecorator(new BaitDuck());
        }

        public override IQuacking CreateRubberDuck()
        {
            return new QuackCounterDecorator(new RubberDuck());
        }
    }
}
