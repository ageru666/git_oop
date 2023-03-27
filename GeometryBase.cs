namespace Lab1.Geometry
{
    internal class GeometryBase///class manager for using geometry
    {
        static uint[] sides;
        static float[] nAngleVectors;

        public static void AnyAngleInput() /// entry point
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
                Array.Resize<float>(ref nAngleVectors, Convert.ToInt32(n));
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"Enter {i + 1} vector counterclock-wise: "); //координаты многоугольника против часовой стрелки
                    if (!float.TryParse(Console.ReadLine(), out nAngleVectors[i]))
                    {
                        Console.WriteLine("Wrong input.");
                        return;
                    }
                }
                Polygon polygon = new Polygon(nAngleVectors);
                Console.WriteLine("Area is: " + polygon.GetArea());
            }
        }
        static void CalculatePerimeterAndArea()/// calculate perimeter and area
        {
            uint P = 0;
            foreach (var item in sides)
                P += item;

            Console.WriteLine($"Perimeter of your figure is: {P}");


            switch (sides.Count())
            {
                case 3:
                    Triangle triangle = new Triangle(ref sides);
                    triangle.CalculateTriangle();
                    break;
                case 4:
                    Fourangle fourangle = new Fourangle(sides[0], sides[1], sides[2], sides[3]);
                    fourangle.CalculateFourangle();
                    break;
                case 5:
                    Fiveangle fiveangle = new Fiveangle(sides[0], sides[1], sides[2], sides[3], sides[4]);
                    fiveangle.CalculateFiveangle();
                    break;
                default:
                    break;
            }
        }
    }
}
