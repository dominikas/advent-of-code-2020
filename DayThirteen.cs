using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace advent_of_code_2020
{
    class DayThirteen
    {
        /*
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");
            string[] Lines = System.IO.File.ReadAllLines(@"C:\Users\domin\source\repos\advent-of-code-2020\inputs\day13.txt");
            List<string> StringList = new List<string>(Lines);
            FindEarliestBus(StringList);
            

        }
        */
        public static void FindEarliestBus(List<String> Instructions)
        {
            var Timestamp = Int32.Parse(Instructions[0]);
            var BusIds = Instructions[1];
            var BusIdsList = new List<String>();
            var DifferenceAndMultipleList = new List<DifferenceAndMultiple>();

            var DifferencesList = new List<int>();
            var DifferencesMultipliedById = new List<int>();
            BusIdsList = Regex.Matches(BusIds, @"[0-9]*").Cast<Match>()
                            .Select(m => m.Value)
                            .ToList();

            BusIdsList.ForEach(line =>
            {
                if (!String.IsNullOrEmpty(line))
                {
                    var element = new DifferenceAndMultiple();
                    var Divider = Int32.Parse(line);
                    var ClosestDivisableNumber = FindClosestDivisableNumber(Timestamp, Divider);
                    var Difference = ClosestDivisableNumber - Timestamp;
                    element.Difference = Difference;
                    element.Multiple = Difference * Divider;
                    DifferenceAndMultipleList.Add(element);
                }
            });
            var FinalList = DifferenceAndMultipleList.OrderBy(o => o.Difference).ToList();
            Console.WriteLine(FinalList[0].Multiple);
        }

        private static int FindClosestDivisableNumber(int TimeStamp, int Divider)
        {
            var ClosestDivisableNumber = TimeStamp;

            while (ClosestDivisableNumber % Divider != 0)
            {
                ClosestDivisableNumber++;
            };

            return ClosestDivisableNumber;
        }

        public class DifferenceAndMultiple
        {
            public int Difference { get; set; }
            public int Multiple { get; set; }
        }

    }

}
