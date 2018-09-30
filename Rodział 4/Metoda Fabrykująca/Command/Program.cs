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
            static void Main_(string[] args)
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

        public class SuperRemoteControllerProgramming
        {
            static void Main()
            {
                SuperRemoteController remote = new SuperRemoteController();
                Light livingroomLight = new Light();
                Light kitchennLight = new Light();
                GarageDoor garageDoor = new GarageDoor();

                CommandTurnOnLight livingroomTurnOnLight = new CommandTurnOnLight(livingroomLight);
                CommandTurnOffLight livingroomTurnOffLight = new CommandTurnOffLight(livingroomLight);
                CommandTurnOnLight kitchenTurnOnLight = new CommandTurnOnLight(kitchennLight);
                CommandTurnOffLight kitchenTurnOffLight = new CommandTurnOffLight(kitchennLight);
                CommandOpenGarageDoor openGarage = new CommandOpenGarageDoor(garageDoor);
                CommandCloseGarageDoor closeGarage = new CommandCloseGarageDoor(garageDoor);

                remote.SetCommand(0, livingroomTurnOnLight, livingroomTurnOffLight);
                remote.SetCommand(1, kitchenTurnOnLight, kitchenTurnOffLight);
                remote.SetCommand(2, openGarage, closeGarage);

                Console.WriteLine(remote);

                remote.PushedTurnOn(0);
                remote.PushedTurnOff(0);
                remote.PushedTurnOn(1);
                remote.PushedTurnOff(1);
                remote.PushedTurnOn(2);
                remote.PushedTurnOff(2);
                remote.PushedTurnOn(3);
                remote.PushedTurnOff(3);

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
            Console.WriteLine("Światło załączone.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Światło wyłączone.");
        }
    }

    public class GarageDoor
    {
        public void LiftUp()
        {
            Console.WriteLine("Drzwi garażowe są otwarte.");
        }

        public void CloseDown()
        {
            Console.WriteLine("Drzwi garażowe zostały zamknięte.");
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

    public class CommandTurnOffLight : ICommand
    {
        Light light;

        public CommandTurnOffLight(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.TurnOff();
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

    public class CommandCloseGarageDoor : ICommand
    {
        GarageDoor garageDoor;

        public CommandCloseGarageDoor(GarageDoor garageDoor)
        {
            this.garageDoor = garageDoor;
        }

        public void Execute()
        {
            garageDoor.CloseDown();
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

    public class SuperRemoteController
    {
        ICommand[] commandsTurnOn;
        ICommand[] commandsTurnOff;


        public SuperRemoteController()
        {
            commandsTurnOn = new ICommand[7];
            commandsTurnOff = new ICommand[7];

            ICommand noCommand = new NoCommand();
            for (int i = 0; i < 7; i++)
            {
                commandsTurnOn[i] = noCommand;
                commandsTurnOff[i] = noCommand;
            }
        }

        public class NoCommand : ICommand
        {
            public void Execute() { }
        }

        public void SetCommand(int slot, ICommand turnOnCommand, ICommand turnOffCommand)
        {
            commandsTurnOn[slot] = turnOnCommand;
            commandsTurnOff[slot] = turnOffCommand;
        }

        public void PushedTurnOn(int slot)
        {
            commandsTurnOn[slot].Execute();
        }

        public void PushedTurnOff(int slot)
        {
            commandsTurnOff[slot].Execute();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n-------- Super Pilot ---------\n");
            for (int i = 0; i < commandsTurnOn.Length; i++)
            {
                sb.Append("[slot " + i + "] " + commandsTurnOn[i].GetType().Name + "         " + commandsTurnOff[i].GetType().Name + "\n");
            }
            return sb.ToString();
        }
    }

}