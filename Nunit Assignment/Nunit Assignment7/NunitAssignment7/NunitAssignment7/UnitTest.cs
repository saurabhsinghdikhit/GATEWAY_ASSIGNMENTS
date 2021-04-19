using NUnit.Framework;
using NunitAssignment7.Concrete;
using System;
using System.Threading.Tasks;

namespace NunitAssignment7
{
    public class Tests
    {
        private Functions _function;
        [SetUp]
        public void Setup()
        {
            // Arrange
            _function = new Functions();
        }

        // While Loop Test case
        // Positive Test Case
        [Test]
        public void NumberAddition_Test_Positive()
        {
            // Act
            int result = _function.NumberAddition(10);

            // Assert
            Assert.AreEqual(55, result);
        }

        // While Loop Test case
        // Positive Test Case
        [Test]
        public void NumberAddition_Test_Negative()
        {
            // Act
            int result = _function.NumberAddition(10);

            // Assert
            Assert.AreNotEqual(10, result);
        }

        // Switch case Tests
        [TestCase(1, "Male")]
        [TestCase(2, "Female")]
        [TestCase(3, "Others")]
        [TestCase(4, "Invalid Gender")]
        public void GenderSelection_Test(int choice, string gender)
        {
            //Act
            string result = _function.GenderSelection(choice);

            //Assert
            Assert.AreEqual(gender, result);
        }

        // If else tests
        [TestCase(23,34,34)]
        [TestCase(23,12,23)]
        public void LargeNumber_Test(int a,int b,int large)
        {
            //Act
            int result = _function.LargeNumber(a,b);

            //Assert
            Assert.AreEqual(large, result);
        }

        // foreach Test case
        // Positive Test Case
        [Test]
        public void ListLength_Test_Positive()
        {
            // Act
            int result = _function.ListLength();

            // Assert
            Assert.AreEqual(33, result);
        }

        // foreach Test case
        // Positive Test Case
        [Test]
        public void ListLength_Test_Negative()
        {
            // Act
            int result = _function.ListLength();

            // Assert
            Assert.AreNotEqual(30, result);
        }

        // for loop tests
        [TestCase("Ram Singh",2)]
        [TestCase("Ram Singh Dikhit",4)]
        public void CountVowels_Test(string name,int vowelcount)
        {
            //Act
            int result = _function.CountVowels(name);

            //Assert
            Assert.AreEqual(vowelcount, result);
        }

        // Null Reference Exception
        [Test]
        public void NullReferenceException_Test()
        {
            //Act
            var exceptionResult = Assert.Throws<NullReferenceException>(() => _function.NullReferenceException(null));

            //Assert
            Assert.AreEqual("Null Reference Exception", exceptionResult.Message);
        }

        // Divide by zero Exception
        [Test]
        public void DivideByZero_Test()
        {
            //Act
            var exceptionResult = Assert.Throws<DivideByZeroException>(() => _function.DivideByZero(12,0));

            //Assert
            Assert.AreEqual("Divide By Zero Exception", exceptionResult.Message);
        }


        // Array Index out of bound
        [Test]
        public void ArrayIndexOutOfBound_Test()
        {
            //Act
            var exceptionResult = Assert.Throws<IndexOutOfRangeException>(() => _function.ArrayIndexOutOfBound());

            //Assert
            Assert.AreEqual("Array Index out of Bound", exceptionResult.Message);
        }

        [Test]
        public async Task CountVowelAsync_Test_Positive()
        {
            var result = await _function.CountVowelAsync("saurabh singh dikhit");
            Assert.AreEqual(6, result);
        }

        [Test]
        public async Task CountVowelAsync_Test_Negative()
        {
            var result = await _function.CountVowelAsync("saurabh singh dikhit");
            Assert.AreNotEqual(7, result);
        }

    }
}