using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            WildDuck duck = new WildDuck();
            WildTurkey turkey = new WildTurkey();

            IDuck turkeyAdapter = new TurkeyAdapter(turkey);

            Console.WriteLine("------Indyk powiada tak...");
            turkey.GulGul();
            turkey.Fly();

            Console.WriteLine("\n------Kaczka powiada tak...");
            DuckTest(duck);

            Console.WriteLine("\n------A IndykAdapter powiada tak...");
            DuckTest(turkeyAdapter);

            Console.ReadKey();
        }

        private static void DuckTest(IDuck duck)
        {
            duck.Quack();
            duck.Fly();
        }

        public interface IDuck
        {
            void Quack();
            void Fly();
        }

        public class WildDuck : IDuck
        {
            public void Quack()
            {
                Console.WriteLine("Kwa! Kwa!");
            }

            public void Fly()
            {
                Console.WriteLine("O rany! Latam!");
            }
        }

        public interface ITurkey
        {
            void GulGul();
            void Fly();
        }

        public class WildTurkey : ITurkey
        {
            public void GulGul()
            {
                Console.WriteLine("GulGulGul");
            }

            public void Fly()
            {
                Console.WriteLine("O rany! Latam!... ale tylko na krótkich dystansach!");
            }
        }

        public class TurkeyAdapter : IDuck
        {
            ITurkey turkey;

            public TurkeyAdapter(ITurkey turkey)
            {
                this.turkey = turkey;
            }

            public void Quack()
            {
                turkey.GulGul();
            }

            public void Fly()
            {
                for (int i = 0; i < 5; i++)
                {
                    turkey.Fly();
                }
            }
        }
    }
}
