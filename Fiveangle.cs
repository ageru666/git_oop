namespace Lab1.Geometry
{
    internal class Fiveangle///class for fiveangle
    {
        uint a, b, c, d, e;
        uint[] sides;
        public uint A { get => a; }
        public uint B { get => b; }
        public uint C { get => c; }
        public uint D { get => d; }
        public uint E { get => e; }

        public Fiveangle(uint a, uint b, uint c, uint d, uint e)///contructor
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.e = e;
            sides = new uint[] { a,b,c,d,e };
        }

        public void CalculateFiveangle()///check for rightness of fiveangle and find area
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
