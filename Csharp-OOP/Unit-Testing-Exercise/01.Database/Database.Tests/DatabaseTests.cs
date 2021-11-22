using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        private const int InternalArrayMaxCapacity = 16;

        [SetUp]

        public void SetUp()
        {
            this.database = new Database(1, 2, 3, 4, 5);
        }

        [Test]
        public void Constructor_ShouldThrowExceptionWhenAddingMoreThanMaxCapacity()
        {
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            database = new Database(numbers);

            Assert.Throws<InvalidOperationException>(() => database.Add(5), "Invalid operation!Internal array max capacity is 16.");
        }

        [Test]
        public void AddMethod_ShouldAddElementOnTheNextFreeCell()
        {
            int numberToAdd = 5;
            int index = database.Count;
            database.Add(numberToAdd);
            int[] result = database.Fetch();
            int added = result[index];

            Assert.AreEqual(added, numberToAdd);
        }

        [Test]

        public void Count_ShouldReturnInternalArrayCount()
        {
            int expected = 5;
            Assert.AreEqual(expected, database.Count);
        }

        [Test]
        public void RemoveMethod_ShouldThrowExceptionWhenCollectionIsEmpty()
        {
            database = new Database();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void RemoveMethod_ShouldSupportOnlyRemovingElementAtLastIndex()
        {
            int[] expected = new int[] { 1, 2, 3, 4 };
            database.Remove();
            int[] result = database.Fetch();
            Assert.AreEqual(expected, result);
        }

        [Test]

        public void FetchMethod_ShouldReturnElementsAsAnArray()
        {
            int[] expected = new int[] { 1, 2, 3, 4, 5 };
            int[] result = database.Fetch();
            Assert.AreEqual(expected, result);
        }

    }
}
   