using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;
        private const int AxeAttackpoints = 10;
        private const int AxeDurabilityPoints = 1;
        private const int DummyHealth = 30;
        private const int DummyExperience = 10;

        [SetUp]
        public void Setup()
        {
            axe = new Axe(AxeAttackpoints, AxeDurabilityPoints);
            dummy = new Dummy(DummyHealth, DummyExperience);
        }

        [Test]
        public void AxeDurability_ShouldDropAfterAttack()
        {
            axe.Attack(dummy);
            Assert.AreEqual(0, axe.DurabilityPoints, "Axe Durability doesn't change after attack!");
        }

        [Test]
        public void AxeAttackingWithZeroDurabilityPoints_ShouldThrowException()
        {
            axe.Attack(dummy);
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Axe should not be able to attack with zero durability points!");
        }
    }
}