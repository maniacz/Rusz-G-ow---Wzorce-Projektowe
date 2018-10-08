using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            //PancakeHouseMenu pancakeHouseMenu = new PancakeHouseMenu();
            //DinerMenu dinerMenu = new DinerMenu();
            IMenu pancakeHouseMenu = new PancakeHouseMenu();
            DinerMenu dinerMenu = new DinerMenu();
            Waitress waitress = new Waitress(pancakeHouseMenu, dinerMenu);
            waitress.PrintMenu();

            Console.ReadKey();
        }
    }

    public class MenuEntry
    {
        string name;
        string description;
        bool vegetarian;
        double price;

        public MenuEntry(string name, string description, bool vegetarian, double price)
        {
            this.name = name;
            this.description = description;
            this.vegetarian = vegetarian;
            this.price = price;
        }

        public string GetName()
        {
            return name;
        }

        public string GetDescription()
        {
            return description;
        }

        public double GetPrice()
        {
            return price;
        }

        public bool IsVegetarian()
        {
            return vegetarian;
        }
    }

    public class PancakeHouseMenu : IMenu
    {
        List<MenuEntry> menuEntries;

        public PancakeHouseMenu()
        {
            menuEntries = new List<MenuEntry>();
            AddElement("Śniadanie naleśnikowe K&B", "Naleśniki z jajecznicą i tostem", true, 2.99);
            AddElement("Śniadanie naleśnikowe zwykłe", "Naleśniki z jajkiem sadzonym i kiełbasą", false, 2.99);
            AddElement("Naleśniki z jagodami", "Naleśniki ze świeżymi jagodami ", true, 3.49);
            AddElement("Wafle nadziewane", "Wafle z jagodami lub truskawkami", true, 3.59);
        }

        private void AddElement(string name, string desc, bool vege, double price)
        {
            MenuEntry menuEntry = new MenuEntry(name, desc, vege, price);
            menuEntries.Add(menuEntry);
        }

        public List<MenuEntry> GetMenuEntries()
        {
            return menuEntries;
        }

        /*DEPRECIATED
        public IIterator CreateIterator()
        {
            return new PancakeHouseMenuIterator(menuEntries);
        }
        */

        public List<MenuEntry>.Enumerator CreateIterator()
        {
            return menuEntries.GetEnumerator();
        }

        IIterator IMenu.CreateIterator()
        {
            return menuEntries.GetEnumerator();
        }
    }

    public class DinerMenu
    {
        const int MAX_ELEMENT_COUNT = 6;
        int elementCount = 0;
        MenuEntry[] menuEntries;

        public DinerMenu()
        {
            menuEntries = new MenuEntry[MAX_ELEMENT_COUNT];
            AddElement("Wegetariańska kanapka BSP", "(Wegetariański) Boczek z sałątą i pomidorem, chleb pszenny pełnoziarnisty", true, 2.99);
            AddElement("Kanapka BSP", "Boczek z sałątą i pomidorem, chleb pszenny pełnoziarnisty", false, 2.99);
            AddElement("Zupa dnia", "Zupa dnia i sałatka z pomidora", false, 3.29);
            AddElement("Hot-dog", "Hot-dog z kiszoną kapustą, rzodkiewką, cebulą i dodatkiem sera", false, 3.05);
        }

        private void AddElement(string name, string desc, bool vege, double price)
        {
            MenuEntry menuEntry = new MenuEntry(name, desc, vege, price);
            if (elementCount >= MAX_ELEMENT_COUNT)
                Console.WriteLine("Niestety, menu jest pełne! Nie można dodać nowej pozycji");
            else
                menuEntries[elementCount++] = menuEntry;
        }

        /* DEPRECIATED
        public MenuEntry[] GetMenuEntries()
        {
            return menuEntries;
        }
        */

        public IIterator CreateIterator()
        {
            return new DinerMenuIterator(menuEntries);
        }
    }

    public interface IIterator
    {
        bool HasNext();
        Object Next();
    }

    public class DinerMenuIterator : IIterator
    {
        MenuEntry[] elements;
        int position = 0;

        public DinerMenuIterator(MenuEntry[] elements)
        {
            this.elements = elements;
        }

        public bool HasNext()
        {
            if (position >= elements.Length || elements[position] == null)
                return false;
            else
                return true;
        }

        public object Next()
        {
            MenuEntry menuEntry = elements[position++];
            return menuEntry;
        }

        public void Remove()
        {
            if (position <= 0)
            {
                throw new IndexOutOfRangeException("Nie możesz usunąć elementu przed pierwszym wywołaniem metody Next()");
            }
            if (elements[position - 1] != null)
            {
                for (int i = position - 1; i < (elements.Length - 1); i++)
                {
                    elements[i] = elements[i + 1];
                }
                elements[elements.Length - 1] = null;
            }
        }
    }

    public class PancakeHouseMenuIterator : IIterator
    {
        List<MenuEntry> elements;
        int position = 0;

        public PancakeHouseMenuIterator(List<MenuEntry> elements)
        {
            this.elements = elements;
        }

        public bool HasNext()
        {
            if (position >= elements.Count || elements.ElementAt(position) == null)
                return false;
            else
                return true;
        }

        public object Next()
        {
            return elements.ElementAt(position++);
        }
    }

    public class Waitress
    {
        /* DEPRECIATED
        PancakeHouseMenu pancakeHouseMenu;
        DinerMenu dinerMenu;
        */
        IMenu pancakeHouseMenu;
        IMenu dinerMenu;

        /* DEPRECIATED
        public Waitress(PancakeHouseMenu pancakeHouseMenu, DinerMenu dinerMenu)
        {
            this.pancakeHouseMenu = pancakeHouseMenu;
            this.dinerMenu = dinerMenu;
        }
        */

        public Waitress(IMenu pancakeHouseMenu, IMenu dinerMenu)
        {
            this.pancakeHouseMenu = pancakeHouseMenu;
            this.dinerMenu = dinerMenu;
        }

        public void PrintMenu()
        {
            IIterator pancakeIterator = pancakeHouseMenu.CreateIterator();
            IIterator dinerIterator = dinerMenu.CreateIterator();

            Console.WriteLine("MENU\n----\nŚNIADANIA");
            PrintMenu(pancakeIterator);
            Console.WriteLine("\nLUNCH");
            PrintMenu(dinerIterator);
        }

        private void PrintMenu(IIterator iterator)
        {
            while (iterator.HasNext())
            {
                MenuEntry menuEntry = (MenuEntry)iterator.Next();
                Console.WriteLine(menuEntry.GetName() + ", ");
                Console.WriteLine(menuEntry.GetPrice() + " -- ");
                Console.WriteLine(menuEntry.GetDescription());
            }
        }
    }

    public interface IMenu
    {
        IIterator CreateIterator();
    }
}
