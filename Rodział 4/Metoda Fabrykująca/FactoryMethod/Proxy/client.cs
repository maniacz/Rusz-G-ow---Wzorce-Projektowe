using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using Gumballs;
 
namespace RemoteGumballs
{
    class MainClass
    {
        public static void Main (string[] args)
        {
            try {
                HttpChannel channel = new HttpChannel ();
                ChannelServices.RegisterChannel (channel, false);
             
                IGumballMachineRemote gumballMachineRemote = 
                (IGumballMachineRemote)Activator.GetObject (
                    typeof(IGumballMachineRemote), "http://localhost:9998/GumballMachine");
             
                GumballMachineMonitor monitor = new GumballMachineMonitor (gumballMachineRemote);
                monitor.Report ();
            } catch (Exception e) {
                throw new RemoteException (e.Message, e);
            }
        }
    }
}