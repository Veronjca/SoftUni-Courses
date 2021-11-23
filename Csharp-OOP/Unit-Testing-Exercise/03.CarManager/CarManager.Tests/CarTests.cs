using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        private const string Make = "Fiat";
        private const string Model = "Bravo";
        private const double FuelConsumption = 0.5;
        private const double FuelCapacity = 60;
        private const double InitialFuelAmount = 0;

        [SetUp]
        public void Setup()
        {
            this.car = new Car(Make, Model, FuelConsumption, FuelCapacity);
        }

        [Test]
        public void Constructor_ShouldSetClassPropertiesProperly()
        {
            Assert.AreEqual(Make, car.Make);
            Assert.AreEqual(Model, car.Model);
            Assert.AreEqual(FuelConsumption, car.FuelConsumption);
            Assert.AreEqual(FuelCapacity, car.FuelCapacity);
            Assert.AreEqual(InitialFuelAmount, car.FuelAmount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Constructor_ShouldThrowExceptionWhenMakeIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car(make, Model, FuelConsumption, FuelCapacity));           
        }

        [TestCase(null)]
        [TestCase("")]
        public void Constructor_ShouldThrowExceptionWhenModelIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car(Make, model, FuelConsumption, FuelCapacity));
        }

        [TestCase(-1)]
        [TestCase(-500)]
        [TestCase(0)]

        public void Constructor_ShouldThrowExceptionWhenFuelConsumptionIsLessThanOrEqualToZero(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car(Make, Model, fuelConsumption, FuelCapacity));
        }

        [TestCase(-1)]
        [TestCase(-500)]
        [TestCase(0)]

        public void Constructor_ShouldThrowExceptionWhenFuelCapacityIsLessOrEqualThanToZero(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car(Make, Model, FuelConsumption, fuelCapacity));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-500)]

        public void Refuel_ShouldThrowExceptionWhenFuelIsLessThanOrEqualToZero(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() => this.car.Refuel(fuelToRefuel));
        }

        [TestCase(50)]
        [TestCase(1)]

        public void Refuel_ShouldWorkProperly(double fuelToRefuel)
        {
            this.car.Refuel(fuelToRefuel);
            Assert.AreEqual(fuelToRefuel, this.car.FuelAmount);
        }

        [TestCase(70)]
        [TestCase(1000)]

        public void Refuel_ShouldEqualizeFuelAmountAndFuelCapacityWhenFuelAmountExceededFuelCapacity(double fuelToRefuel)
        {
            this.car.Refuel(fuelToRefuel);
            Assert.AreEqual(FuelCapacity, this.car.FuelAmount);
        }

        [TestCase(50)]
        [TestCase(20.5)]

        public void Drive_ShouldThrowExceptionWhenNeededFuelIsMoreThanCarFuelAmount(double distance)
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(distance));
        }

        [TestCase(50)]
        [TestCase(20.5)]

        public void Drive_ShouldWorkProperly(double distance)
        {
            this.car.Refuel(10);
            double expected = this.car.FuelAmount - ((distance / 100) * this.car.FuelConsumption);
            this.car.Drive(distance);
            Assert.AreEqual(expected, this.car.FuelAmount);
        }

    }
}