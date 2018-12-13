using System.Collections;

namespace CompoundPattern.Observable
{
    public class Observed : IQuackObservable
    {
        ArrayList observators = new ArrayList();
        private IQuackObservable duck;

        public Observed(IQuackObservable duck)
        {
            this.duck = duck;
        }

        public void registerObservator(IObservator observator)
        {
            observators.Add(observator);
        }

        public void notifyObservators()
        {
            IEnumerator enumerator = observators.GetEnumerator();
            while (enumerator.MoveNext())
            {
                IObservator observator = (IObservator)enumerator.Current;
                observator.Update(duck);
            }
        }

    }
}
