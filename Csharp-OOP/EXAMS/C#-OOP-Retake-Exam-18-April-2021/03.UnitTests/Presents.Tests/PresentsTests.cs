namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        private List<Present> presents;
        private Present present;
        private Bag bag;
        [SetUp]
        public void SetUp()
        {
            this.bag = new Bag();
            this.present = new Present("headphones", 20);
        }

        [Test]

        public void Constructor_ShouldInitializeACollectionOfPresents()
        {
            this.presents = new List<Present>();
            IReadOnlyCollection<Present> expected = this.presents.AsReadOnly();
            CollectionAssert.AreEqual(expected, this.bag.GetPresents());
        }

        [Test]

        public void Create_ShouldThrowExceptionWhenPresentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.bag.Create(null));
        }

        [Test]
        
        public void Create_ShouldThrowExceptionWhenTryingToAddExistingPresent()
        {
            this.bag.Create(this.present);
            Assert.Throws<InvalidOperationException>(() => this.bag.Create(this.present));
        }

        [Test]

        public void Create_ShouldAddPresents()
        {
            this.bag.Create(this.present);
            int expected = 1;
            Assert.AreEqual(expected, this.bag.GetPresents().Count);
        }

        [Test]
        public void Create_ShouldReturnMessageWhenSuccesfullyAddedPresent()
        {         
            string expected = $"Successfully added present {this.present.Name}.";
            Assert.AreEqual(expected, this.bag.Create(this.present));
        }

        [Test]

        public void RemoveShouldWorkProperly()
        {
            this.bag.Create(this.present);
            Assert.IsTrue(this.bag.Remove(this.present));
        }

        [Test]
        public void GetPresentWithLeastMagic_ShouldWorkProperly()
        {
            this.bag.Create(this.present);
            this.bag.Create(new Present("doll", 35));
            this.bag.Create(new Present("car", 100));
            string expectedName = this.present.Name;
            double expectedMagic = this.present.Magic;
            Present result = this.bag.GetPresentWithLeastMagic();
            Assert.AreEqual(expectedName, result.Name);
            Assert.AreEqual(expectedMagic, result.Magic);
        }

        [Test]
        public void GetPresent_ShouldWorkProperly()
        {
            this.bag.Create(this.present);
            Present result = this.bag.GetPresent("headphones");
            string expectedName = this.present.Name;
            double expectedMagic = this.present.Magic;
            Assert.AreEqual(expectedName, result.Name);
            Assert.AreEqual(expectedMagic, result.Magic);
        }

    }
}
