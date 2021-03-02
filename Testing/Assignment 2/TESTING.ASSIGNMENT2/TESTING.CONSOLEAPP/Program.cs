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
            Console.WriteLine("Ram".ChangeCase());
            Console.WriteLine("ram MCA RAM Bca BbA".ChangeToTitleCase());
            Console.WriteLine("Ram".IsLowerCaseString()?"All Characters are lower":"Not all characters are lower");
            Console.WriteLine("ramsingh".DoCapitalize());
            Console.WriteLine("ram".IsUpperCaseString() ? "All Characters are upper" : "Not all characters are upper");
            Console.WriteLine("123d".IsValidNumericValue()?"Is valid numeric string":"Is not valid numeric string");
            Console.WriteLine("ramsingh".RemoveLastCharacter());
            Console.WriteLine("ram singh".WordCount());
            Console.WriteLine("123".StringToInteger());
            Console.ReadLine();
        }
    }
}
