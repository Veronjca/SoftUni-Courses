using NUnit.Framework;
using System;

namespace Tests
{
    
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;
        private const int InternalArrayMaxCapacity = 16;
        [SetUp]
        public void Setup()
        {
            this.database = new ExtendedDatabase(
                new Person(1, "Emre"),
                new Person(2, "Pavlin"),
                new Person(3, "Ivan"),
                new Person(4, "Nikolay"),
                new Person(5, "Martin"),
                new Person(6, "Jordan"),
                new Person(7, "Maxim"),
                new Person(8, "Aneliya"),
                new Person(9, "Danail"),
                new Person(10, "Margarita"),
                new Person(11, "Valeri"),
                new Person(12, "Ivaylo"),
                new Person(13, "Neli"),
                new Person(14, "Viki"),
                new Person(15, "Vanessa")
                );
        }

        [Test]
        public void Count_ShouldReturnInternalArrayCount()
        {
            int expected = 15;
            Assert.AreEqual(expected, database.Count);
        }

        [Test]

        public void AddMethod_ShouldThrowExceptionWhenTryingToAddMorePersonsThanMaxCapacity()
        {
            this.database.Add(new Person(16, "Victoriya"));
            Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(17, "Kircho")));
        }
        [Test]

        public void AddMethod_ShouldThrowExceptionWhenTryingToAddPersonWithAlreadyExistingUsername()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(16, "Vanessa")));           
        }

        [Test]

        public void AddMethod_ShouldThrowExceptionWhenTryingToAddPersonWithAlreadyExistingId()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(15, "Goshko")));
        }

        [Test]

        public void AddMethod_ShouldWorkProperly()
        {
            this.database.Add(new Person(16, "Kircho"));
            int expected = 16;
            Assert.AreEqual(expected, this.database.Count);
        }

        [Test]

        public void AddRangeMethod_ShoudlThrowExceptionWhenProvidedDataLengthIsOutOfRange()
        {
            Person[] persons = new Person[] {
                new Person(1, "Emre"),
                new Person(2, "Pavlin"),
                new Person(3, "Ivan"),
                new Person(4, "Nikolay"),
                new Person(5, "Martin"),
                new Person(6, "Jordan"),
                new Person(7, "Maxim"),
                new Person(8, "Aneliya"),
                new Person(9, "Danail"),
                new Person(10, "Margarita"),
                new Person(11, "Valeri"),
                new Person(12, "Ivaylo"),
                new Person(13, "Neli"),
                new Person(14, "Viki"),
                new Person(15, "Vanessa"),
                new Person(16, "Victoriya"),
                new Person(17, "Kircho")
            };
            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(persons));
        }

        [Test]

        public void RemoveMethod_ShouldThrowExceptionWhenCollectionIsEmpty()
        {
            this.database = new ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]

        public void RemoveMethod_ShouldWorkProperly()
        {
            this.database.Remove();
            int expected = 14;
            Assert.AreEqual(expected, this.database.Count);
        }

        [TestCase("")]
        [TestCase(null)]

        public void FindByUsernameMethod_ShouldThrowExceptionWhenNameIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(name));
        }

        [TestCase("Pesho")]
        [TestCase("123")]
        [TestCase("NimoaDaIzmislqPovecheImena")]

        public void FindByUsernameMethod_ShouldThrowExceptionWhenNameDoesntExist(string name)
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername(name));
        }

        [TestCase("Vanessa")]
        public void FindByUsernameMethod_ShouldWorkProperly(string name)
        {
            Person expected = new Person(15, "Vanessa");
            Person result = this.database.FindByUsername(name);
            Assert.AreEqual(expected.UserName, result.UserName);
            Assert.AreEqual(expected.Id, result.Id);
        }

        [TestCase(-5)]
        [TestCase(-300)]

        public void FindByIdMethod_ShouldThrowExceptionWithNegativeId(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(id));
        }

        [TestCase(17)]
        [TestCase(500)]

        public void FindByIdMethod_ShouldThrowExceptionWhenIdDoesntExist(long id)
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindById(id));
        }

        [TestCase(15)]

        public void FindByIdMethod_ShouldWorkProperly(long id)
        {
            Person expected = new Person(15, "Vanessa");
            Person result = this.database.FindById(id);
            Assert.AreEqual(expected.UserName, result.UserName);
            Assert.AreEqual(expected.Id, result.Id);
        }
    }
}