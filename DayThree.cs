using System.Linq;
using System.Collections.Generic;

using System.Text.RegularExpressions;
using System;

namespace advent_of_code_2020
{
    class DayThree
    {/*
        static void Main(string[] args)
        {

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\domin\source\repos\advent-of-code-2020\inputs\day3.txt");
            List<string> stringList = new List<string>(lines);

            var FirstTree = CountTreesPartOne(stringList, 1, 1);
            var SecondTree = CountTreesPartOne(stringList, 3, 1);
            var ThirdTree = CountTreesPartOne(stringList, 5, 1);
            var Fourth = CountTreesPartOne(stringList, 7, 1);
            var Fifth = CountTreesPartOne(stringList, 1, 2);

            var Multiple = FirstTree * SecondTree * ThirdTree * Fourth * Fifth;
            Console.Write("Multiple " + Multiple);
        
        }
    */
        public static double CountTreesPartOne(List<string> stringList, int Right, int Down)
        {
            var TreeCounter = 0;
            var ColumnIndex = Right;
            for (var RowIndex = Down; RowIndex < stringList.Count(); RowIndex = RowIndex + Down)
            {
                var line = stringList[RowIndex];
                if (ColumnIndex < line.Length)
                {
                    if (Char.Parse(line[ColumnIndex].ToString()).Equals(Char.Parse("#")))
                    {
                        TreeCounter++;
                    }
                    var diff = line.Length - 1 - ColumnIndex;
                    if (diff < Right)
                    {
                        ColumnIndex = (Right - 1) - diff;
                    }
                    else
                    {
                        ColumnIndex = ColumnIndex + Right;
                    }
                }

            }
            Console.WriteLine("Counter = " + TreeCounter);

            return TreeCounter;
        }
    }
}
