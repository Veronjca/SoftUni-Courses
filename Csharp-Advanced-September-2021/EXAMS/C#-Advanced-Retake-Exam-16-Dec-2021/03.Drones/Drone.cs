using System;

namespace Drones
{
    public class Drone
    {
        private string name;
        private string brand;
        private int range;
        private bool available = true;
        public Drone(string name, string brand, int range)
        {
            this.Name = name;
            this.Brand = brand;
            this.Range = range;
        }
        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
            }
        }
        public string Brand
        {
            get => this.brand;
            set
            {
                this.brand = value;
            }
        }
        public int Range
        {
            get => this.range;
            set
            {
                this.range = value;
            }
        }

        public bool Available
        {
            get => this.available;
            set
            {
                this.available = value;
            }
        }

        public override string ToString()
        {
            return $"Drone: {this.Name}{Environment.NewLine}Manufactured by: {this.Brand}{Environment.NewLine}Range: {this.Range} kilometers";
        }
    }
}
