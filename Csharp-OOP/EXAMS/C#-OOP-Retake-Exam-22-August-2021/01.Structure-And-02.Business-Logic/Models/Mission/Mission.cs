using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            int counter = -1;
            bool flag = false;
            foreach (var astronaut in astronauts)
            {
                while (astronaut.Oxygen > 0)
                {
                    if (counter + 1 < planet.Items.Count)
                    {
                        astronaut.Bag.Items.Add(planet.Items.AsEnumerable().ToList()[++counter]);
                        if (astronaut.CanBreath)
                        {
                            astronaut.Breath();
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        flag = true;
                        break;
                    }
                }

                if (flag)
                {
                    break;
                }
            }
        }
    }
}


