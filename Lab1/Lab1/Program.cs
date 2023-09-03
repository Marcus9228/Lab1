using System.Collections;
using System.Data.SqlTypes;
using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string");
            string userInput = Console.ReadLine();
            Console.WriteLine();
            string numbers = "";
            string[] stringInput = new string[userInput.Length];
            List<string> numArray = new List<string>();
            List<string> numArray2 = new List<string>();
            List<int> startIndex = new List<int>();
            List<int> startIndex2 = new List<int>();
            List<int> endIndex = new List<int>();
            List<int> endIndex2 = new List<int>();
            long total = 0;

            for (int i = 0; i < userInput.Length; i++)
            {
                for (int j = i; j < userInput.Length; j++)
                {
                    if (userInput[i] == userInput[j] && i != j)
                    {
                        numbers += userInput.Substring(i, j - (i - 1));
                        numArray.Add(numbers);
                        startIndex.Add(i);
                        endIndex.Add(j - (i - 1));
                        numbers = "";
                    }
                }
            }

            for (int i = 0; i < numArray.Count; i++)
            {
                char ch = numArray[i].First();
                int count = numArray[i].Count(f => (f == ch));
                bool containsOnlyDigits = numArray[i].All(char.IsDigit);
                if (count == 2 && containsOnlyDigits)
                {
                    numArray2.Add(numArray[i]);
                    startIndex2.Add(startIndex[i]);
                    endIndex2.Add(endIndex[i]);
                }
                
            }

            for (int i = 0; i < numArray2.Count; i++) 
            {
                int startIndexs = userInput.IndexOf(numArray2[i]);
                string substring1 = userInput.Substring(0, startIndex2[i]);
                string substring2 = userInput.Remove(0, startIndex2[i] + numArray2[i].Length);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(substring1);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(numArray2[i]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(substring2);
                Console.WriteLine();

                long num = Convert.ToInt64(numArray2[i]);
                total += num;
            }
            Console.WriteLine("\nThe total of all highlighted numbers: " + total);
        }
    }
}