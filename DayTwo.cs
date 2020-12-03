using System.Linq;
using System.Collections.Generic;

using System.Text.RegularExpressions;
using System;

namespace advent_of_code_2020
{
    class DayTwo
    {
        static void Main(string[] args)
        {

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\domin\source\repos\advent-of-code-2020\day2.txt");
            List<string> stringList = new List<string>(lines);
            CountValidPasswordsPartTwo(stringList);
        }

        public static void CountValidPasswordsPartOne(List<string> stringList)
        {
            var counter = 0;
            stringList.ForEach(line =>
            {
                string[] digits = Regex.Split(line, @"[\s]+");
                var range = digits[0];
                string[] rangeSplitted = Regex.Split(digits[0], @"[\D]");
                var min = rangeSplitted[0];
                var max = rangeSplitted[1];
                var letter = digits[1].Replace(":", "");
                var pass = digits[2];
                var charOccurences = pass.Count(x => x == char.Parse(letter));
                if (charOccurences >= Int32.Parse(min) && charOccurences <= Int32.Parse(max))
                {
                    counter++;
                }
            });
            Console.WriteLine("Counter = " + counter);
        }
        public static void CountValidPasswordsPartTwo(List<string> stringList)
        {
            var counter = 0;
            stringList.ForEach(line =>
            {
                string[] digits = Regex.Split(line, @"[\s]+");
                var range = digits[0];
                string[] rangeSplitted = Regex.Split(digits[0], @"[\D]");
                var min = rangeSplitted[0];
                var max = rangeSplitted[1];
                var letter = digits[1].Replace(":", "");
                var pass = digits[2];

                if (pass[Int32.Parse(min)-1].Equals(char.Parse(letter)) ^ pass[Int32.Parse(max)-1].Equals(char.Parse(letter)))
                {
                    counter++;
                }
            });
            Console.WriteLine("Counter = " + counter);
        }
    }
}
