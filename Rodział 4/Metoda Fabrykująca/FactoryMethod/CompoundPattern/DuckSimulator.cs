using System;
using CompoundPattern.Ducks;
using CompoundPattern.Gooses;
using CompoundPattern.CounterDecorator;
using CompoundPattern.DuckFactories;
using CompoundPattern.BirdFlock;

namespace CompoundPattern
{
    class DuckSimulator
    {
        public void Simulate()
        {
            IQuacking wildDuck = new WildDuck();
            IQuacking flatnoseDuck = new FlatnoseDuck();
            IQuacking baitDuck = new BaitDuck();
            IQuacking rubberDuck = new RubberDuck();

            Console.WriteLine("Symulator kaczek\n");

            Simulate(wildDuck);
            Simulate(flatnoseDuck);
            Simulate(baitDuck);
            Simulate(rubberDuck);

            //Console.ReadKey();
        }

        public void SimulateWithGooseAdapter()
        {
            IQuacking wildDuck = new WildDuck();
            IQuacking flatnoseDuck = new FlatnoseDuck();
            IQuacking baitDuck = new BaitDuck();
            IQuacking rubberDuck = new RubberDuck();
            IQuacking goose = new GooseAdapter(new Goose());

            Console.WriteLine("\nSymulator kaczek z adaptowaną gęsią\n");

            Simulate(wildDuck);
            Simulate(flatnoseDuck);
            Simulate(baitDuck);
            Simulate(rubberDuck);
            Simulate(goose);

            //Console.ReadKey();
        }

        public void SimulateWithQuackCounterDecorator()
        {
            IQuacking wildDuck = new QuackCounterDecorator(new WildDuck());
            IQuacking flatnoseDuck = new QuackCounterDecorator(new FlatnoseDuck());
            IQuacking baitDuck = new QuackCounterDecorator(new BaitDuck());
            IQuacking rubberDuck = new QuackCounterDecorator(new RubberDuck());
            IQuacking goose = new GooseAdapter(new Goose());

            Console.WriteLine("\nSymulator kaczek z licznikiem kwaknięć - wrorzec Dekorator\n");

            Simulate(wildDuck);
            Simulate(flatnoseDuck);
            Simulate(baitDuck);
            Simulate(rubberDuck);
            Simulate(goose);

            Console.WriteLine("Kaczki kwaknęły " + QuackCounterDecorator.GetQuackCount() + " razy");
            QuackCounterDecorator.ResetQuackCounter();
            //Console.ReadKey();
        }

        public void SimulateUsingDuckFactory()
        {
            DuckAbstractFactory duckFactory = new CountingQuakDuckFactory();

            IQuacking wildDuck = duckFactory.CreateWildDuck();
            IQuacking flatnoseDuck = duckFactory.CreateFlatnoseDuck();
            IQuacking baitDuck = duckFactory.CreateBaitDuck();
            IQuacking rubberDuck = duckFactory.CreateRubberDuck();
            IQuacking goose = new GooseAdapter(new Goose());

            Console.WriteLine("\nSymulator kaczek z wzorcem Fabryka Abstrakcyjna\n");

            Simulate(wildDuck);
            Simulate(flatnoseDuck);
            Simulate(baitDuck);
            Simulate(rubberDuck);
            Simulate(goose);

            Console.WriteLine("Kaczki kwaknęły " + QuackCounterDecorator.GetQuackCount() + " razy");
            //Console.ReadKey();
        }

        public void SimulateFlockComposite()
        {
            DuckAbstractFactory duckFactory = new CountingQuakDuckFactory();
            IQuacking flatnoseDuck = duckFactory.CreateFlatnoseDuck();
            IQuacking baitDuck = duckFactory.CreateBaitDuck();
            IQuacking rubberDuck = duckFactory.CreateRubberDuck();
            IQuacking gooseDuck = new GooseAdapter(new Goose());

            Console.WriteLine("Symulator kaczek z wzorcem Kompozyt - stada");

            Flock flockOfDucks = new Flock();
            flockOfDucks.Add(flatnoseDuck);
            flockOfDucks.Add(baitDuck);
            flockOfDucks.Add(rubberDuck);
            flockOfDucks.Add(gooseDuck);

            Flock flockOfWildDucks = new Flock();
            IQuacking wildDuck1 = duckFactory.CreateWildDuck();
            IQuacking wildDuck2 = duckFactory.CreateWildDuck();
            IQuacking wildDuck3 = duckFactory.CreateWildDuck();
            IQuacking wildDuck4 = duckFactory.CreateWildDuck();
            flockOfWildDucks.Add(wildDuck1);
            flockOfWildDucks.Add(wildDuck2);
            flockOfWildDucks.Add(wildDuck3);
            flockOfWildDucks.Add(wildDuck4);

            flockOfDucks.Add(flockOfWildDucks);

            Console.WriteLine("\nSymulator kaczek: Symulacja całego stada");
            Simulate(flockOfDucks);

            Console.WriteLine("\nSymulator kaczek: Symulacja stada dzikich kaczek");
            Simulate(flockOfWildDucks);

            Console.WriteLine("Kaczki kwaknęły " + QuackCounterDecorator.GetQuackCount() + " razy");
            Console.ReadKey();
        }

        private void Simulate(IQuacking duck)
        {
            duck.Quack();
        }
    }
}
