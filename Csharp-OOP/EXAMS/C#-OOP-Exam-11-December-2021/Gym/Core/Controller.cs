using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private IRepository<IEquipment> equipment = new EquipmentRepository();
        private ICollection<IGym> gyms = new List<IGym>();

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete currentAthlete = null;
            IGym currentGym = this.gyms.FirstOrDefault(g => g.Name == gymName); 

            switch (athleteType)
            {
                case "Boxer":
                    currentAthlete = new Boxer(athleteName, motivation, numberOfMedals);
                    break;
                case "Weightlifter":
                    currentAthlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            if (athleteType == "Boxer" && currentGym.GetType().Name != "BoxingGym")
            {
                return OutputMessages.InappropriateGym;
            }
            if (athleteType == "Weightlifter" && currentGym.GetType().Name != "WeightliftingGym")
            {
                return OutputMessages.InappropriateGym;
            }

            currentGym.AddAthlete(currentAthlete);
            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment current = null;
            switch (equipmentType)
            {
                case "BoxingGloves":
                    current = new BoxingGloves();
                    break;
                case "Kettlebell":
                    current = new Kettlebell();
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
            this.equipment.Add(current);

            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym current = null;
            switch (gymType)
            {
                case "BoxingGym":
                    current = new BoxingGym(gymName);
                    break;
                        case "WeightliftingGym":
                    current = new WeightliftingGym(gymName);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
            this.gyms.Add(current);

            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym currentGym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            double result = currentGym.EquipmentWeight;
            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, result);

        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment currentEquipment = this.equipment.FindByType(equipmentType);
            IGym currentGym = this.gyms.FirstOrDefault(g => g.Name == gymName);

            if (currentEquipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }
            currentGym.AddEquipment(currentEquipment);
            this.equipment.Remove(currentEquipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder output = new StringBuilder();
            foreach (var gym in this.gyms)
            {
                output.AppendLine(gym.GymInfo());
            }

            return output.ToString().Trim();
        }

        public string TrainAthletes(string gymName)
        {
            IGym currentGym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            currentGym.Exercise();
            return string.Format(OutputMessages.AthleteExercise, currentGym.Athletes.Count);
        }
    }
}
