using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompoundPattern
{
    public class DuckSimulator
    {
        public static void Main()
        {
            DuckSimulator simulator = new DuckSimulator();
            simulator.Run();
        }

        private void Run()
        {
            IQuacking wildDuck = new WildDuck();
            IQuacking flatnoseDuck = new FlatnoseDuck();
            IQuacking baitDuck = new BaitDuck();
            IQuacking rubberDuck = new RubberDuck();
            IQuacking gooseDuck = new GooseAdapter(new Goose());

            Console.WriteLine("\nSymulator Kaczek");

            Run(wildDuck);
            Run(flatnoseDuck);
            Run(baitDuck);
            Run(rubberDuck);
            Run(gooseDuck);

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
}
