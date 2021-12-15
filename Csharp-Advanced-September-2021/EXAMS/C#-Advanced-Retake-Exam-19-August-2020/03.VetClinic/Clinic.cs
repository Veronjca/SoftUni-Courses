using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> pets;

        public Clinic(int capacity)
        {
            this.pets = new List<Pet>();
            this.Capacity = capacity;
        }

        public int Capacity { get; set; }
        public int Count => this.pets.Count;

        public void Add(Pet pet)
        {
            if (this.pets.Count < this.Capacity)
            {
                this.pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet current = this.pets.FirstOrDefault(p => p.Name == name);
            if (current == null)
            {
                return false;
            }
            this.pets.Remove(current);
            return true;
        }

        public Pet GetPet(string name, string owner)
            => this.pets.FirstOrDefault(p => p.Name == name && p.Owner == owner);

        public Pet GetOldestPet()
            => this.pets.OrderByDescending(p => p.Age).FirstOrDefault();

        public string GetStatistics()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("The clinic has the following patients:");

            foreach (var pet in this.pets)
            {
                output.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return output.ToString().Trim();
        }
    }
}
