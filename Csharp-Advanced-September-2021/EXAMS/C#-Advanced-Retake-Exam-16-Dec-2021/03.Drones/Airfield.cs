using System;
using System.Collections.Generic;
using System.Linq;

namespace Drones
{
    public class Airfield
    {
        private List<Drone> drones;
        private string name;
        private int capacity;
        private double landingStrip;
        public Airfield(string name, int capacity, double landingStrip)
        {           
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.drones = new List<Drone>();
        }

        public IReadOnlyCollection<Drone> Drones => this.drones.AsReadOnly();
        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
            }
        }
        public int Capacity
        {
            get => this.capacity;
            set
            {
                this.capacity = value;
            }
        }
        public double LandingStrip
        {
            get => this.landingStrip;
            set
            {
                this.landingStrip = value;
            }
        }
        public int Count => this.drones.Count;

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name))
            {
                return "Invalid drone.";
            }
            if (string.IsNullOrEmpty(drone.Brand))
            {
                return "Invalid drone.";
            }
            if (drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            if (this.drones.Count == this.Capacity)
            {
                return "Airfield is full.";
            }

            this.drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            Drone current = this.drones.FirstOrDefault(d => d.Name == name);
            if (current == null)
            {
                return false;
            }
            return this.drones.Remove(current);
        }

        public int RemoveDroneByBrand(string brand)
            => this.drones.RemoveAll(d => d.Brand == brand);

        public Drone FlyDrone(string name)
        {
            Drone current = this.Drones.FirstOrDefault(d => d.Name == name);
            if (current != null)
            {
                current.Available = false;
            }
            return current;           
        }

        public List<Drone> FlyDronesByRange(int range)
        {           
            foreach (var drone in this.Drones.Where(d => d.Range >= range).ToList())
            {
                drone.Available = false;
            }

            return this.Drones.Where(d => d.Range >= range && d.Available == false).ToList();
        }

        public string Report()
        {
            return $"Drones available at {this.Name}:{Environment.NewLine}{string.Join(Environment.NewLine, this.Drones.Where(d => d.Available == true))}";
        }
    }
}
