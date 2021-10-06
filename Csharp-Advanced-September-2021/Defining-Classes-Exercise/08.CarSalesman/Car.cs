using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; } = "n/a";
        public string Color { get; set; } = "n/a";

        public override string ToString()
        {
            return $"{this.Model}:\n  {this.Engine}\n  Weight: {this.Weight}\n  Color: {this.Color}";
        }
    }
}
