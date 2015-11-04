namespace UnitTestProject1
{
    using System.Collections.Generic;
    using System.Linq;
    using InitialTasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CustomHashSetTests
    {
        [TestMethod]
        public void TestConstructorAsItShuoldCreateEmptyHashSet()
        {
            var set = new CustomHashSet<string>();
            Assert.AreEqual(0, set.Count);
        }

        [TestMethod]
        public void TestConstructorWithListOfStrings()
        {
            var set = new CustomHashSet<string>(new List<string>()
            {
                "alabala", "gruhgruh", "tintirimintiri", "ivichka e vyrhyt", "koki"
            });
            Assert.AreEqual(5, set.Count);
        }

        [TestMethod]
        public void TestIfUnionWokscorrectly()
        {
            var firstList = new List<string>()
            {
                "alabala",
                "gruhgruh",
                "tintirimintiri",
                "ivichka e vyrhyt",
                "koki"
            };
            var secondList = new List<string>()
            {
                "trilalal",
                "tophrop",
                "trimtirim",
                "ivichka e vyrhyt",
                "koki"
            };

            var firstSet = new CustomHashSet<string>(firstList);
            var secondSet = new CustomHashSet<string>(secondList);

            var resultList = firstSet.Union(secondList);

            firstSet.Union(secondSet);

            foreach (var entry in resultList)
            {
                var result = firstSet.Contains(entry);
                Assert.AreEqual(true, result);
            }
        }

        [TestMethod]
        public void TestIfIntersectWokscorrectly()
        {
            var firstList = new List<string>()
            {
                "alabala",
                "gruhgruh",
                "tintirimintiri",
                "ivichka e vyrhyt",
                "koki"
            };
            var secondList = new List<string>()
            {
                "trilalal",
                "tophrop",
                "trimtirim",
                "ivichka e vyrhyt",
                "koki"
            };


            var firstSet = new CustomHashSet<string>(firstList);
            var secondSet = new CustomHashSet<string>(secondList);

            var resultList = firstSet.Intersect(secondList);

            var resultSet = firstSet.Intersect(secondSet);

            foreach (var entry in resultList)
            {
                var result = resultSet.Contains(entry);
                Assert.AreEqual(true, result);
            }

            Assert.AreEqual(resultList.Count(), resultSet.Count);
        }

        [TestMethod]
        public void TestIfAddingNewValueWorksCorrectly()
        {
            var firstList = new List<string>()
            {
                "alabala",
                "gruhgruh",
                "tintirimintiri",
                "ivichka e vyrhyt",
                "koki"
            };

            var firstSet = new CustomHashSet<string>(firstList);

            firstSet.Add("trilalal");
            firstSet.Add("tophrop");
            firstSet.Add("trimtirim");

            Assert.AreEqual(8, firstSet.Count);
        }

        [TestMethod]
        public void TestIfRemovingValueWorksCorrectly()
        {
            var firstList = new List<string>()
            {
                "alabala",
                "gruhgruh",
                "tintirimintiri",
                "ivichka e vyrhyt",
                "koki"
            };

            var firstSet = new CustomHashSet<string>(firstList);
            firstSet.Remove("koki");

            Assert.AreEqual(4, firstSet.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestIfRemoveThrowsExeptionWhenInvalidKeyIsEntered()
        {
            var firstList = new List<string>()
            {
                "alabala",
                "gruhgruh",
                "tintirimintiri",
                "ivichka e vyrhyt",
                "koki"
            };

            var firstSet = new CustomHashSet<string>(firstList);
            firstSet.Remove("Vesich");
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestIfFindThrowsExeptionWhenInvalidKeyIsEntered()
        {
            var firstList = new List<string>()
            {
                "alabala",
                "gruhgruh",
                "tintirimintiri",
                "ivichka e vyrhyt",
                "koki"
            };

            var firstSet = new CustomHashSet<string>(firstList);
            firstSet.Find("Vesich");
        }
    }
}
