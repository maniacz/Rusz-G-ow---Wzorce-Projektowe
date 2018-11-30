using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CompoundPattern
{
    public class DuckSimulator
    {
        public static void Main()
        {
            DuckSimulator simulator = new DuckSimulator();
            DuckAbstractFactory duckFactory = new DuckWithQuakCounterFactory();
            //simulator.Run();
            simulator.Run(duckFactory);
        }


        private void Run()
        {
            //IQuacking wildDuck = new WildDuck();
            //IQuacking flatnoseDuck = new FlatnoseDuck();
            //IQuacking baitDuck = new BaitDuck();
            //IQuacking rubberDuck = new RubberDuck();
            //IQuacking gooseDuck = new GooseAdapter(new Goose());

            IQuacking wildDuck = new QuackCounter(new WildDuck());
            IQuacking flatnoseDuck = new QuackCounter(new FlatnoseDuck());
            IQuacking baitDuck = new QuackCounter(new BaitDuck());
            IQuacking rubberDuck = new QuackCounter(new RubberDuck());
            IQuacking gooseDuck = new GooseAdapter(new Goose());

            //Console.WriteLine("\nSymulator Kaczek");
            Console.WriteLine("\nSymulator Kaczek z wzorcem Dekorator");

            Run(wildDuck);
            Run(flatnoseDuck);
            Run(baitDuck);
            Run(rubberDuck);
            Run(gooseDuck);

            Console.WriteLine("Kaczki kwakały " + QuackCounter.GetQuackCount() + " razy");
            Console.ReadKey();
        }

        private void Run(DuckAbstractFactory duckFactory)
        {
            IQuacking wildDuck = duckFactory.CreateWildDuck();
            IQuacking flatnoseDuck = duckFactory.CreateFlatnoseDuck();
            IQuacking baitDuck = duckFactory.CreateBaitDuck();
            IQuacking rubberDuck = duckFactory.CreateRubberDuck();
            IQuacking gooseDuck = new GooseAdapter(new Goose());

            //Console.WriteLine("\nSymulator Kaczek");
            //Console.WriteLine("\nSymulator Kaczek z wzorcem Dekorator");
            //Console.WriteLine("\nSymulator Kaczek z wzorcem Fabryka Abstrakcyjna");
            Console.WriteLine("\nSymulator Kaczek ze wzorcem Kompozyt - stada");

            Herd duckHerd = new Herd();

            duckHerd.Add(flatnoseDuck);
            duckHerd.Add(baitDuck);
            duckHerd.Add(rubberDuck);
            duckHerd.Add(gooseDuck);

            Herd wildDuckHerd = new Herd();

            IQuacking wildDuck1 = duckFactory.CreateWildDuck();
            IQuacking wildDuck2 = duckFactory.CreateWildDuck();
            IQuacking wildDuck3 = duckFactory.CreateWildDuck();
            IQuacking wildDuck4 = duckFactory.CreateWildDuck();

            wildDuckHerd.Add(wildDuck1);
            wildDuckHerd.Add(wildDuck2);
            wildDuckHerd.Add(wildDuck3);
            wildDuckHerd.Add(wildDuck4);

            duckHerd.Add(wildDuckHerd);

            //Run(wildDuck);
            //Run(flatnoseDuck);
            //Run(baitDuck);
            //Run(rubberDuck);
            //Run(gooseDuck);

            Console.WriteLine("\nSymulator kaczek: Symulacja całego stada");
            Run(duckHerd);

            Console.WriteLine("Kaczki kwakały " + QuackCounter.GetQuackCount() + " razy");
            Console.ReadKey();
        }

        private void Run(IQuacking duck)
        {
            duck.Quack();
        }
    }

    public interface IQuacking
    {
        void Quack();
    }

    public class WildDuck : IQuacking
    {
        public void Quack()
        {
            Console.WriteLine("Kwa! Kwa!");
        }
    }

    public class FlatnoseDuck : IQuacking
    {
        public void Quack()
        {
            Console.WriteLine("Kwa! Kwa!");
        }
    }

    public class BaitDuck : IQuacking
    {
        public void Quack()
        {
            Console.WriteLine("Kwak");
        }
    }

    public class RubberDuck : IQuacking
    {
        public void Quack()
        {
            Console.WriteLine("Piszczę!");
        }
    }

    public class Goose
    {
        public void Gaggle()
        {
            Console.WriteLine("Gę! Gę!");
        }
    }

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

    public class QuackCounter : IQuacking
    {
        IQuacking duck;
        static int quackCount;

        public QuackCounter(IQuacking duck)
        {
            this.duck = duck;
        }

        public void Quack()
        {
            duck.Quack();
            quackCount++;
        }

        public static int GetQuackCount()
        {
            return quackCount;
        }
    }

    public abstract class DuckAbstractFactory
    {
        public abstract IQuacking CreateWildDuck();
        public abstract IQuacking CreateFlatnoseDuck();
        public abstract IQuacking CreateBaitDuck();
        public abstract IQuacking CreateRubberDuck();
    }

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

    public class DuckWithQuakCounterFactory : DuckAbstractFactory
    {
        public override IQuacking CreateWildDuck()
        {
            return new QuackCounter(new WildDuck());
        }

        public override IQuacking CreateFlatnoseDuck()
        {
            return new QuackCounter(new FlatnoseDuck());
        }

        public override IQuacking CreateBaitDuck()
        {
            return new QuackCounter(new BaitDuck());
        }

        public override IQuacking CreateRubberDuck()
        {
            return new QuackCounter(new RubberDuck());
        }
    }

    //Stado - eng. Herd
    public class Herd : IQuacking
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
