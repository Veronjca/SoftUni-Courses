using CarRacing.Core.Contracts;
using CarRacing.Models;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars = new CarRepository();
        private RacerRepository racers = new RacerRepository();
        private IMap map = new Map();
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if (type != "SuperCar" && type != "TunedCar")
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }
            ICar current = null;

            if (type == "SuperCar")
            {
                current = new SuperCar(make, model, VIN, horsePower);
            }
            else
            {
                current = new TunedCar(make, model, VIN, horsePower);
            }

            this.cars.Add(current);
            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar currentCar = this.cars.FindBy(carVIN);

            if (currentCar == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            if (type != "ProfessionalRacer" && type != "StreetRacer")
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }         
            IRacer currentRacer = null;

            if (type == "ProfessionalRacer")
            {
                currentRacer = new ProfessionalRacer(username, currentCar);
            }
            else
            {
                currentRacer = new StreetRacer(username, currentCar);
            }

            this.racers.Add(currentRacer);
            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = this.racers.FindBy(racerOneUsername);
            IRacer racerTwo = this.racers.FindBy(racerTwoUsername);

            if (racerOne is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            else if ( racerTwo is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return this.map.StartRace(racerOne, racerTwo);         
        }

        public string Report()
        {
            StringBuilder output = new StringBuilder();
            foreach (var racer in this.racers.Models.OrderByDescending(r => r.DrivingExperience).ThenBy(r => r.Username))
            {
                output.AppendLine(racer.ToString());
            }

            return output.ToString().Trim();
        }

    }
}
