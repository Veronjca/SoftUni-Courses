namespace Robots.Tests
{
    using System;
    using NUnit.Framework;

    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;
        private const string RobotName = "Robo";
        private const int RobotBattery = 200;
        private const int Capacity = 1;

        [SetUp]
        
        public void SetUp()
        {
            this.robot = new Robot(RobotName, RobotBattery);
            this.robotManager = new RobotManager(Capacity);
            this.robotManager.Add(this.robot);
        }

        [Test]

        public void Constructor_ShouldWorkProperly()
        {
            int expectedCapacity = Capacity;
            Assert.AreEqual(expectedCapacity, this.robotManager.Capacity);
        }

        [Test]

        public void Constructor_ShouldThrowExceptionWhenCapacityIsLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => this.robotManager = new RobotManager(-1));
        }

        [Test]

        public void Add_ShouldThrowExceptionWhenTryingToAddExistingRobot()
        {
            this.robotManager = new RobotManager(3);
            this.robotManager.Add(this.robot);
 
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Add(this.robot));
        }

        [Test]

        public void Add_ShouldThrowExceptionWhenNoMoreCapacity()
        {
            var dummy = new Robot("Kircho", 20);
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Add(dummy));
        }

        [Test]

        public void Remove_ShouldWorkProperly()
        {
            int expectedCount = 0;
            this.robotManager.Remove("Robo");
            Assert.AreEqual(expectedCount, this.robotManager.Count);
        }

        [Test]

        public void Remove_ShouldThrowExceptionWhenRobotToRemoveIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Remove("Penka"));
        }

        [Test]

        public void Work_ShouldThrowExceptionWhenRobotToRemoveIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Work("Penka", "cleaning", 20));
        }

        [Test]

        public void Work_ShouldThrowExceptionWhenRobotBatteryIsLessThanBatteryUsage()
        {
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Work(this.robot.Name, "cleaning", 300));
        }

        [Test]

        public void Work_ShouldBehaveProperly()
        {
            int expectedBattery = this.robot.Battery - 100;
            this.robotManager.Work(this.robot.Name, "cleaning", 100);
            
            Assert.AreEqual(expectedBattery, this.robot.Battery);
        }

        [Test]
        public void Charge_ShouldThrowExceptionWhenRobotToChargeIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Charge("Penka"));
        }

        [Test]
        public void Charge_ShouldWorkProperly()
        {
            int expectedBattery = this.robot.MaximumBattery;
            this.robotManager.Work(this.robot.Name, "cleaning", 100);
            this.robotManager.Charge(this.robot.Name);

            Assert.AreEqual(expectedBattery, this.robot.Battery);
        }
    }
}
