namespace UnitTestProject1
{
    using System.Collections.Generic;
    using InitialTasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CustomHashTableTests
    {
        [TestMethod]
        public void TestConstructorAsItShuoldCreateEmptyHashTableW()
        {
            var table = new CustomHashTable<int, int>();
            Assert.AreEqual(0, table.Count);
        }

        [TestMethod]
        public void TestConstructorAsItShuoldCreateTableWithInitialCapacityOf16()
        {
            var table = new CustomHashTable<int, int>();
            PrivateObject accessor = new PrivateObject(table);
            LinkedList<KeyValuePair<int, int>>[] dataPrivateField = (LinkedList<KeyValuePair<int, int>>[])accessor.GetField("data");
            Assert.AreEqual(16, dataPrivateField.Length);
        }

        [TestMethod]
        public void TestConstructorWithListOfPairs()
        {
            var table = new CustomHashTable<int, int>(new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(5, 6),
                new KeyValuePair<int, int>(98, 6),
                new KeyValuePair<int, int>(7, 56),
                new KeyValuePair<int, int>(8, 45)
            });
            Assert.AreEqual(4, table.Count);
        }

        [TestMethod]
        public void TestIfKeysPropertyReturnsAdequateValues()
        {
            var table = new CustomHashTable<int, int>(new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(5, 6),
                new KeyValuePair<int, int>(98, 6),
                new KeyValuePair<int, int>(9, 56),
                new KeyValuePair<int, int>(28, 45)
            });
            Assert.AreEqual(4, table.Keys.Count);
        }

        [TestMethod]
        public void TestIfAddingNewPairsWorksCorrectly()
        {
            var table = new CustomHashTable<int, int>(new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(5, 6),
                new KeyValuePair<int, int>(98, 6),
                new KeyValuePair<int, int>(8, 56),
                new KeyValuePair<int, int>(10, 45)
            });
            table.Add(87, 89);
            table.Add(57, 189);
            table.Add(51, 89);
            table.Add(512, 189);
            table.Add(52, 819);
            table.Add(145, 89);

            Assert.AreEqual(10, table.Count);
        }

        [TestMethod]
        public void TestIfRemovingPairsWorksCorrectly()
        {
            var table = new CustomHashTable<int, int>(new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(5, 6),
                new KeyValuePair<int, int>(98, 6),
                new KeyValuePair<int, int>(9, 56),
                new KeyValuePair<int, int>(10, 45)
            });
            table.Remove(5);

            Assert.AreEqual(3, table.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestIfRemoveThrowsExeptionWhenInvalidKeyIsEntered()
        {
            var table = new CustomHashTable<int, int>(new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(5, 6),
                new KeyValuePair<int, int>(98, 6),
                new KeyValuePair<int, int>(8, 56),
                new KeyValuePair<int, int>(22, 45)
            });
            table.Remove(21);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestIfFindThrowsExeptionWhenInvalidKeyIsEntered()
        {
            var table = new CustomHashTable<int, int>(new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(5, 6),
                new KeyValuePair<int, int>(98, 6),
                new KeyValuePair<int, int>(7, 56),
                new KeyValuePair<int, int>(9, 45)
            });
            table.Find(21);
        }

        [TestMethod]
        public void TestIfIndexerWorksCorrectly()
        {
            var table = new CustomHashTable<int, int>(new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(5, 6),
                new KeyValuePair<int, int>(98, 6),
                new KeyValuePair<int, int>(7, 56),
                new KeyValuePair<int, int>(9, 45)
            });
            var foundByIndex = table[9];

            Assert.AreEqual(45, foundByIndex);
        }
    }
}
