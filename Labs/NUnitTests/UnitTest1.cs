using NUnit.Framework;
using Lab_07_TDD_Collections;
using Lab_09_Rabbit_Test;
using Lab_14_LINQ;
using Lab_20_Northwind_Products;
using Lab_28_Fibonacci;
using Lab_29_SimsonsRule;

namespace NUnitTests
{
    public class Tests
    {
        [SetUp] // Annotations
        public void Setup() // Setup run
        {
            // Get data from database
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(true, true);
        }

        [TestCase(1,2,3,4,5,280)]
        public void ArrayListDictionaryGetTotal(int a, int b, int c, int d, int e, int expected)
        {
            // call method to other project
            int actual = Array_List_Dictionary.GetTotal(1, 2, 3, 4, 5);
            expected = 280;

            // See test corrert or not
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 3, 4)]
        [TestCase(3, 7, 8)]
        public void RabbitGrowthTests(int totalYears, int expectedCumulativeRabbitAge, int expectedRabbitCount)
        {
            // Arrange

            // Act
            // Tuple (int name, int name)
            (int actualCumulativeAge, int actualRabbitCount) = Rabbit_Collection.MultiplyRabbits(totalYears);

            // Assert
            Assert.AreEqual(expectedCumulativeRabbitAge, actualCumulativeAge);
            Assert.AreEqual(expectedRabbitCount, actualRabbitCount);
        }

        [TestCase(2, 2, 1)]
        [TestCase(3, 3, 1)]
        [TestCase(4, 4, 2)]
        [TestCase(5, 6, 3)]
        [TestCase(6, 9, 4)]
        [TestCase(7, 13, 5)]
        [TestCase(8, 18, 7)]
        public void RabbitGrowthTestsIfAgeGreaterThanTwo(int totalYears, int expectedCumulativeRabbitAge, int expectedRabbitCount)
        {
            // Arrange

            // Act
            // Tuple (int name, int name)
            (int actualCumulativeAge, int actualRabbitCount) = Rabbit_Collection.MultiplyRabbitsIfAgeGreaterThanTwo(totalYears);

            // Assert
            Assert.AreEqual(expectedCumulativeRabbitAge, actualCumulativeAge);
            Assert.AreEqual(expectedRabbitCount, actualRabbitCount);
        }

        [TestCase(null, 105)] // Total customers
        public void TotalNumberOfCustomers(string city, int expectedTotalCustomers) 
        {
            // Arrange

            // Act
            int actualTotalCustomers = NorthwindCustomer.TotalNumberOfCustomers();

            // Assert
            Assert.AreEqual(expectedTotalCustomers, actualTotalCustomers);
        }

        [TestCase("London", 19)] // London customers
        [TestCase("Berlin", 1)] // Berlin customers
        public void TotalNumberOfCustomersByCity(string city, int expectedTotalCustomers)
        {
            // Arrange

            // Act
            int actualTotalCustomers = NorthwindCustomer.TotalNumberOfCustomersByCity(city);

            // Assert
            Assert.AreEqual(expectedTotalCustomers, actualTotalCustomers);
        }

        [TestCase(null, 12)]
        public void TotalNumberOfProductsWithCategoryIDEqualOne(string name, int expectedTotalProducts)
        {
            // Arrange

            // Act
            int actualTotalProducts = NorthwindCustomer.TotalNumberOfProductsWithCategoryIDEqualOne();

            // Assert
            Assert.AreEqual(expectedTotalProducts, actualTotalProducts);
        }

        [TestCase(3)]
        public void TotalNumberOfProductsStartingWithP(int expectedTotalProducts)
        {
            // Arrange

            // Act
            int actualTotalProducts = NorthwindProduct.TotalNumberOfProductsStartingWithP();

            // Assert
            Assert.AreEqual(expectedTotalProducts, actualTotalProducts);
        }

        [TestCase("a", 2)]
        [TestCase("p", 3)]
        public void TotalNumberOfProductsStartingWithLetter(string letter, int expectedTotalProducts)
        {
            // Arrange

            // Act
            int actualTotalProducts = NorthwindProduct.TotalNumberOfProductsStartingWithLetter(letter);

            // Assert
            Assert.AreEqual(expectedTotalProducts, actualTotalProducts);
        }

        [TestCase(1,1)]
        [TestCase(4,3)]
        [TestCase(7,13)]
        public void ReturnFibonacciNthItemInSequence(int n, int expectedValue)
        {
            // Arrange

            // Act
            int actualValue = Fibonacci.ReturnFibonacciNthItemInSequence(n);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase(6,0,6,72)]
        [TestCase(8, 0, 8, 170.66666666666666d)]
        [TestCase(10,0,10, 333.33333333333331d)]
        public void GetAreaUnderGraphUsingSimpsonsRule(int n, int min, int max, double expectedValue)
        {
            // Arrange

            // Act
            double actualValue = SimsonsRule.GetAreaUnderGraphUsingSimpsonsRule(n, min, max);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase(6,0,6,324)]
        [TestCase(10,0,10,2500)]
        [TestCase(20,0,20,40000)]
        public void GetAreaUnderGraphUsingSimpsonsRuleCubic(int n, int min, int max, double expectedValue)
        {
            // Arrange

            // Act
            double actualValue = SimsonsRule.GetAreaUnderGraphUsingSimpsonsRuleCubic(n, min, max);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}