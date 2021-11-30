using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            racerOne.Race();
            racerTwo.Race();

            double firstRacerRacingBehaviorMultiplier = 0;
            double secondRacerRacingBehaviorMultiplier = 0;
            if (racerOne.RacingBehavior == "strict")
            {
                firstRacerRacingBehaviorMultiplier = 1.2;
            }
            else
            {
                firstRacerRacingBehaviorMultiplier = 1.1;
            }
            
            if (racerTwo.RacingBehavior == "strict")
            {
                secondRacerRacingBehaviorMultiplier = 1.2;
            }
            else
            {
                secondRacerRacingBehaviorMultiplier = 1.1;
            }

            double firstRacerChanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * firstRacerRacingBehaviorMultiplier;

            double secondRacerChanceOfWinning = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * secondRacerRacingBehaviorMultiplier;

            if (firstRacerChanceOfWinning > secondRacerChanceOfWinning)
            {
                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            }

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
        }
    }
}
