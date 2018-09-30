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

        static void Main()
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
    }
}
