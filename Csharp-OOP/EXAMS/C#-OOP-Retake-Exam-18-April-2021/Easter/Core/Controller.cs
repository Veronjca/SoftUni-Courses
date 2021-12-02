using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private IRepository<IBunny> bunnies = new BunnyRepository();
        private IRepository<IEgg> eggs = new EggRepository();
        private int countOfColoredEggs;
        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType != "HappyBunny" && bunnyType != "SleepyBunny")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            IBunny bunny = null;
            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else
            {
                bunny = new SleepyBunny(bunnyName);
            }

            this.bunnies.Add(bunny);
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = this.bunnies.FindByName(bunnyName);
            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            IDye dye = new Dye(power);
            bunny.AddDye(dye);
            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            this.eggs.Add(egg);
            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            IWorkshop workshop = new Workshop();
            IEgg egg = this.eggs.FindByName(eggName);
            var suitableBunnies = this.bunnies.Models.Where(b => b.Energy >= 50).ToList();

            if (suitableBunnies.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            foreach (var bunny in this.bunnies.Models.Where(b => b.Energy >= 50).OrderByDescending(b => b.Energy))
            {
                workshop.Color(egg, bunny);
                if (egg.IsDone())
                {
                    break;
                }
            }

            if (egg.IsDone())
            {
                countOfColoredEggs++;
                return String.Format(OutputMessages.EggIsDone, eggName);
            }

            return string.Format(OutputMessages.EggIsNotDone, eggName);           
        }

        public string Report()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"{this.countOfColoredEggs} eggs are done!");
            output.AppendLine("Bunnies info:");

            foreach (var bunny in this.bunnies.Models.Where(b => b.Energy > 0))
            {
                output.AppendLine(bunny.ToString());
            }

            return output.ToString().Trim();
        }
    }
}
