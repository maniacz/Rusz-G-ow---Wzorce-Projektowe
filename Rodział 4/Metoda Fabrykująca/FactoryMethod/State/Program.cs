using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
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

        State state;
        int gumCount = 0;

        public GumMachine(int gumCount)
        {
            emptyState = new EmptyState(this);
            noCoinState = new NoCoinState(this);
            coinPresentState = new CoinPresentState(this);
            gumSoldState = new GumSoldState(this);

            this.gumCount = gumCount;
            if (gumCount > 0)
                state = noCoinState;
            else
                state = emptyState;
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

        public void DeliverGum()
        {
            Console.WriteLine("Automat jest pusty");
            gumMachine.SetState(gumMachine.GetStateEmpty());
            ReturnCoin();
        }

        public void InsertCoin()
        {
            Console.WriteLine("Automat jest pusty");
        }

        public void ReturnCoin()
        {
            Console.WriteLine("Automat jest pusty");
        }

        public void TurnTheKnob()
        {
            Console.WriteLine("Automat jest pusty");
        }
    }

    public class CoinPresentState : State
    {
        GumMachine gumMachine;

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
            gumMachine.SetState(gumMachine.GetStateGumSold());
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
            Console.WriteLine("");
        }

        public void InsertCoin()
        {
            Console.WriteLine("");
        }

        public void ReturnCoin()
        {
            Console.WriteLine("");
        }

        public void TurnTheKnob()
        {
            Console.WriteLine("");
        }
    }
}
