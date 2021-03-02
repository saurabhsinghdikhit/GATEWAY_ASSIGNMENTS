using System;
using System.Collections.Generic;
using System.Text;
using TESTING.CONSOLEAPP.ExtenstionClasses;
using Xunit;

namespace TESTING.CONSOLEAPP.TEST
{
    public class StringOperationTest
    {
        [Fact]
        public void Test_ChangeCase()
        {
            // Arrange
            var inputString = "Upper";
            var outputString = "upper";
            // Act
            var newString = inputString.ChangeCase();
            // Assert
            Assert.Equal(newString, outputString);
        }
        [Fact]
        public void Test_ChangeToTitleCase()
        {
            // Arrange
            var inputString = "ram MCA RAM Bca BbA";
            var outputString = "Ram MCA RAM Bca Bba";
            // Act
            var newString = inputString.ChangeToTitleCase();
            // Assert
            Assert.Equal(newString, outputString);
        }
        [Fact]
        public void Test_IsLowerCaseString()
        {
            // Arrange
            var inputString = "ramsingh";
            // Act
            var newString = inputString.IsLowerCaseString();
            // Assert
            Assert.True(newString);
        }
        [Fact]
        public void Test_IsUpperCaseString()
        {
            // Arrange
            var inputString = "RAM";
            // Act
            var newString = inputString.IsUpperCaseString();
            // Assert
            Assert.True(newString);
        }
        [Fact]
        public void Test_DoCapitalize()
        {
            // Arrange
            var inputString = "ram";
            var outputString = "Ram";
            // Act
            var newString = inputString.DoCapitalize();
            // Assert
            Assert.Equal(newString,outputString);
        }
        [Theory]
        [InlineData("123", true)]
        [InlineData("123c", false)]
        public void Test_IsValidNumericValue(string inputString,bool result)
        {
            // Arrange
            
            // Act
            var newString = inputString.IsValidNumericValue();
            // Assert
            Assert.Equal(newString, result);
        }
        [Fact]
        public void Test_RemoveLastCharacter()
        {
            // Arrange
            var inputString = "Ram Singh";
            var outputString = "Ram Sing";
            // Act
            var newString = inputString.RemoveLastCharacter();
            // Assert
            Assert.Equal(newString, outputString);
        }
        [Fact]
        public void Test_WordCount()
        {
            // Arrange
            var inputString = "Ram Singh";
            var count = 2;
            // Act
            var newString = inputString.WordCount();
            // Assert
            Assert.Equal(newString, count);
        }
        [Fact]
        public void Test_StringToInteger()
        {
            // Arrange
            var inputString = "123";
            var output = 123;
            // Act
            var newString = inputString.StringToInteger();
            // Assert
            Assert.Equal(newString, output);
        }
    }
}
