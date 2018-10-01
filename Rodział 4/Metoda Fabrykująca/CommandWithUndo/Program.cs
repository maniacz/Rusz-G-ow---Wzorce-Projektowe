using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandWithRollback
{
    class Program
    {
        static void Main_(string[] args)
        {
            SuperRemoteControllerWithRollback remote = new SuperRemoteControllerWithRollback();
            Light livingroomLight = new Light();

            CommandTurnOnLight livingroomTurnOnLight = new CommandTurnOnLight(livingroomLight);
            CommandTurnOffLight livingroomTurnOffLight = new CommandTurnOffLight(livingroomLight);

            remote.SetCommand(0, livingroomTurnOnLight, livingroomTurnOffLight);

            remote.PushedTurnOn(0);
            remote.PushedTurnOff(0);
            Console.WriteLine(remote);
            remote.PushedRollBack();
            remote.PushedTurnOff(0);
            remote.PushedTurnOn(0);
            Console.WriteLine(remote);
            remote.PushedRollBack();

            Console.ReadKey();
        }

        static void Main__()
        {
            SuperRemoteControllerWithRollback remote = new SuperRemoteControllerWithRollback();
            CeilingFan ceilingFan = new CeilingFan("Jadalnia");

            CommandSetMediumSpeedOnFan commandFanMediumSpeed = new CommandSetMediumSpeedOnFan(ceilingFan);
            CommandSetHighSpeedOnFan commandFanHighSpeed = new CommandSetHighSpeedOnFan(ceilingFan);
            CommandTurnOffFan commandTurnOffFan = new CommandTurnOffFan(ceilingFan);

            remote.SetCommand(0, commandFanMediumSpeed, commandTurnOffFan);
            remote.SetCommand(1, commandFanHighSpeed, commandTurnOffFan);

            remote.PushedTurnOn(0);
            remote.PushedTurnOff(0);
            Console.WriteLine(remote);
            remote.PushedRollBack();

            remote.PushedTurnOn(1);
            Console.WriteLine(remote);
            remote.PushedRollBack();

            Console.ReadKey();
        }

        static void Main()
        {
            SuperRemoteControllerWithRollback remote = new SuperRemoteControllerWithRollback();
            Light light = new Light("Salon: ");
            TV tv = new TV("Salon: ");
            HiFi hiFi = new HiFi("Salon: ");
            Jacuzzi jacuzzi = new Jacuzzi();

            CommandTurnOnLight turnOnLight = new CommandTurnOnLight(light);
            CommandTurnOnHiFi turnOnHiFi = new CommandTurnOnHiFi(hiFi);
            CommandTurnOnTV turnOnTV = new CommandTurnOnTV(tv);
            CommandTurnOnJacuzzi turnOnJacuzzi = new CommandTurnOnJacuzzi(jacuzzi);

            CommandTurnOffLight turnOffLight = new CommandTurnOffLight(light);
            CommandTurnOffHiFi turnOffHiFi = new CommandTurnOffHiFi(hiFi);
            CommandTurnOffTV turnOffTV = new CommandTurnOffTV(tv);
            CommandTurnOffJacuzzi turnOffJacuzzi = new CommandTurnOffJacuzzi(jacuzzi);

            ICommand[] partyTurnOn = { turnOnLight, turnOnHiFi, turnOnTV, turnOnJacuzzi };
            ICommand[] partyTurnOff = { turnOffLight, turnOffHiFi, turnOffTV, turnOffJacuzzi };

            MakroCommand makroTurnOnParty = new MakroCommand(partyTurnOn);
            MakroCommand makroTurnOffParty = new MakroCommand(partyTurnOff);

            remote.SetCommand(0, makroTurnOnParty, makroTurnOffParty);

            Console.WriteLine(remote);
            Console.WriteLine("---- Włączamy makro polecenie ----");
            remote.PushedTurnOn(0);
            Console.WriteLine("---- Wyłączamy makro polecenie ----");
            remote.PushedTurnOff(0);

            Console.ReadKey();
        }

        public interface ICommand
        {
            void Execute();
            void Rollback();
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

            public void Rollback()
            {
                light.TurnOff();
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

            public void Rollback()
            {
                light.TurnOn();
            }
        }

        public class CommandSetHighSpeedOnFan : ICommand
        {
            CeilingFan fan;
            int previousSpeed;

            public CommandSetHighSpeedOnFan(CeilingFan fan)
            {
                this.fan = fan;
            }

            public void Execute()
            {
                previousSpeed = fan.GetCurrentSpeed();
                fan.HighSpeed();
            }

            public void Rollback()
            {
                if (previousSpeed == CeilingFan.FAST)
                {
                    fan.HighSpeed();
                }
                else if (previousSpeed == CeilingFan.MEDIUM)
                {
                    fan.MediumSpeed();
                }
                else if (previousSpeed == CeilingFan.LOW)
                {
                    fan.LowSpeed();
                }
                else if (previousSpeed == CeilingFan.OFF)
                {
                    fan.TurnOff();
                }
            }
        }

        public class CommandSetMediumSpeedOnFan : ICommand
        {
            CeilingFan fan;
            int previousSpeed;

            public CommandSetMediumSpeedOnFan(CeilingFan fan)
            {
                this.fan = fan;
            }

            public void Execute()
            {
                previousSpeed = fan.GetCurrentSpeed();
                fan.MediumSpeed();
            }

            public void Rollback()
            {
                if (previousSpeed == CeilingFan.FAST)
                {
                    fan.HighSpeed();
                }
                else if (previousSpeed == CeilingFan.MEDIUM)
                {
                    fan.MediumSpeed();
                }
                else if (previousSpeed == CeilingFan.LOW)
                {
                    fan.LowSpeed();
                }
                else if (previousSpeed == CeilingFan.OFF)
                {
                    fan.TurnOff();
                }
            }
        }

        public class CommandTurnOffFan : ICommand
        {
            CeilingFan fan;
            int previousSpeed;

            public CommandTurnOffFan(CeilingFan fan)
            {
                this.fan = fan;
            }

            public void Execute()
            {
                previousSpeed = fan.GetCurrentSpeed();
                fan.TurnOff();
            }

            public void Rollback()
            {
                if (previousSpeed == CeilingFan.FAST)
                {
                    fan.HighSpeed();
                }
                else if (previousSpeed == CeilingFan.MEDIUM)
                {
                    fan.MediumSpeed();
                }
                else if (previousSpeed == CeilingFan.LOW)
                {
                    fan.LowSpeed();
                }
                else if (previousSpeed == CeilingFan.OFF)
                {
                    fan.TurnOff();
                }
            }
        }

        public class CommandTurnOnHiFi : ICommand
        {
            HiFi hiFi;

            public CommandTurnOnHiFi(HiFi hiFi)
            {
                this.hiFi = hiFi;
            }

            public void Execute()
            {
                hiFi.TurnOn();
            }

            public void Rollback()
            {
                hiFi.TurnOff();
            }
        }

        public class CommandTurnOffHiFi : ICommand
        {
            HiFi hiFi;

            public CommandTurnOffHiFi(HiFi hiFi)
            {
                this.hiFi = hiFi;
            }

            public void Execute()
            {
                hiFi.TurnOff();
            }

            public void Rollback()
            {
                hiFi.TurnOn();
            }
        }

        public class CommandTurnOnTV : ICommand
        {
            TV tv;

            public CommandTurnOnTV(TV tv)
            {
                this.tv = tv;
            }

            public void Execute()
            {
                tv.TurnOn();
            }

            public void Rollback()
            {
                tv.TurnOff();
            }
        }

        public class CommandTurnOffTV : ICommand
        {
            TV tv;

            public CommandTurnOffTV(TV tv)
            {
                this.tv = tv;
            }

            public void Execute()
            {
                tv.TurnOff();
            }

            public void Rollback()
            {
                tv.TurnOn();
            }
        }

        public class CommandTurnOnJacuzzi : ICommand
        {
            Jacuzzi jacuzzi;

            public CommandTurnOnJacuzzi(Jacuzzi jacuzzi)
            {
                this.jacuzzi = jacuzzi;
            }

            public void Execute()
            {
                jacuzzi.TurnOn();
            }

            public void Rollback()
            {
                jacuzzi.TurnOff();
            }
        }

        public class CommandTurnOffJacuzzi : ICommand
        {
            Jacuzzi jacuzzi;

            public CommandTurnOffJacuzzi(Jacuzzi jacuzzi)
            {
                this.jacuzzi = jacuzzi;
            }

            public void Execute()
            {
                jacuzzi.TurnOff();
            }

            public void Rollback()
            {
                jacuzzi.TurnOn();
            }
        }

        public class Light
        {
            string location;

            public Light() { }

            public Light(string location)
            {
                this.location = location;
            }

            public void TurnOn()
            {
                Console.WriteLine("Światło załączone.");
            }

            public void TurnOff()
            {
                Console.WriteLine("Światło wyłączone.");
            }
        }

        public class CeilingFan
        {
            public const int FAST = 3;
            public const int MEDIUM = 2;
            public const int LOW = 1;
            public const int OFF = 0;
            string location;
            int speed;

            public CeilingFan(string location)
            {
                this.location = location;
                speed = OFF;
            }

            public void HighSpeed()
            {
                speed = FAST;
                Console.WriteLine(location + " wentylator sufitowy włączony na wysokie obroty ");
            }

            public void MediumSpeed()
            {
                speed = MEDIUM;
                Console.WriteLine(location + " wentylator sufitowy włączony na średnie obroty ");
            }

            public void LowSpeed()
            {
                speed = LOW;
                Console.WriteLine(location + " wentylator sufitowy włączony na niskie obroty ");
            }

            public void TurnOff()
            {
                speed = OFF;
                Console.WriteLine(location + " wentylator sufitowy wyłączony ");
            }

            public int GetCurrentSpeed()
            {
                return speed;
            }
        }

        public class SuperRemoteControllerWithRollback
        {
            ICommand[] commandsTurnOn;
            ICommand[] commandsTurnOff;
            ICommand rollbackCommand;


            public SuperRemoteControllerWithRollback()
            {
                commandsTurnOn = new ICommand[7];
                commandsTurnOff = new ICommand[7];

                ICommand noCommand = new NoCommand();
                for (int i = 0; i < 7; i++)
                {
                    commandsTurnOn[i] = noCommand;
                    commandsTurnOff[i] = noCommand;
                }
                rollbackCommand = noCommand;
            }

            public class NoCommand : ICommand
            {
                public void Execute() { }
                public void Rollback() { }
            }

            public void SetCommand(int slot, ICommand turnOnCommand, ICommand turnOffCommand)
            {
                commandsTurnOn[slot] = turnOnCommand;
                commandsTurnOff[slot] = turnOffCommand;
            }

            public void PushedTurnOn(int slot)
            {
                commandsTurnOn[slot].Execute();
                rollbackCommand = commandsTurnOn[slot];
            }

            public void PushedTurnOff(int slot)
            {
                commandsTurnOff[slot].Execute();
                rollbackCommand = commandsTurnOff[slot];
            }

            public void PushedRollBack()
            {
                rollbackCommand.Rollback();
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

        public class MakroCommand : ICommand
        {
            ICommand[] commands;

            public MakroCommand(ICommand[] commands)
            {
                this.commands = commands;
            }

            public void Execute()
            {
                for (int i = 0; i < commands.Length; i++)
                {
                    commands[i].Execute();
                }
            }

            public void Rollback()
            {
                for (int i = 0; i < commands.Length; i++)
                {
                    commands[i].Rollback();
                }
            }
        }
    }

    internal class Jacuzzi
    {
        public void TurnOn()
        {
            Console.WriteLine("Jacuzzi włączone, temp. 30 stopni C");
        }

        public void TurnOff()
        {
            Console.WriteLine("Jacuzzi wyłączone, temp. 23 stopni C");
        }

        public void TurnOnBubbles()
        {
            Console.WriteLine("bąbelki włączone");
        }
    }

    internal class HiFi
    {
        string location;

        public HiFi(string location)
        {
            this.location = location;
        }

        public void TurnOn()
        {
            Console.WriteLine("Wieża włączona");
        }

        public void TurnOff()
        {
            Console.WriteLine("Wieża wyłączona");
        }
    }

    internal class TV
    {
        string location;

        public TV(string location)
        {
            this.location = location;
        }

        public void TurnOn()
        {
            Console.WriteLine("Telewizor włączony");
        }

        public void TurnOff()
        {
            Console.WriteLine("Telewizor wyłączony");
        }

        public void SetSource()
        {
            Console.WriteLine("Telewizor ustawiony na DVD");
        }
    }
}
