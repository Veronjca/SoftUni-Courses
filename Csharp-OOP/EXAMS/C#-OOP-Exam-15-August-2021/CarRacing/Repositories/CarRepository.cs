using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> models = new List<ICar>();
        public IReadOnlyCollection<ICar> Models => this.models.AsReadOnly();

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }
            this.models.Add(model);
        }

        public ICar FindBy(string property)
        {
            return this.models.FirstOrDefault(car => car.VIN == property);
        }

        public bool Remove(ICar model)
        {
            return this.models.Remove(model);
        }
    }
}
