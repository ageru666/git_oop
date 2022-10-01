using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Voloshin.Geometry
{
    internal class Fourangle
    {
        uint a, b, c, d;
        uint[] sides;
        public uint A { get => a; }
        public uint B { get => b; }
        public uint C { get => c; }
        public uint D { get => d; }

        public Fourangle(uint a, uint b, uint c, uint d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            sides = new uint[] { a,b,c,d };
        }
        public void CalculateFourangle()
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


    }
}
