using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System.Linq;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            foreach (var dye in bunny.Dyes)
            {
                while (!dye.IsFinished() && bunny.Energy > 0)
                {
                    if (!egg.IsDone())
                    {
                        egg.GetColored();
                        dye.Use();
                        bunny.Work();
                    }
                    else
                    {
                        break;
                    }
                }
                if (egg.IsDone() || bunny.Energy <= 0)
                {
                    break;
                }
            }

            bunny.Dyes.ToList().RemoveAll(d => d.Power == 0);
        }
    }
}
