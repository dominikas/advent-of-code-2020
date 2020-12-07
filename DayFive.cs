using System.Linq;
using System.Collections.Generic;

using System.Text.RegularExpressions;
using System;

namespace advent_of_code_2020
{
    class DayFive
    {
     /*
        static void Main(string[] args)
        {
            string[] Lines = System.IO.File.ReadAllLines(@"C:\Users\domin\source\repos\advent-of-code-2020\day5.txt");
            List<string> StringList = new List<string>(Lines);

            FindMySeatId(StringList);
        }
     */
        public static void FindHighestSeatId(List<string> stringList)
        {
            var HighestSeatId = 0;
            var SeatsIdsList = new List<int>();
            stringList.ForEach(line =>
            {
                var Row = 0;
                var Column = 0;

                var RowPart = line.Substring(0, 7);

                var Max = 127;
                var Min = 0;

                var Diff = (Max - Min) + 1;

                foreach (char letter in RowPart)
                {
                    if (Diff != 1)
                    {
                        Diff = Diff / 2;
                    }
                    if (letter.Equals(Char.Parse("F")))
                    {
                        Min = Min;
                        Max = Max - Diff;
                    }
                    else if (letter.Equals(Char.Parse("B")))
                    {
                        Min = Min + Diff;
                        Max = Max;
                    }
                    Diff = (Max - Min) + 1;
                }
                Row = Min;
                var ColumnPart = line.Substring(7, 3);
                Max = 7;
                Min = 0;
                Diff = (Max - Min) + 1;
                foreach (char letter in ColumnPart)
                {
                    if (Diff != 1)
                    {
                        Diff = Diff / 2;
                    }
                    if (letter.Equals(Char.Parse("L")))
                    {
                        Min = Min;
                        Max = Max - Diff;
                    }
                    else if (letter.Equals(Char.Parse("R")))
                    {
                        Min = Min + Diff;
                        Max = Max;
                    }
                    Diff = (Max - Min) + 1;
                }
                Column = Min;

                SeatsIdsList.Add((Row * 8) + Column);
            });

            HighestSeatId = SeatsIdsList.Max();

            Console.WriteLine("Highest Id " + HighestSeatId);

            ;
        }

        public static void FindMySeatId(List<string> stringList)
        {
            var SeatsIdsList = new List<int>();
            var RowsList = new List<int>();
            var ColumnList = new List<int>();
            stringList.ForEach(line =>
            {
                var Row = 0;
                var Column = 0;

                var RowPart = line.Substring(0, 7);

                var Max = 127;
                var Min = 0;

                var Diff = (Max - Min) + 1;

                foreach (char letter in RowPart)
                {
                    if (Diff != 1)
                    {
                        Diff = Diff / 2;
                    }
                    if (letter.Equals(Char.Parse("F")))
                    {
                        Min = Min;
                        Max = Max - Diff;
                    }
                    else if (letter.Equals(Char.Parse("B")))
                    {
                        Min = Min + Diff;
                        Max = Max;
                    }
                    Diff = (Max - Min) + 1;
                }
                Row = Min;
                RowsList.Add(Row);

                var ColumnPart = line.Substring(7, 3);

                Max = 7;
                Min = 0;
                Diff = (Max - Min) + 1;
                foreach (char letter in ColumnPart)
                {
                    if (Diff != 1)
                    {
                        Diff = Diff / 2;
                    }
                    if (letter.Equals(Char.Parse("L")))
                    {
                        Min = Min;
                        Max = Max - Diff;
                    }
                    else if (letter.Equals(Char.Parse("R")))
                    {
                        Min = Min + Diff;
                        Max = Max;
                    }
                    Diff = (Max - Min) + 1;
                }
                Column = Min;
                ColumnList.Add(Column);

                SeatsIdsList.Add((Row * 8) + Column);
            });

            RowsList.Sort();
            ColumnList.Sort();

            foreach (int Row in RowsList)
            {
                if (RowsList.Count(x => x == Row) != 8)
                {
                    Console.WriteLine("Diff for row " + Row);
                }
            }

            foreach (int Col in ColumnList)
            {
                if (ColumnList.Count(x => x == Col) != 102)
                {
                    Console.WriteLine("Diff for col " + Col);
                }
            }

        }
    }
}

