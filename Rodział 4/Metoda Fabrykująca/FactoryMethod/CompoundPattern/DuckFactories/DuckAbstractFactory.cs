using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompoundPattern.DuckFactories
{
    public abstract class DuckAbstractFactory
    {
        public abstract IQuacking CreateWildDuck();
        public abstract IQuacking CreateFlatnoseDuck();
        public abstract IQuacking CreateBaitDuck();
        public abstract IQuacking CreateRubberDuck();
    }
}
