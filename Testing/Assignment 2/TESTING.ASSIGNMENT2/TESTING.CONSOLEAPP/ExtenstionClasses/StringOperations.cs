using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTING.CONSOLEAPP.ExtenstionClasses
{
    public static class StringOperations
    {
        public static string ChangeCase(this string inputString) {
            return Char.IsLower(inputString[0]) ? inputString.ToUpper() : inputString.ToLower();
        }
        public static string ChangeToTitleCase(this string inputString)
        {
            StringBuilder updatedString = new StringBuilder();
            string[] inputStringArray = inputString.Split(' ');
            foreach(var item in inputStringArray)
            {
                bool isAcronyms = true;
                for (int index = 0; index < item.Length; index++)
                {
                    if (Char.IsLower(item[index]))
                    {
                        isAcronyms = false;
                        break;
                    }

                }
                if (!isAcronyms)
                    updatedString.Append(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(item)+" ");
                else
                    updatedString.Append(item+" ");
            }
            return updatedString.ToString().Remove(updatedString.Length-1);
        }
        public static bool IsLowerCaseString(this string inputString)
        {
            bool isLower = true;
            for (int index = 0; index < inputString.Length; index++)
            {
                if (Char.IsUpper(inputString[index]))
                {
                    isLower = false;
                    break;
                }
            }
            return isLower ? true : false;
        }
        public static string DoCapitalize(this string inputString)
        {
            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(inputString);
        }
        public static bool IsUpperCaseString(this string inputString)
        {
            bool isUpper = true;
            for (int index = 0; index < inputString.Length; index++)
            {
                if (Char.IsLower(inputString[index]))
                {
                    isUpper = false;
                    break;
                }
            }
            return isUpper ? true : false;
        }
        public static bool IsValidNumericValue(this string inputString)
        {
            return int.TryParse(inputString, out int n);
        }
        public static string RemoveLastCharacter(this string inputString)
        {
            return inputString.Remove(inputString.Length - 1);
        }
        public static int WordCount(this string inputString)
        {
            return inputString.Split(' ').Length;
        }
        public static int StringToInteger(this string inputString)
        {
            int.TryParse(inputString,out int n);
            return n;
        }
    }
}
