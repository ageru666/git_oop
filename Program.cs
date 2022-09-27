namespace Lab1_Voloshyn
{

    static class MainMenu
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine("Choose one of the options below.");
            Console.WriteLine("1. Geometry");
            Console.WriteLine("2. Sorting");
            string input = Console.ReadLine();
            switch (input) 
            {
                case "1":
                    //Geometry.AnyAngleInput(); 
                    break;
                case "2":
                    //Sorting.SortingMenu(); 
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
