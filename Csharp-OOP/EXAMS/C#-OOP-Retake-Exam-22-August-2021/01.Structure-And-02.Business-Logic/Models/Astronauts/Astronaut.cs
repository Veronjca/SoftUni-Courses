using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags.Contracts;
using System;
using SpaceStation.Utilities.Messages;
using SpaceStation.Models.Bags;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private Backpack bag = new Backpack();

        protected int oxygenDecrease = 10;
        public Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(this.Name, ExceptionMessages.InvalidAstronautName);
                }
                this.name = value;
            }
        }

        public double Oxygen
        {
            get => this.oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }
                this.oxygen = value;
            }
        }

        public bool CanBreath => this.Oxygen - oxygenDecrease >= 0 ? true : false;

        public IBag Bag
        {
            get => this.bag;
            private set => this.bag = value as Backpack;
        }

        public virtual void Breath()
        {
            this.Oxygen -= 10;
        }

        public override string ToString()
        {
            return $"Name: {this.Name}{Environment.NewLine}Oxygen: {this.Oxygen}{Environment.NewLine}{this.Bag.ToString()}";
        }
    }
}
