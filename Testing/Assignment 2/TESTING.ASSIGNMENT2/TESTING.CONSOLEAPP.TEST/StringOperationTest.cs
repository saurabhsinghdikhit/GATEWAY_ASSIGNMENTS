using System;
using System.Collections.Generic;
using System.Text;
using TESTING.CONSOLEAPP.ExtenstionClasses;
using Xunit;

namespace TESTING.CONSOLEAPP.TEST
{
    public class StringOperationTest
    {

        [Theory]
        [InlineData("Upper", "upper")]
        [InlineData("UPPER", "upper")]
        [InlineData("lower", "LOWER")]
        public void Test_ChangeCase(string inputString, string result)
        {

            // Act
            var newString = inputString.ChangeCase();

            // Assert
            Assert.Equal(newString, result);

        }

        [Theory]
        [InlineData("ram MCA RAM Bca BbA", "Ram MCA RAM Bca Bba")]
        [InlineData("Ram RAm MCA", "Ram Ram MCA")]
        [InlineData("abc bCA bcOm MVc MVC", "Abc Bca Bcom Mvc MVC")]
        public void Test_ChangeToTitleCase(string inputString, string result)
        {
            
            // Act
            var newString = inputString.ChangeToTitleCase();
            
            // Assert
            Assert.Equal(newString, result);
        
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
        [InlineData("453", true)]
        [InlineData("abc", false)]
        public void Test_IsValidNumericValue(string inputString,bool result)
        {

            // Act
            var newString = inputString.IsValidNumericValue();
            
            // Assert
            Assert.Equal(newString, result);
        
        }

        [Theory]
        [InlineData("abcd", "abc")]
        [InlineData("123c", "123")]
        [InlineData("Ram Singh", "Ram Sing")]
        [InlineData("SRB", "SR")]
        public void Test_RemoveLastCharacter(string inputString, string result)
        {
            
            // Act
            var newString = inputString.RemoveLastCharacter();
            
            // Assert
            Assert.Equal(newString, result);
        
        }

        [Theory]
        [InlineData("abcd", 1)]
        [InlineData("Saurabh singh dikhit",3)]
        [InlineData("Ram Singh", 2)]
        [InlineData("SRB", 1)]
        public void Test_WordCount(string inputString, int count)
        {
            
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
