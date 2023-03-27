using Lab1.Geometry;

//implementation of sorting was made with help of Yurii Kyrpotenko

namespace Lab1
{

    static class MainMenu///class menu with options(sorting or geometry)
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()//menu
        {
            Console.WriteLine("Choose one of the options below.");
            Console.WriteLine("1. Geometry");
            Console.WriteLine("2. Sorting");
            string input = Console.ReadLine();
            switch (input) // 8 stars total
            {
                case "1":
                    GeometryBase.AnyAngleInput(); //**
                    break;
                case "2":
                    SortManager.SortMenuSwitcher(); // ******
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Try again.\n");
                    break;
            }
            Menu();
        }
    }
}
