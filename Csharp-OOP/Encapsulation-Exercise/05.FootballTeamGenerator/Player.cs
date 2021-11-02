using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int dribble, int passing, int shooting, int sprint)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
            this.Sprint = sprint;

        }
        public string Name 
        { 
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
                 
            }
        }
        public int Endurance 
        { 
            get => this.endurance; 
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessageHelper(nameof(this.Endurance)));
                }
                this.endurance = value;
            }
        }
        public int Sprint 
        { 
            get => this.sprint;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessageHelper(nameof(this.Sprint)));
                }
                this.sprint = value;
            }            
        }

        public int Dribble 
        { 
            get => this.dribble;
           private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessageHelper(nameof(this.Dribble)));
                }
                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessageHelper(nameof(this.Passing)));
                }
                this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessageHelper(nameof(this.Shooting)));
                }
                this.shooting = value;
            }
        }

        public int SkillLevel => (int)Math.Round((this.Endurance + this.Sprint + this.Shooting + this.Dribble + this.Passing) / 5.0);
        private string ExceptionMessageHelper(string statName)
        {
            return $"{statName} should be between 0 and 100.";
        }
    }
}
