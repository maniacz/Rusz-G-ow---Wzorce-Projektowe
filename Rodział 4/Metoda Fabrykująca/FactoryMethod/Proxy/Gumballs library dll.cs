using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Serialization;
 
namespace Gumballs
{
    #region States
     
    /// <summary>
    /// Represents the State of the Gumball Machine.
    /// </summary>
    [Serializable]
    public abstract class State
    {
        [NonSerialized]
        protected GumballMachine _gumballMachine; 
         
        /// <summary>
        /// The Gumball Machine reference; used to change the state of the machine.
        /// </summary>
        protected GumballMachine GumballMachine { 
            get { return _gumballMachine; } 
            private set { _gumballMachine = value; }
        }
         
        /// <summary>
        /// The name of this state.
        /// </summary>
        protected string Name { get; private set; }
 
        /// <summary>
        /// Initializes a new instance of the <see cref="Gumballs.State"/> class.
        /// </summary>
        /// <param name='gumballMachine'>
        /// Gumball machine this state is part of.
        /// </param>
        /// <param name='name'>
        /// Name of this state.
        /// </param>
        protected State (GumballMachine gumballMachine, string name)
        {
            GumballMachine = gumballMachine;
            Name = name;
        }
         
        /// <summary>
        /// The behavior of the state when a quarter is inserted into the machine.
        /// </summary>
        public abstract void InsertQuarter ();
        /// <summary>
        /// The behavior of the state when a quarter is ejected from the machine.
        /// </summary>
        public abstract void EjectQuarter ();
        /// <summary>
        /// The behavior of the state when the machine's crank is turned.
        /// </summary>
        public abstract void TurnCrank ();
        /// <summary>
        /// The behavior of the state when the machine dispenses a gumball (or not).
        /// </summary>
        public abstract void Dispense ();
         
        /// <summary>
        /// Releases the given number of gumballs, and updates the machine's state 
        /// accordingly.
        /// </summary>
        /// <param name='count'>
        /// Number of gumballs to subtract.
        /// </param>
        protected void ReleaseGumballs (int count)
        {            
            for (int i = 1; i <= count; i++) {
                GumballMachine.ReleaseGumball ();
            }
             
            if (GumballMachine.IsEmpty ()) {
                GumballMachine.State = GumballMachine.SoldOutState;
            } else {
                GumballMachine.State = GumballMachine.NoQuarterState;
            }
        }
         
        public override string ToString ()
        {
            return string.Format ("[State {0}]", Name);
        }
    }
     
    /// <summary>
    /// Represents the state of the gumball machine when there is no quarter.
    /// </summary>
    [Serializable]
    public sealed class NoQuarterState : State
    {
        public NoQuarterState (GumballMachine gm) : base(gm, "NoQuarter")
        {
        }
         
        #region implemented abstract members of Gumballs.State
        public override void InsertQuarter ()
        {
            Console.WriteLine ("Accepting quarter");
            GumballMachine.State = GumballMachine.HasQuarterState;
        }
 
        public override void EjectQuarter ()
        {
            Console.WriteLine ("Cannot eject quarter as there is no quarter");
        }
 
        public override void TurnCrank ()
        {
            Console.WriteLine ("Can't turn the crank as there is no quarter");
        }
 
        public override void Dispense ()
        {
            Console.WriteLine ("Can't dispense gumballs because there is no quarter");
        }
        #endregion
    }
     
    /// <summary>
    /// Represents the state of the gumball machine when there is a quarter in the slot.
    /// </summary>
    [Serializable]
    public sealed class HasQuarterState : State
    {
        private Random _randomizer = new Random ();
         
        public HasQuarterState (GumballMachine gm) : base(gm, "HasQuarter")
        {
        }
         
        #region implemented abstract members of Gumballs.State
        public override void InsertQuarter ()
        {
            Console.WriteLine ("Can't insert a second quarter");
        }
 
        public override void EjectQuarter ()
        {
            Console.WriteLine ("Ejecting quarter");
            GumballMachine.State = GumballMachine.NoQuarterState;
        }
 
        public override void TurnCrank ()
        {
            Console.WriteLine ("Turning the crank");
             
            if (_randomizer.Next (11) == 10) {
                GumballMachine.State = GumballMachine.WinnerState;
            } else {
                GumballMachine.State = GumballMachine.SoldState;
            }
            GumballMachine.Dispense ();
        }
 
