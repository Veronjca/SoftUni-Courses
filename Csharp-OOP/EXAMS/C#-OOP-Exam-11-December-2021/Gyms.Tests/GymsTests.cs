using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        private Gym gym;
       
        [SetUp]
        public void SetUp()
        {
            this.gym = new Gym("SexyGym", 20);
        }

        //[Test]
        //public void AthleteConstructor_ShouldWorkProperly()
        //{
        //    Athlete athlete = new Athlete("TheRock");
        //    Assert.IsFalse(athlete.IsInjured);
        //}

        [Test]

        public void Constructor_ShouldWorkProperly()
        {
            Assert.AreEqual("SexyGym", this.gym.Name);
            Assert.AreEqual(20, this.gym.Capacity);
        }

        [Test]

        public void Name_ShouldThrowExceptionWhenValueIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => this.gym = new Gym(null, 20));
            Assert.Throws<ArgumentNullException>(() => this.gym = new Gym(string.Empty, 20));
        }

        [Test]

        public void Capacity_ShouldThrowExceptionWhenValueIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() => this.gym = new Gym("SexyGym", -1));
        }

        [Test]
        public void AddAthlete_ShouldThrowExceptionWhenGymIsFull()
        {
            this.gym = new Gym("SexyGym", 1);
            Athlete currentAthlete = new Athlete("TheRock");
            this.gym.AddAthlete(currentAthlete);
            Assert.Throws<InvalidOperationException>(() => this.gym.AddAthlete(new Athlete("Pesho")));
        }

        [Test]
        public void AddAthlete_ShouldWorkProperly()
        {
            this.gym.AddAthlete(new Athlete("TheRock"));
            Assert.AreEqual(1, this.gym.Count);
        }

        [Test]
        public void AthleteRemove_ShouldThrowExceptionWhenAthleteToRemoveIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => this.gym.RemoveAthlete("TheRock"));
        }

        [Test]
        public void AthleteRemove_ShouldWorkProperly()
        {
            this.gym.AddAthlete(new Athlete("TheRock"));
            this.gym.RemoveAthlete("TheRock");
            Assert.AreEqual(0, this.gym.Count);
        }

        [Test]
        public void InjureAthlete_ShouldThrowExceptionWhenRequestedAthleteIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => this.gym.InjureAthlete("TheRock"));
        }

        [Test]
        public void InjureAthlete_ShouldWorkProperly()
        {
            Athlete athlete = new Athlete("TheRock");
            this.gym.AddAthlete(athlete);
            this.gym.InjureAthlete("TheRock");
            Assert.IsTrue(athlete.IsInjured);
            Assert.AreEqual(athlete, this.gym.InjureAthlete("TheRock"));
        }

        [Test]
        public void Report_ShouldWorkProperly()
        {
            this.gym.AddAthlete(new Athlete("TheRock"));
            this.gym.AddAthlete(new Athlete("Batista"));
            string expected = $"Active athletes at {this.gym.Name}: TheRock, Batista";
            Assert.AreEqual(expected, this.gym.Report());
        }

        
    }
}
