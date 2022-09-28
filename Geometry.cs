namespace Lab1
{
    internal class Geometry
    {
        static uint[] sides;
       
       

        public static void AnyAngleInput() // entry point
        {
            uint n;
            Console.WriteLine("How much angles do you want?:");
            if (!uint.TryParse(Console.ReadLine(), out n))
            {
                Console.Clear();
                Console.WriteLine("Wrong input.");
                return;
            }
            if (n > int.MaxValue)
            {
                Console.WriteLine("To much angles, cutting. (Overflow)");
                n = int.MaxValue;
            }

            Console.WriteLine($"Input {n} sides (in cm).");

            if (n < 6) // если у нас фигуры до 5 углов то сюда
            {
                Array.Resize<uint>(ref sides, Convert.ToInt32(n));
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"Enter {i + 1} side: ");
                    if (!uint.TryParse(Console.ReadLine(), out sides[i]))
                    {
                        Console.Clear();
                        Console.WriteLine("Wrong input.");
                        return;
                    }
                }
                foreach (var item in sides)
                {
                    Console.WriteLine($"Your sides is: {item} ");
                }
                CalculatePerimeterAndArea();
            }
            else// если больше 5-ти углов то сюда
            {
        
                Console.WriteLine("Not implemented");
                return;
            }
            
        }


        static void CalculatePerimeterAndArea()
        {
            uint P = 0;
            foreach (var item in sides)
                P += item;

            Console.WriteLine($"Perimeter of your figure is: {P}");


            switch (sides.Count())
            {
                case 3:
                    CalculateTriangle(ref P);
                    break;
                case 4:
                    CalculateFourangle();
                    break;
                case 5:
                    CalculateFiveangle();
                    break;
                default:
                    break;
            }
        }

        static void CalculateTriangle(ref uint P)
        {
            double p = P / 2;
            double S = Math.Sqrt(p * (p - sides[0]) * (p - sides[1]) * (p - sides[2]));
            Console.WriteLine($"Area of your triangle is: {S}  square cm");

            if (sides[0] == sides[1] && sides[1] == sides[2])
            {
                Console.WriteLine($"Your figure is an equilateral triangle."); // равносторонний треугольник
                return;
            }

            if (sides[0] == sides[1] || sides[1] == sides[2] || sides[0] == sides[2])
            {
                Console.WriteLine($"Your figure is an isosceles triangle."); // равнобедренный треугольник
                return;
            }

            int biggestValIndex = Array.IndexOf<uint>(sides, sides.Max());
            if (Math.Pow(sides[biggestValIndex], 2) == ((Math.Pow(sides[0], 2)) + Math.Pow(sides[1], 2) + Math.Pow(sides[2], 2) - Math.Pow(sides[biggestValIndex], 2)))
                Console.WriteLine($"Your figure is an right triangle."); // прямоугольный треугольник    
        }
        static void CalculateFourangle()
        {
            if (sides[0] == sides[1] && sides[2] == sides[3] && sides[0] == sides[3])
            {
                Console.WriteLine($"Your figure is an square.");
                Console.WriteLine($"Area of your square is: {Math.Pow(sides[0], 2)} square cm");
                return;
            }

            if ((sides[0] == sides[1] && sides[2] == sides[3]) || (sides[1] == sides[3] && sides[0] == sides[2]) || (sides[1] == sides[2] && sides[3] == sides[0]))
            {
                Console.WriteLine($"Your figure is an Rectangle.");
                Console.WriteLine($"Area of your Rectangle is: {sides.Max() * sides.Min()} square cm");
                return;
            }

            Console.WriteLine($"Your figure is an Trapezoid.");
        }
        static void CalculateFiveangle()
        {
            if (sides[0] == sides[1] && sides[0] == sides[2] && sides[0] == sides[3] && sides[0] == sides[4])
            {
                Console.WriteLine($"Your figure is an right fiveangle.");
                double S = Math.Sqrt(((Math.Pow(sides[0], 2) + (sides[0] * 2) * Math.Sqrt(sides[0])) / 4) * Math.Pow(sides[0], 2));
                Console.WriteLine($"Area of your fiveangle is: {S}  square cm");
            }
            else
                Console.WriteLine($"Your figure is not right fiveangle. (Not all sides are the same)");
        }
    }
}
