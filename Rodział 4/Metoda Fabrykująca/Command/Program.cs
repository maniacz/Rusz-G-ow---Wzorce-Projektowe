using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        public class MiniRemoteControllerTest
        {
            static void Main(string[] args)
            {
                MiniRemoteController remote = new MiniRemoteController();
                Light light = new Light();
                GarageDoor garageDoor = new GarageDoor();

                CommandTurnOnLight turnOnLight = new CommandTurnOnLight(light);
                CommandOpenGarageDoor openGarageDoor = new CommandOpenGarageDoor(garageDoor);

                remote.SetCommand(turnOnLight);
                remote.ButtonPushed();
                remote.SetCommand(openGarageDoor);
                remote.ButtonPushed();

                Console.ReadKey();
            }
        }
    }

    public interface ICommand
    {
        void Execute();
    }

    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("Światło włączone.");
        }
    }

    public class GarageDoor
    {
        public void LiftUp()
        {
            Console.WriteLine("Drzwi garażowe są otwarte.");
        }
    }

    public class CommandTurnOnLight : ICommand
    {
        Light light;

        public CommandTurnOnLight(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.TurnOn();
        }
    }

    public class CommandOpenGarageDoor : ICommand
    {
        GarageDoor garageDoor;

        public CommandOpenGarageDoor(GarageDoor garageDoor)
        {
            this.garageDoor = garageDoor;
        }

        public void Execute()
        {
            garageDoor.LiftUp();
        }
    }

    public class MiniRemoteController
    {
        ICommand slot;

        public MiniRemoteController() { }

        public void SetCommand(ICommand command)
        {
            slot = command;
        }

        public void ButtonPushed()
        {
            slot.Execute();
        }
    }

}