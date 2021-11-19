using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Axe axe;
        private Dummy dummy;
        private const int AxeAttackpoints = 10;
        private const int AxeDurabilityPoints = 10;
        private const int DummyHealth = 10;
        private const int DummyExperience = 10;

        [SetUp]
        public void StartUp()
        {
            axe = new Axe(AxeAttackpoints, AxeDurabilityPoints);
            dummy = new Dummy(DummyHealth, DummyExperience);
        }

        [Test]

        public void Dummy_ShouldLoseHealthAfterAttack()
        {
            dummy.TakeAttack(AxeAttackpoints);
            Assert.AreEqual(0, dummy.Health, "Dummy should lose health after attack!");
        }

        [Test]
        public void DeadDummy_ShouldThrowExceptionIfAttacked()
        {
            dummy.TakeAttack(AxeAttackpoints);
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(AxeAttackpoints), "When dead, dummy should not be able to take attacks!");
        }

        [Test]

        public void DeadDummy_ShouldBeAbleToGiveExperience()
        {
            dummy.TakeAttack(AxeAttackpoints);
            int experience = dummy.GiveExperience();
            Assert.AreEqual(DummyExperience, experience);
        }

        [Test]

        public void AliveDummy_ShouldNotBeAbleToGiveExperience()
        {
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}