        public override void Dispense ()
        {
            Console.WriteLine ("Can't dispense; crank must be turned first");
        }
        #endregion
    }
     
    /// <summary>
    /// Represents the state of the gumball machine when there is a successful sale.
    /// </summary>
    [Serializable]
    public sealed class SoldState : State
    {
        public SoldState (GumballMachine gm) : base(gm, "Sold")
        {
        }
 
        #region implemented abstract members of Gumballs.State
        public override void InsertQuarter ()
        {
            Console.WriteLine ("Please wait, your gumball is arriving");
        }
 
        public override void EjectQuarter ()
        {
            Console.WriteLine ("Please wait, your gumball is arriving");
        }
 
        public override void TurnCrank ()
        {
            Console.WriteLine ("Please wait, your gumball is arriving.");
        }
 
        public override void Dispense ()
        {
            ReleaseGumballs (1);
        }
        #endregion
    }
     
    /// <summary>
    /// Represents the state of the gumball machine when the successful sale is a winner.
    /// </summary>
    [Serializable]
    public sealed class WinnerState : State
    {
        public WinnerState (GumballMachine gm) : base(gm, "Winner")
        {
        }
 
        #region implemented abstract members of Gumballs.State
        public override void InsertQuarter ()
        {
            Console.WriteLine ("Please wait, your gumballs are arriving");
        }
 
        public override void EjectQuarter ()
        {
            Console.WriteLine ("Please wait, your gumballs are arriving");
        }
 
        public override void TurnCrank ()
        {
            Console.WriteLine ("Please wait, your gumballs are arriving");
        }
 
        public override void Dispense ()
        {
            ReleaseGumballs (2);
        }
        #endregion    
    }
     
    /// <summary>
    /// Represents the state of the gumball machine when there are no more gumballs.
    /// </summary>
    [Serializable]
    public sealed class SoldOutState : State
    {
        public SoldOutState (GumballMachine gm) : base(gm, "SoldOut")
        {
        }
         
        #region implemented abstract members of Gumballs.State
        public override void InsertQuarter ()
        {
            Console.WriteLine ("You cannot insert a quarter, gumballs are sold out");
        }
 
        public override void EjectQuarter ()
        {
            Console.WriteLine ("You weren't allowed to insert a quarter, gumballs are sold out");
        }
 
        public override void TurnCrank ()
        {
            Console.WriteLine ("You can't turn the crank, gumballs are sold out");
        }
 
        public override void Dispense ()
        {
            Console.WriteLine ("Can't dispense, gumballs are sold out");
        }
        #endregion
    }
     
    #endregion
     
    /// <summary>
    /// The Gumball Machine.
    /// </summary>
    public sealed class GumballMachine : MarshalByRefObject, IGumballMachineRemote
    {
        public State NoQuarterState { get; private set; }
 
        public State HasQuarterState { get; private set; }
 
        public State SoldState { get; private set; }
 
        public State WinnerState { get; private set; }
 
        public State SoldOutState { get; private set; }
 
        /// <summary>
        /// Gets the current number of gumballs in the machine.
        /// </summary>
        public int Count { get; private set; }
 
        /// <summary>
        /// Gets or sets the current state of the machine.
        /// </summary>
        public State State { 
            get { return _state; }
            internal set { 
                if (_validStates.Contains (value)) {
                    _state = value;
                } else {
                    throw new ArgumentException ("Invalid state instance " + value);
                }
            }
        }
         
        /// <summary>
        /// Gets the location of the machine.
        /// </summary>
        public string Location { get; private set; }
         
        private State _state;
        private List<State> _validStates;
         
        /// <summary>
        /// Initializes a new instance of the <see cref="Gumballs.GumballMachine"/> class.
        /// </summary>
        /// <param name='location'>
        /// Location of the Gumball machine.
        /// </param>
        /// <param name='count'>
        /// Initial number of gumballs in the machine.
        /// </param>
        public GumballMachine (string location, int count)
        {
            Location = location;
            Count = count;
             
            NoQuarterState = new NoQuarterState (this);
            HasQuarterState = new HasQuarterState (this);
            SoldState = new SoldState (this);
            WinnerState = new WinnerState (this);
            SoldOutState = new SoldOutState (this);
             
            _validStates = new List<State> ();
            _validStates.Add (NoQuarterState);
            _validStates.Add (HasQuarterState);
            _validStates.Add (SoldState);
            _validStates.Add (WinnerState);
            _validStates.Add (SoldOutState);
             
            if (Count > 0) {
                State = NoQuarterState;
            } else {
                State = SoldOutState;
            }
        }
         
