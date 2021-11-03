using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private int radius;

        public Circle(int radius)
        {
            this.Radius = radius;
        }
        public int Radius { get; private set; }
        public void Draw()
        {
            double @in = this.Radius - 0.4;
            double @out = this.Radius + 0.4;
            for (double y = this.Radius; y >= -this.Radius; --y)
            {
                for (double x = -this.Radius; x < @out; x+= 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= @in * @in && value <= @out * @out)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
