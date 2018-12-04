using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompoundPattern.Ducks;

namespace CompoundPattern.DuckFactories
{
    public class DuckFactory : DuckAbstractFactory
    {
        public override IQuacking CreateWildDuck()
        {
            return new WildDuck();
        }

        public override IQuacking CreateFlatnoseDuck()
        {
            return new FlatnoseDuck();
        }

        public override IQuacking CreateBaitDuck()
        {
            return new BaitDuck();
        }

        public override IQuacking CreateRubberDuck()
        {
            return new RubberDuck();
        }
    }
}
