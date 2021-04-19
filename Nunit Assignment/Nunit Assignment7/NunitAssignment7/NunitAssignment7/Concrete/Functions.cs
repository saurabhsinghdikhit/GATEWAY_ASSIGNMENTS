using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NunitAssignment7.Concrete
{
    public class Functions
    {

        // while
        public int NumberAddition(int n)
        {
            int i = 1, addition = 0;
            while (i <= n)
            {
                addition += i;
                i++;
            }
            return addition;

        }

        // switch
        public string GenderSelection(int number)
        {
            string gender = "";
            switch (number)
            {
                case 1:
                    gender = "Male";
                    break;
                case 2:
                    gender = "Female";
                    break;
                case 3:
                    gender = "Others";
                    break;
                default:
                    gender = "Invalid Gender";
                    break;
            }
            return gender;
        }

        // if else
        public int LargeNumber(int a,int b)
        {
            if (a>b)
                return a;
            else
            {
                return b;
            }
        }

        //foreach ....
        public int ListLength()
        {
            List<int> numbers = new List<int>() { 1, 2, 5, 7, 8, 10 };
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            return sum;
        }

        //for loop
        public int CountVowels(string name)
        {
            int count=0;
            for (int i = 1; i < name.Length; i++)
            {
                if (name[i] == 'A' || name[i] == 'E' || name[i] == 'I' || name[i] == 'O' || name[i] == 'U' ||
                    name[i] == 'a' || name[i] == 'e' || name[i] == 'i' || name[i] == 'o' || name[i] == 'u')
                    count += 1;
            }
            return count;
        }

        // NullReferenceException
        public void NullReferenceException(string s1)
        {
            if (s1 == null)
                throw new NullReferenceException("Null Reference Exception");
        }

        // Devide by zero
        public void DivideByZero(int num1, int num2)
        {
            int result = 0;
            try
            {
                result = num1 / num2;
            }
            catch (DivideByZeroException)
            {
                throw new DivideByZeroException("Divide By Zero Exception");
            }
        }
        //Array Index Out Of Bound 
        public void ArrayIndexOutOfBound()
        {
            try
            {
                string name = "Saurabh Singh";
                Console.WriteLine(name[name.Length]);
            }
            catch (Exception)
            {

                throw new IndexOutOfRangeException("Array Index out of Bound");
            }
        }

        //Async
        public async Task<int> CountVowelAsync(string name)
        {
            int count = 0;
            for (int i = 1; i < name.Length; i++)
            {
                if (name[i] == 'A' || name[i] == 'E' || name[i] == 'I' || name[i] == 'O' || name[i] == 'U' ||
                    name[i] == 'a' || name[i] == 'e' || name[i] == 'i' || name[i] == 'o' || name[i] == 'u')
                    count += 1;
            }
            return count;
        }
    }
}
