using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> Racers;
        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Racers = new List<Racer>();
        }      
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.Racers.Count;

        public void Add(Racer racer)
        {
            if (this.Racers.Count < this.Capacity)
            {
                this.Racers.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            int removed = this.Racers.RemoveAll(x => x.Name == name);
            if (removed == 0)
            {
                return false;
            }

            return true;
        }

        public Racer GetOldestRacer()
        {
            return this.Racers.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public Racer GetRacer(string name)
        {
            return this.Racers.FirstOrDefault(x => x.Name == name);
        }

        public Racer GetFastestRacer()
        {
            return this.Racers.OrderByDescending(x => x.Car.Speed).FirstOrDefault();
        }

        public string Report()
        {
            return $"Racers participating at {this.Name}:{Environment.NewLine}{String.Join(Environment.NewLine, this.Racers)}";
        }
    }
}
