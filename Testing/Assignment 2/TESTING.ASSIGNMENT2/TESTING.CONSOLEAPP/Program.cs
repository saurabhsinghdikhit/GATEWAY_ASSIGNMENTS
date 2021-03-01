using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTING.CONSOLEAPP.ExtenstionClasses;

namespace TESTING.CONSOLEAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(StringOperations.ChangeCase("ramSinghDIKHIT"));
            Console.WriteLine(StringOperations.ChangeToTitleCase("ram MCA RAM Bca BbA"));
            Console.WriteLine(StringOperations.IsLowerCaseString("Ram")?"All Characters are lower":"Not all characters are lower");
            Console.WriteLine(StringOperations.DoCapitalize("ramsingh"));
            Console.WriteLine(StringOperations.IsUpperCaseString("ram") ? "All Characters are upper" : "Not all characters are upper");
            Console.WriteLine(StringOperations.IsValidNumericValue("123d")?"Is valid numeric string":"Is not valid numeric string");
            Console.WriteLine(StringOperations.RemoveLastCharacter("ramsingh"));
            Console.WriteLine(StringOperations.WordCount("ram singh"));
            Console.WriteLine(StringOperations.StringToInteger("123"));
            Console.ReadLine();
        }
    }
}
