using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizzeria wloska = new WloskaPizzeria();
            Pizzeria amerykanska = new AmerykanskaPizzeria();

            Pizza pizza = wloska.ZamowPizza("serowa");
            Console.WriteLine("Eryk zamówił: " + pizza.PobierzNazwa());

            pizza = amerykanska.ZamowPizza("serowa");
            Console.WriteLine("Jacek zamówił: " + pizza.PobierzNazwa());

            Console.ReadKey();
        }

        public abstract class Pizzeria
        {
            public Pizza ZamowPizza(string typ)
            {
                Pizza pizza;
                pizza = UtworzPizza(typ);

                pizza.Przygotowanie();
                pizza.Pieczenie();
                pizza.Krojenie();
                pizza.Pakowanie();

                return pizza;
            }

            protected abstract Pizza UtworzPizza(string typ);
        }

        public abstract class Pizza
        {
            protected string nazwa;
            protected string ciasto;
            protected string sos;
            protected Warzywa[] warzywa;
            protected Ser ser;
            protected Pepperoni pepperoni;
            protected Malze malze;

            protected abstract void Przygotowanie();

            public void Pieczenie()
            {
                Console.WriteLine("Pieczenie 25 minut w temperaturze 350 stopni Celsjusza.");
            }

            public virtual void Krojenie()
            {
                Console.WriteLine("Krojenie pizzy na 8 kawałków.");
            }

            public void Pakowanie()
            {
                Console.WriteLine("Pakowanie pizzy w oficjalne pudełko naszej Pizzerii.");
            }

            public string PobierzNazwa()
            {
                return nazwa;
            }
        }

        public class WloskaPizzeria : Pizzeria
        {
            protected override Pizza UtworzPizza(string typ)
            {
                if (typ.Equals("serowa"))
                {
                    return new WloskaSerowaPizza();
                }
                /*
                else if (typ.Equals("wegetarianska"))
                {
                    return new WloskaWegetarianskaPizza();
                }
                else if (typ.Equals("owoce morza"))
                {
                    return new WloskaOwoceMorzaPizza();
                }
                */
                else
                    return null;
            }
        }

        public class AmerykanskaPizzeria : Pizzeria
        {
            protected override Pizza UtworzPizza(string typ)
            {
                if (typ.Equals("serowa"))
                {
                    return new AmerykanskaSerowaPizza();
                }
                /*
                else if (typ.Equals("wegetarianska"))
                {
                    return new WloskaWegetarianskaPizza();
                }
                else if (typ.Equals("owoce morza"))
                {
                    return new WloskaOwoceMorzaPizza();
                }
                */
                else
                    return null;
            }
        }

        public class WloskaSerowaPizza : Pizza
        {
            public WloskaSerowaPizza()
            {
                nazwa = "Włoska pizza serowa z sosem Marinara";
                ciasto = "Cienkie kruche ciasto";
                sos = "Sos Marinara";

                dodatki.Add("Tarty ser Reggiano");
            }
        }

        public class AmerykanskaSerowaPizza : Pizza
        {
            public AmerykanskaSerowaPizza()
            {
                nazwa = "Amerykanska pizza serowa";
                ciasto = "Extra grube, chrupkie ciasto";
                sos = "Sos z pomidorów śliwkowych";

                dodatki.Add("Grubo tarty ser Mozarella");
            }

            public override void Krojenie()
            {
                Console.WriteLine("Krojenie pizzy na kwadratowe kawałki.");
            }
        }

        public interface FabrykaSkladnikowPizzy
        {
            Ciasto UtworzCiasto();
            Sos UtworzSos();
            Ser UtworzSer();
            Warzywa[] UtworzWarzywa();
            Pepperoni UtworzPepperoni();
            Malze UtworzMalze();
        }

        public class WloskaFabrykaSkladnikowPizzy : FabrykaSkladnikowPizzy
        {
            public Ciasto UtworzCiasto()
            {
                return new CienkieChrupkieCiasto();
            }

            public Malze UtworzMalze()
            {
                return new SwiezeMalze();
            }

            public Pepperoni UtworzPepperoni()
            {
                return new PlastryPepperoni();
            }

            public Ser UtworzSer()
            {
                return new SerReggiano();
            }

            public Sos UtworzSos()
            {
                return new SosMarinara();
            }

            public Warzywa[] UtworzWarzywa()
            {
                Warzywa[] warzywa = { new Czosnek(), new Cebula(), new Pieczarki(), new CzerwonaPapryka() };
                return warzywa;
            }
        }

        public class AmerykanskaFabrykaSkladnikowPizzy : FabrykaSkladnikowPizzy
        {
            public Ciasto UtworzCiasto()
            {
                return new GrubeChrupkieCiasto();
            }

            public Malze UtworzMalze()
            {
                return new MrozoneMalze();
            }

            public Pepperoni UtworzPepperoni()
            {
                return new PlastryPepperoni();
            }

            public Ser UtworzSer()
            {
                return new SerMozarella();
            }

            public Sos UtworzSos()
            {
                return new SosPomidorowy();
            }

            public Warzywa[] UtworzWarzywa()
            {
                Warzywa[] warzywa = { new CzarneOliwki(), new Szpinak(), new Baklazan() };
                return warzywa;
            }
        }

        public class Ciasto
        {
        }
        public class Sos
        {
        }

        public class Ser
        {
        }

        public class Warzywa
        {
        }

        public class Pepperoni
        {
        }

        public class Malze
        {
        }

        private class Cebula : Warzywa
        {
        }

        private class CienkieChrupkieCiasto : Ciasto
        {
        }

        private class CzerwonaPapryka : Warzywa
        {
        }

        private class Czosnek : Warzywa
        {
        }

        private class Pieczarki : Warzywa
        {
        }

        private class PlastryPepperoni : Pepperoni
        {
        }

        private class SerReggiano : Ser
        {
        }

        private class SosMarinara : Sos
        {
        }

        private class SwiezeMalze : Malze
        {
        }

        private class Baklazan : Warzywa
        {
        }

        private class CzarneOliwki : Warzywa
        {
        }

        private class Szpinak : Warzywa
        {
        }

        private class GrubeChrupkieCiasto : Ciasto
        {
        }

        private class MrozoneMalze : Malze
        {
        }

        private class SerMozarella : Ser
        {
        }

        private class SosPomidorowy : Sos
        {
        }
    }
}
