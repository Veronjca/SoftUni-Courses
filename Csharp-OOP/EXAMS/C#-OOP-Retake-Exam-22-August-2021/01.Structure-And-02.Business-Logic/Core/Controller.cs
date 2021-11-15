using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private int exploredPlanetsCount;
        private AstronautRepository astronauts = new AstronautRepository();
        private PlanetRepository planets = new PlanetRepository();
        public string AddAstronaut(string type, string astronautName)
        {
            Astronaut current;
            if (type == "Biologist")
            {
                current = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                current = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                current = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }
            this.astronauts.Add(current);

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet current = new Planet(planetName);
            foreach (var item in items)
            {
                current.Items.Add(item);
            }
            this.planets.Add(current);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> suitableAstronauts = this.astronauts.Models.ToList();
            suitableAstronauts.RemoveAll(a => a.Oxygen < 60);
            if (suitableAstronauts.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            IMission mission = new Mission();
            
            mission.Explore(this.planets.FindByName(planetName), suitableAstronauts);
            exploredPlanetsCount++;
            int deadAstronauts = suitableAstronauts.Count(a => a.Oxygen == 0);

            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts);

        }

        public string Report()
        {
            return $"{exploredPlanetsCount} planets were explored!{Environment.NewLine}Astronauts info:{Environment.NewLine}{string.Join(Environment.NewLine, this.astronauts.Models)}";
        }

        public string RetireAstronaut(string astronautName)
        {
            if (this.astronauts.FindByName(astronautName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            this.astronauts.Remove(this.astronauts.FindByName(astronautName));
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
