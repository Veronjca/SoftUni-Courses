using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private List<string> items = new List<string>();
        public Planet(string name)
        {                    
            this.Name = name;
        }
        public ICollection<string> Items => this.items;

        public string Name 
        { 
            get => this.name; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(this.Name, ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }
        }


    }
}
