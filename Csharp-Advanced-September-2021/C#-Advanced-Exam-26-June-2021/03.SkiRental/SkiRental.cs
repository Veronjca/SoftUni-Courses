using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> Skies;
        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Skies = new List<Ski>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.Skies.Count;

        public void Add(Ski ski)
        {
            if (this.Skies.Count < Capacity)
            {
                this.Skies.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            int removed = this.Skies.RemoveAll(x => x.Manufacturer == manufacturer && x.Model == model);
            return removed > 0 ? true : false;
        }

        public Ski GetNewestSki()
        {
            return this.Skies.OrderByDescending(x => x.Year).FirstOrDefault();
        }
        public Ski GetSki(string manufacturer, string model)
        {
            return this.Skies.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }
        public string GetStatistics()
        {
            return $"The skis stored in {this.Name}:{Environment.NewLine}{string.Join(Environment.NewLine, this.Skies)}";


        }
    }
}
