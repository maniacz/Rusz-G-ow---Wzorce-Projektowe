using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace State
{
    public class GumMachine
    {
        State state = State.EMPTY;
        int gumCount = 0;

        public GumMachine(int gumCount)
        {
            this.gumCount = gumCount;
            if (gumCount > 0)
            {
                state = State.NO_COIN;
            }
        }

        public enum State
        {
            EMPTY,
            NO_COIN,
            COIN_PRESENT,
            GUM_SOLD
        }

        public void InsertCoin()
        {
            if (state == State.COIN_PRESENT)
            {
                Console.WriteLine("Nie możesz włożyć więcej niż jednej monety");
            }
            else if (state == State.EMPTY)
            {
                Console.WriteLine("Nie możesz kupić gumy, automat jest pusty");
            }
            else if (state == State.GUM_SOLD)
            {
                Console.WriteLine("Proszę czekać na gumę");
            }
            else if (state == State.NO_COIN)
            {
                state = State.COIN_PRESENT;
                Console.WriteLine("Moneta przyjęta");
            }
        }

        public void ReturnCoin()
        {
            if (state == State.COIN_PRESENT)
            {
                Console.WriteLine("Moneta zwrócona");
                state = State.NO_COIN;
            }
            else if (state == State.EMPTY)
            {
                Console.WriteLine("Nie włożyłeś monety");
            }
            else if (state == State.GUM_SOLD)
            {
                Console.WriteLine("Niestety nie można zwrócić monety po przekręceniu gałki");
            }
            else if (state == State.NO_COIN)
            {
                Console.WriteLine("Nie włożyłeś monety");
            }
        }

        public void TurnTheKnob()
        {
            if (state == State.COIN_PRESENT)
            {
                Console.WriteLine("Obróciłeś gałkę...");
                state = State.GUM_SOLD;
                DeliverGum();
            }
            else if (state == State.EMPTY)
            {
                Console.WriteLine("Przekręciłeś gałkę, ale automat jest pusty");
            }
            else if (state == State.GUM_SOLD)
            {
                Console.WriteLine("Nie dostaniesz gumy tylko dlatego, że przekręciłeś drugi raz!");
            }
            else if (state == State.NO_COIN)
            {
                Console.WriteLine("Zanim przekręcisz gałkę, wrzuć monetę");
            }
        }

        public void DeliverGum()
        {
            if (state == State.COIN_PRESENT)
            {
                Console.WriteLine("Nie wydano gumy");
            }
            else if (state == State.EMPTY)
            {
                Console.WriteLine("Nie wydano gumy");
            }
            else if (state == State.GUM_SOLD)
            {
                Console.WriteLine("Wypada guma");
                gumCount--;
                if (gumCount == 0)
                {
                    Console.WriteLine("Ups, koniec gum!");
                    state = State.EMPTY;
                }
                else
                {
                    state = State.NO_COIN;
                }
            }
            else if (state == State.NO_COIN)
            {
                Console.WriteLine("");
            }
        }

        public override string ToString()
        {
            StringBuilder textToReturn = new StringBuilder();
            textToReturn.AppendLine();
            textToReturn.AppendLine("Automaty Sprzedające SA");
            textToReturn.AppendLine("Wolnostojący automat sprzedający Gumball Model #2004");
            textToReturn.AppendLine("Zapas: " + gumCount + " gumy");
            switch (state)
            {
                case State.EMPTY:
                    textToReturn.AppendLine("Automat jest pusty");
                    break;
                case State.NO_COIN:
                    textToReturn.AppendLine("Automat oczekuje na monetę");
                    break;
                case State.COIN_PRESENT:
                    textToReturn.AppendLine("Automat przyjął monetę");
                    break;
                case State.GUM_SOLD:
                    textToReturn.AppendLine("Automat sprzedaje gumę");
                    break;
                default:
                    break;
            }

            return textToReturn.ToString();
        }
    }

    public class GumMashineTest
    {
        public static void Main()
        {
            GumMachine gumMachine = new GumMachine(5);

            Console.WriteLine(gumMachine);

            gumMachine.InsertCoin();
            gumMachine.TurnTheKnob();

            Console.WriteLine(gumMachine);

            gumMachine.InsertCoin();
            gumMachine.ReturnCoin();
            gumMachine.TurnTheKnob();

            Console.WriteLine(gumMachine);

            gumMachine.InsertCoin();
            gumMachine.TurnTheKnob();
            gumMachine.InsertCoin();
            gumMachine.TurnTheKnob();
            gumMachine.ReturnCoin();

            Console.WriteLine(gumMachine);

            gumMachine.InsertCoin();
            gumMachine.InsertCoin();
            gumMachine.TurnTheKnob();
            gumMachine.InsertCoin();
            gumMachine.TurnTheKnob();
            gumMachine.InsertCoin();
            gumMachine.TurnTheKnob();

            Console.WriteLine(gumMachine);

            Console.ReadKey();
        }
    }
}
