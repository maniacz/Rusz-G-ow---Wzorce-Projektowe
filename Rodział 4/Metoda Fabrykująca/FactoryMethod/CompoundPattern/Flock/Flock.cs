using System.Collections;
using CompoundPattern.Observable;

namespace CompoundPattern.BirdFlock
{
    public class Flock : IQuacking
    {
        ArrayList birds = new ArrayList();
        Observed observed;

        public Flock()
        {
            observed = new Observed(this);
        }

        public void Add(IQuacking bird)
        {
            birds.Add(bird);
        }

        public void Quack()
        {
            IEnumerator enumerator = birds.GetEnumerator();
            while (enumerator.MoveNext())
            {
                IQuacking bird = (IQuacking)enumerator.Current;
                bird.Quack();
                notifyObservators();
            }
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
