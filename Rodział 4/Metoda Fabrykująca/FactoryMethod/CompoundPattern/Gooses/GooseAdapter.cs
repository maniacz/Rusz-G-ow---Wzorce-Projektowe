using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompoundPattern.Gooses
{
    public class GooseAdapter : IQuacking
    {
        Goose goose;

        public GooseAdapter(Goose goose)
        {
            this.goose = goose;
        }

        public void Quack()
        {
            goose.Gaggle();
        }
    }
}
