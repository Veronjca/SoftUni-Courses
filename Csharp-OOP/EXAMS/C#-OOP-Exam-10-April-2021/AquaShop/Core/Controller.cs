using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private IRepository<IDecoration> decorations = new DecorationRepository();
        private List<IAquarium> aquariums = new List<IAquarium>(); 
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium currentAquarium = null;
            switch (aquariumType)
            {
                case "FreshwaterAquarium":
                    currentAquarium = new FreshwaterAquarium(aquariumName);
                    break;
                case "SaltwaterAquarium":
                    currentAquarium = new SaltwaterAquarium(aquariumName);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            this.aquariums.Add(currentAquarium);
            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration currentDecoration = null;
            switch (decorationType)
            {
                case "Ornament":
                    currentDecoration = new Ornament();
                    break;
                case "Plant":
                    currentDecoration = new Plant();
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            this.decorations.Add(currentDecoration);
            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish currentFish = null;
            switch (fishType)
            {
                case "FreshwaterFish":
                    currentFish = new FreshwaterFish(fishName, fishSpecies, price);
                    break;
                case "SaltwaterFish":
                    currentFish = new SaltwaterFish(fishName, fishSpecies, price);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IAquarium currentAquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if (fishType == "FreshwaterFish" && currentAquarium.GetType().Name != nameof(FreshwaterAquarium))
            {
                return OutputMessages.UnsuitableWater;
            }
            else if (fishType == "SaltwaterFish" && currentAquarium.GetType().Name!= nameof(SaltwaterAquarium))
            {
                return OutputMessages.UnsuitableWater;
            }
          
            currentAquarium.AddFish(currentFish);

            return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium currentAquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            decimal value = currentAquarium.Fish.Sum(f => f.Price) + currentAquarium.Decorations.Sum(d => d.Price);
            return string.Format(OutputMessages.AquariumValue, aquariumName, value);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium currentAquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            currentAquarium.Feed();
            return string.Format(OutputMessages.FishFed, currentAquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration currentDecoration = this.decorations.FindByType(decorationType);
            if (currentDecoration == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            aquarium.Decorations.Add(currentDecoration);
            this.decorations.Remove(currentDecoration);
            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder output = new StringBuilder();
            foreach ( var aquarium in this.aquariums)
            {
                output.AppendLine(aquarium.GetInfo());
            }

            return output.ToString().Trim();
        }
    }
}
