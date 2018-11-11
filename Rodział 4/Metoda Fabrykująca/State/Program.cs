using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace State
{
    public class GumMachineTest
    {
        static void Main() 
        {
            GumMachine gumMachine = new GumMachine(5);

            Console.WriteLine(gumMachine);

            gumMachine.InsertCoin();
            gumMachine.TurnTheKnob();

            Console.WriteLine(gumMachine);

            gumMachine.InsertCoin();
            gumMachine.TurnTheKnob();
            gumMachine.InsertCoin();
            gumMachine.TurnTheKnob();

            Console.WriteLine(gumMachine);

            Console.ReadKey();
        }
    }

    public interface State
    {
        void InsertCoin();
        void ReturnCoin();
        void TurnTheKnob();
        void DeliverGum();
    }

    public class GumMachine
    {
        State emptyState;
        State noCoinState;
        State coinPresentState;
        State gumSoldState;
        State victoryState;

        State state;
        int gumCount = 0;

        public GumMachine(int gumCount)
        {
            emptyState = new EmptyState(this);
            noCoinState = new NoCoinState(this);
            coinPresentState = new CoinPresentState(this);
            gumSoldState = new GumSoldState(this);
            victoryState = new VictoryState(this);

            this.gumCount = gumCount;
            if (gumCount > 0)
                state = noCoinState;
            else
                state = emptyState;
        }

        public override string ToString()
        {
            StringBuilder textToReturn = new StringBuilder();
            textToReturn.AppendLine();
            textToReturn.AppendLine("Automaty Sprzedające SA");
            textToReturn.AppendLine("Wolnostojący automat sprzedający Gumball Model #2004");
            textToReturn.AppendLine("Zapas: " + gumCount + " gumy");

            if (state is EmptyState)
                textToReturn.AppendLine("Automat jest pusty");
            else if (state is NoCoinState)
                textToReturn.AppendLine("Automat oczekuje na monetę");
            else if (state is CoinPresentState)
                textToReturn.AppendLine("Automat przyjął monetę");
            else if (state is GumSoldState)
                textToReturn.AppendLine("Automat sprzedaje gumę");
            else if (state is VictoryState)
                textToReturn.AppendLine("Wygrana!");

            return textToReturn.ToString();
        }

        public void InsertGums(int gumsInserted)
        {
            gumCount += gumsInserted;
        }

        public void InsertCoin()
        {
            state.InsertCoin();
        }

        public void ReturnCoin()
        {
            state.ReturnCoin();
        }

        public void TurnTheKnob()
        {
            state.TurnTheKnob();
            state.DeliverGum();
        }

        public void SetState(State state)
        {
            this.state = state;
        }

        public void ReleaseGum()
        {
            Console.WriteLine("Wypada guma...");
            if (gumCount != 0)
                gumCount--;
        }

        public State GetStateCoinPresent()
        {
            return coinPresentState;
        }

        public State GetStateEmpty()
        {
            return emptyState;
        }

        public State GetStateNoCoin()
        {
            return noCoinState;
        }

        public State GetStateGumSold()
        {
            return gumSoldState;
        }

        public State GetVictoryState()
        {
            return victoryState;
        }

        public int GetGumCount()
        {
            return gumCount;
        }
    }

    public class NoCoinState : State
    {
        GumMachine gumMachine;

        public NoCoinState(GumMachine gumMachine)
        {
            this.gumMachine = gumMachine;
        }

        public void DeliverGum()
        {
            Console.WriteLine("Najpierw zapłać");
        }

        public void InsertCoin()
        {
            Console.WriteLine("Moneta przyjęta");
            gumMachine.SetState(gumMachine.GetStateCoinPresent());
        }

        public void ReturnCoin()
        {
            Console.WriteLine("Nie włożyłeś monety");
        }

        public void TurnTheKnob()
        {
            Console.WriteLine("Zanim przekręcisz gałkę, wrzuć monetę");
        }
    }

    public class EmptyState : State
    {
        GumMachine gumMachine;

        public EmptyState(GumMachine gumMachine)
        {
            this.gumMachine = gumMachine;
        }

        public void FillTheMachineWithGums(int gumsInserted)
        {
            Console.WriteLine("Uzupełniamy pusty automat gumami");
            gumMachine.InsertGums(gumsInserted);
            gumMachine.SetState(gumMachine.GetStateNoCoin());
        }

        public void DeliverGum()
        {
            Console.WriteLine("Automat jest pusty");
            gumMachine.SetState(gumMachine.GetStateEmpty());
            ReturnCoin();
        }

        public void InsertCoin()
        {
            Console.WriteLine("Nie można wrzucić monety. Automat jest pusty");
        }

        public void ReturnCoin()
        {
            Console.WriteLine("Nie można zwrócić monety, żadna nie została wrzucon. Automat jest pusty");
        }

        public void TurnTheKnob()
        {
            Console.WriteLine("Obróciłeś gałkę ale automat jest pusty");
        }
    }

    public class CoinPresentState : State
    {
        GumMachine gumMachine;
        Random randomVictory = new Random();

        public CoinPresentState(GumMachine gumMachine)
        {
            this.gumMachine = gumMachine;
        }

        //Akcja niedopuszczalna dla tego stanu
        public void DeliverGum()
        {
            Console.WriteLine("Nie wydano gumy");
        }

        public void InsertCoin()
        {
            Console.WriteLine("Nie możesz włożyć więcej niż jednej monety");
        }

        public void ReturnCoin()
        {
            Console.WriteLine("Moneta zwrócona");
            gumMachine.SetState(gumMachine.GetStateNoCoin());
        }

        public void TurnTheKnob()
        {
            Console.WriteLine("Obróciłeś gałkę...");
            int victory = randomVictory.Next(10);
            if (victory == 0)
            {
                gumMachine.SetState(gumMachine.GetVictoryState());
            }
            else
            {
                gumMachine.SetState(gumMachine.GetStateGumSold());
            }
        }
    }

    public class GumSoldState : State
    {
        GumMachine gumMachine;

        public GumSoldState(GumMachine gumMachine)
        {
            this.gumMachine = gumMachine;
        }

        public void DeliverGum()
        {
            gumMachine.ReleaseGum();
            if (gumMachine.GetGumCount() > 0)
	        {
                gumMachine.SetState(gumMachine.GetStateNoCoin());
	        }
            else
	        {
                Console.WriteLine("Ups, koniec gum!");
                gumMachine.SetState(gumMachine.GetStateEmpty());
	        }
        }

        //Akcja niedopuszczalna
        public void InsertCoin()
        {
            Console.WriteLine("Proszę czekać na gumę");
        }

        //Akcja niedopuszczalna
        public void ReturnCoin()
        {
            Console.WriteLine("Niestety nie można zwrócić gumy po przekręceniu gałki");
        }

        public void TurnTheKnob()
        {
            Console.WriteLine("Nie dostaniesz gumy tylko dla tego, że przekręciłeś drugi raz!");
        }
    }

    public class VictoryState : State
    {
        GumMachine gumMachine;

        public VictoryState(GumMachine gumMachine)
        {
            this.gumMachine = gumMachine;
        }

        public void InsertCoin()
        {
            Console.WriteLine("Nie trzeba wrzucać monety. Guma wygrana");
        }

        public void ReturnCoin()
        {
            Console.WriteLine("Brak monety do zwortu");
        }

        public void TurnTheKnob()
        {
            Console.WriteLine("Nie dostaniesz trzeciej gumy");
        }

        public void DeliverGum()
        {
            Console.WriteLine("WYGRAŁEŚ! Dostajesz drugą gumę");
            gumMachine.ReleaseGum();
            if (gumMachine.GetGumCount() == 0)
            {
                gumMachine.SetState(gumMachine.GetStateEmpty());
            }
            else
            {
                gumMachine.ReleaseGum();
                if (gumMachine.GetGumCount() > 0)
                {
                    gumMachine.SetState(gumMachine.GetStateNoCoin());
                }
                else
                {
                    Console.WriteLine("Koniec gum!");
                    gumMachine.SetState(gumMachine.GetStateEmpty());
                }
            }
        }
    }
}