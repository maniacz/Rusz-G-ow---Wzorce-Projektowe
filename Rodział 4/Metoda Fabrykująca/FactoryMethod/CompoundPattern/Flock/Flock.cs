using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CompoundPattern.BirdFlock
{
    public class Flock : IQuacking
    {
        ArrayList birds = new ArrayList();

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
            }
        }
    }
}
