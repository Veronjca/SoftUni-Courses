using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> models = new List<IRacer>();
        public IReadOnlyCollection<IRacer> Models => this.models.AsReadOnly();

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }
            this.models.Add(model);
        }

        public IRacer FindBy(string property)
        {
            return this.models.FirstOrDefault(r => r.Username == property);
        }

        public bool Remove(IRacer model)
        {
            return this.models.Remove(model);
        }
    }
}