        /// <summary>
        /// Inserts a quarter.
        /// </summary>
        public void InsertQuarter ()
        {
            State.InsertQuarter ();
        }
         
        /// <summary>
        /// Ejects the quarter.
        /// </summary>
        public void EjectQuarter ()
        {
            State.EjectQuarter ();
        }
         
        /// <summary>
        /// Turns the crank.
        /// </summary>
        public void TurnCrank ()
        {
            State.TurnCrank ();
        }
         
        /// <summary>
        /// Dispenses gumballs (possibly).
        /// </summary>
        public void Dispense ()
        {
            State.Dispense ();
        }
         
        /// <summary>
        /// Refill the machine with the specified count of gumballs.
        /// </summary>
        /// <param name='count'>
        /// Count of gumballs to refill with.
        /// </param>
        public void Refill (int count)
        {
            Count += count;
            if (State == SoldOutState) {
                State = NoQuarterState;
            }
        }
         
        /// <summary>
        /// Releases a gumball if it's available.
        /// </summary>
        public void ReleaseGumball ()
        {
            if (Count > 0) {
                Console.WriteLine ("Releasing gumball!");
                Count -= 1;            
            } else {
                Console.WriteLine ("No gumballs to release");
            }
                 
        }
         
        /// <summary>
        /// Determines whether this instance is empty.
        /// </summary>
        /// <returns>
        /// <c>true</c> if this instance is empty; otherwise, <c>false</c>.
        /// </returns>
        public bool IsEmpty ()
        {
            return Count <= 0;
        }
         
        public override string ToString ()
        {
            return string.Format (
                "[GumballMachine: State={0} Count={1} Location={2}]",
                State,
                Count,
                Location
            );
        }
 
        #region IGumballMachineRemote implementation
        public int GetCount ()
        {
            return Count;
        }
 
        public string GetLocation ()
        {
            return Location;
        }
 
        public State GetState ()
        {
            return State;
        }
        #endregion
    }
     
    /// <summary>
    /// Gumball machine monitor.
    /// </summary>
    public sealed class GumballMachineMonitor
    {
        private IGumballMachineRemote _gumballMachine;
         
        /// <summary>
        /// Initializes a new instance of the <see cref="Gumballs.GumballMachineMonitor"/> class.
        /// </summary>
        /// <param name='gumballMachine'>
        /// Remote gumball machine.
        /// </param>
        public GumballMachineMonitor (IGumballMachineRemote gumballMachine)
        {
            _gumballMachine = gumballMachine;
        }
         
        public void Report ()
        {
            Console.WriteLine ("Gumball machine: {0}", _gumballMachine.GetLocation ());
            Console.WriteLine (
                "Current inventory: {0} gumballs",
                _gumballMachine.GetCount()
            );
            Console.WriteLine ("Current state: {0}", _gumballMachine.GetState ());
        }
    }
     
    #region Remoting
     
    /// <summary>
    /// Remote exception.
    /// </summary>
    public class RemoteException : Exception
    {
        public RemoteException (string message, Exception cause) : base(message, cause) {}
 
        public RemoteException (string message) : base(message) {}
    }
     
    /// <summary>
    /// Proxy for a remote gumball machine.
    /// </summary>
    public interface IGumballMachineRemote
    {
        /// <summary>
        /// Gets the count of gumballs.
        /// </summary>
        /// <returns>
        /// The count of gumballs.
        /// </returns>
        int GetCount ();
 
        /// <summary>
        /// Gets the location of the machine.
        /// </summary>
        /// <returns>
        /// The location.
        /// </returns>
        string GetLocation ();
 
        /// <summary>
        /// Gets the state of the machine.
        /// </summary>
        /// <returns>
        /// The state.
        /// </returns>
        State GetState ();
    }
     
    #endregion
}