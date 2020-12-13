using System;
using System.Linq;
using System.Collections.Generic;

namespace advent_of_code_2020
{
    class DayTen
    {
        /*
        static void Main(string[] args)
        {
            string[] Lines = System.IO.File.ReadAllLines(@"C:\Users\domin\source\repos\advent-of-code-2020\day10.txt");
            List<string> StringList = new List<string>(Lines);
            CountAdapter(StringList);

        }
        */
        public static void CountAdapter(List<String> StringList)
        {
            var JoltsList = new List<int>();
            var DiffList = new List<int>();

            StringList.ForEach(line =>
            {
                JoltsList.Add(Int32.Parse(line));
            });
            JoltsList.Add(0);

            JoltsList.Sort();
            JoltsList.Add(JoltsList.Last() + 3);
            for (int i = 1; i < JoltsList.Count; i++)
            {
                DiffList.Add(JoltsList[i] - JoltsList[i - 1]);
            }

            var OnesCounter = DiffList.Count(x => x == 1);
            var ThreeCounter = DiffList.Count(x => x == 3);

            Console.WriteLine("Ones Counter " + OnesCounter);
            Console.WriteLine("Threes Counter " + ThreeCounter);
        }

    }
}
