using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fascade
{
    class Program
    {
        public class HomeCinemaFascadeTest
        {
            static void Main(string[] args)
            {
                Amplifier amplifier = new Amplifier();
                Tuner tuner = new Tuner();
                DVD dvd = new DVD();
                CD cd = new CD();
                Projector projector = new Projector();
                CinemaLights lights = new CinemaLights();
                Screen screen = new Screen();
                PopcornMachine popcorn = new PopcornMachine();

                HomeCinemaFascade homeCinema = new HomeCinemaFascade(amplifier, tuner, dvd, cd, projector, lights, screen, popcorn);
                homeCinema.DisplayMovie("Poszukiwacze zaginionej arki");
                homeCinema.FinishWatching();

                Console.ReadKey();
            }
        }

        public class HomeCinemaFascade
        {
            Amplifier amplifier;
            Tuner tuner;
            DVD dvd;
            CD cd;
            Projector projector;
            CinemaLights lights;
            Screen screen;
            PopcornMachine popcorn;

            public HomeCinemaFascade(Amplifier amplifier, Tuner tuner, DVD dvd, CD cd, Projector projector, CinemaLights lights, Screen screen, PopcornMachine popcorn)
            {
                this.amplifier = amplifier;
                this.tuner = tuner;
                this.dvd = dvd;
                this.cd = cd;
                this.projector = projector;
                this.lights = lights;
                this.screen = screen;
                this.popcorn = popcorn;
            }

            public void DisplayMovie(string movie)
            {
                Console.WriteLine("---- Przygotuj się na seans filmowy ----");
                popcorn.TurnOn();
                popcorn.PreparePopcorn();
                lights.Dimm(10);
                screen.MoveDown();
                projector.TurnOn();
                projector.TurnWideScreenMode();
                amplifier.TurnOn();
                amplifier.SetDolbySurround();
                amplifier.SetVolume(5);
                dvd.TurnOn();
                dvd.Play(movie);
            }

            public void FinishWatching()
            {
                Console.WriteLine("---- Koniec seansu, wyłączam kino domowe ----");
                popcorn.TunrOff();
                lights.TurnOn();
                screen.MoveUp();
                projector.TurnOn();
                amplifier.TurnOff();
                dvd.Stop();
                dvd.EjectDisc();
                dvd.TurnOff();
            }
        }

    }

    internal class PopcornMachine
    {
        string name;

        public PopcornMachine()
        {
            name = this.GetType().Name;
        }

        internal void PreparePopcorn()
        {
            Console.WriteLine(name + ": popcorn w drodze.");
        }

        internal void TunrOff()
        {
            Console.WriteLine(name + ": maszynka do popcornu wyłączona");
        }

        internal void TurnOn()
        {
            Console.WriteLine(name + ": maszynka do popcornu załączona");
        }
    }

    internal class Screen
    {
        string name;

        public Screen()
        {
            name = this.GetType().Name;
        }

        internal void MoveDown()
        {
            Console.WriteLine(name + ": opuszczony");
        }

        internal void MoveUp()
        {
            Console.WriteLine(name + ": podniesiony");
        }
    }

    internal class CinemaLights
    {
        string name;

        public CinemaLights()
        {
            name = this.GetType().Name;
        }

        internal void Dimm(int v)
        {
            Console.WriteLine(name + ": przyciemniony na " + v);
        }

        internal void TurnOn()
        {
            Console.WriteLine(name + ": załączony");
        }
    }

    internal class Projector
    {
        string name;

        public Projector()
        {
            name = this.GetType().Name;
        }

        internal void TurnOn()
        {
            Console.WriteLine(name + ": załączony");
        }

        internal void TurnWideScreenMode()
        {
            Console.WriteLine(name + ": uruchomiony tryb szerokoekranowy");
        }
    }

    internal class CD
    {
    }

    internal class DVD
    {
        string movie;
        string name;

        public DVD()
        {
            name = this.GetType().Name;
        }

        internal void EjectDisc()
        {
            Console.WriteLine(name + ": wysuwanie dysku DVD");
        }

        internal void Play(string movie)
        {
            Console.WriteLine(name + ": odtwarzanie filmu " + movie);
            this.movie = movie;
        }

        internal void Stop()
        {
            Console.WriteLine(name + ": koniec odtwarzania filmu " + movie);
        }

        internal void TurnOff()
        {
            Console.WriteLine(name + ": wyłączony");
        }

        internal void TurnOn()
        {
            Console.WriteLine(name + ": załączony");
        }
    }

    internal class Tuner
    {
    }

    internal class Amplifier
    {
        string name;

        public Amplifier()
        {
            name = this.GetType().Name;
        }

        internal void SetDolbySurround()
        {
            Console.WriteLine(name + ": włączono dźwięk przestrzenny");
        }

        internal void SetVolume(int v)
        {
            Console.WriteLine(name + ": ustawiono głośność na " + v);
        }

        internal void TurnOff()
        {
            Console.WriteLine(name + ": wyłączony");
        }

        internal void TurnOn()
        {
            Console.WriteLine(name + ": załączony");
        }
    }

}
