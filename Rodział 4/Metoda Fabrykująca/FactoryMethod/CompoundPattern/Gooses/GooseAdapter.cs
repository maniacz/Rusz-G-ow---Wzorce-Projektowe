using CompoundPattern.Observable;
using System;

namespace CompoundPattern.Gooses
{
    public class GooseAdapter : IQuacking
    {
        Goose goose;
        Observed observed;

        public GooseAdapter(Goose goose)
        {
            this.goose = goose;
            observed = new Observed(this);
        }

        public void Quack()
        {
            goose.Gaggle();
            notifyObservators();
        }

        public void notifyObservators()
        {
            observed.notifyObservators();
        }

        public void registerObservator(IObservator observator)
        {
            observed.registerObservator(observator);
        }
    }
}
