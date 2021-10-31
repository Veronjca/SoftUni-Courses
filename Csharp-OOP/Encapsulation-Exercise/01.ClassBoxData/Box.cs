using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length 
        { 
            get => length;
            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Length cannot be zero or negative.");
                    return;
                }
                length = value;
            }
        }
        public double Width 
        { 
            get => width; 
            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Width cannot be zero or negative.");
                    return;
                }
                width = value;
            }
        }
        public double Height 
        { 
            get => height; 
            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Height cannot be zero or negative.");
                    return;
                }
                height = value;
            }
        }

        public double CalculateSurfaceArea()
        {
            return (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        }

        public double CalculateLateralSurfaceArea()
        {
            return (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        }

        public double Volume()
        {
            return this.Length * this.Width * this.Height;
        }
    }
}
