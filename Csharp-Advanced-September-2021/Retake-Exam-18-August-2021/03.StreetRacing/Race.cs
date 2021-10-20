using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
            this.Participants = new List<Car>();
        }
        public List<Car> Participants { get; private set; } 
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public int Count => Participants.Count;

        public void Add(Car currentCar)
        {
            if (!this.Participants.Exists(car => car.LicensePlate == currentCar.LicensePlate) && this.Participants.Count < this.Capacity && currentCar.HorsePower <= this.MaxHorsePower)
            {
                this.Participants.Add(currentCar);
            }
        }

        public bool Remove(string licensePlate)
        {
            int removed = this.Participants.RemoveAll(car => car.LicensePlate == licensePlate);
            if (removed == 0)
            {
                return false;
            }

            return true;
        }

        public Car FindParticipant(string licensePlate)
        {
            return this.Participants.Find(car => car.LicensePlate == licensePlate);
        }

        public Car GetMostPowerfulCar()
        {
            int maxHorsePower = int.MinValue;

            for (int i = 0; i < this.Participants.Count; i++)
            {
                if (this.Participants[i].HorsePower > maxHorsePower)
                {
                    maxHorsePower = this.Participants[i].HorsePower;
                }
            }

            if (maxHorsePower != int.MinValue)
            {
                return this.Participants.Find(car => car.HorsePower == maxHorsePower);
            }

            return null;
        }

        public string Report()
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var participant in Participants)
            {
                info.AppendLine(participant.ToString());
            }
            return info.ToString().TrimEnd();



        }
    }
}
