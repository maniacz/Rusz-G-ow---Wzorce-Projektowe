using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateMethod
{
    class Program
    {
        static void Main_(string[] args)
        {
            TeaWithHook tea = new TeaWithHook();
            CoffeeWithHook coffee = new CoffeeWithHook();

            Console.WriteLine("Przyrządzam herbatę");
            tea.PrepareRecipe();

            Console.WriteLine("A teraz pora na kawę");
            coffee.PrepareRecipe();

            Console.ReadKey();
        }

        static void Main()
        {
            Duck[] ducks =
            {
                new Duck("Kaczor Duffy", 8),
                new Duck("Kaczro Dewey", 2),
                new Duck("Kaczor Howard", 7),
                new Duck("Kaczor Louie", 2),
                new Duck("Kaczor Donald", 10),
                new Duck("Kaczur Huey", 2)
            };

            Console.WriteLine("Przed sortowaniem");
            Display(ducks);

            Array.Sort(ducks);

            Console.WriteLine("Po zakończeniu sortowania");
            Display(ducks);

            Console.ReadKey();
        }

        private static void Display(Duck[] ducks)
        {
            for (int i = 0; i < ducks.Length; i++)
            {
                Console.WriteLine(ducks[i]);
            }
        }
    }

    public abstract class CaffeineBeverageWithHook
    {
        //Nie da się tu zrobić metody sealed 
        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();
            if (CustomerWantsCondiments())
            {
                AddCondiments();
            }
        }

        protected abstract void Brew();

        protected abstract void AddCondiments();

        protected void BoilWater()
        {
            Console.WriteLine("Gotowanie wody");
        }

        protected void PourInCup()
        {
            Console.WriteLine("Nalewanie do filiżanki");
        }

        protected virtual bool CustomerWantsCondiments()
        {
            return true;
        }
    }

    public class TeaWithHook : CaffeineBeverageWithHook
    {
        protected override void Brew()
        {
            Console.WriteLine("Wkładanie torebki herbaty do wrzątku");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("Dodawanie cytryny");
        }

        protected override bool CustomerWantsCondiments()
        {
            string answer = GetAnswer();

            if (answer.ToLower().StartsWith("t"))
                return true;
            else
                return false;
        }

        private string GetAnswer()
        {
            string answer = null;

            Console.WriteLine("Czy życzy Pan sobie dodania cytryny do herbaty (t/n)?");

            try
            {
                answer = Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Błąd przy odczytywaniu odpowiedzi");
            }

            if (answer == null)
            {
                return "nie";
            }

            return answer;
        }
    }

    public class CoffeeWithHook : CaffeineBeverageWithHook
    {
        protected override void Brew()
        {
            Console.WriteLine("Zaparzanie i przesączanie kawy przez filtr");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("Dodawanie cukru i mleka");
        }

        protected override bool CustomerWantsCondiments()
        {
            string answer = GetAnswer();

            if (answer.ToLower().StartsWith("t"))
                return true;
            else
                return false;
        }

        private string GetAnswer()
        {
            string answer = null;

            Console.WriteLine("Czy życzy Pan sobie dodania cukru i mleka do kawy (t/n)?");

            try
            {
                answer = Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Błąd przy odczytywaniu odpowiedzi");
            }

            if (answer == null)
            {
                return "nie";
            }

            return answer;
        }
    }

    public class Duck : IComparable
    {
        string name;
        int weight;

        public Duck(string name, int weight)
        {
            this.name = name;
            this.weight = weight;
        }

        public override string ToString()
        {
            return name + " waży " + weight;
        }

        public int CompareTo(object obj)
        {
            Duck anotherDuck = (Duck)obj;

            if (this.weight < anotherDuck.weight)
                return -1;
            else if (this.weight == anotherDuck.weight)
                return 0;
            else
                return 1;

        }
    }
}
