using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace advent_of_code_2020
{
    class DayTwelve
    {
        /*
        static void Main(string[] args)
        {
            
            string[] Lines = System.IO.File.ReadAllLines(@"C:\Users\domin\source\repos\advent-of-code-2020\inputs\day12.txt");
            List<string> StringList = new List<string>(Lines);
            FindManhattanDistance(StringList);
            
        }
        */
        public static void FindManhattanDistance(List<String> StringList)
        {
            var InstructionList = ExtractInstructions(StringList);
            var EastValue = 0;
            var EastWestValueDir = 1;
            var NorthValue = 0;
            var NorthSouthDir = 0;

            InstructionList.ForEach(instr =>
            {
                switch (instr.Direction)
                {
                    case "N":
                        NorthValue = NorthValue + instr.Value;
                        break;
                    case "S":
                        NorthValue = NorthValue - instr.Value;
                        break;
                    case "E":
                        EastValue = EastValue + instr.Value;
                        break;
                    case "W":
                        EastValue = EastValue - instr.Value;
                        break;
                    case "R":
                        if (instr.Value == 90)
                        {
                            if (EastWestValueDir == 1)
                            {
                                EastWestValueDir = 0;
                                NorthSouthDir = -1;
                            }
                            else if (NorthSouthDir == -1)
                            {
                                NorthSouthDir = 0;
                                EastWestValueDir = -1;
                            }
                            else if (EastWestValueDir == -1)
                            {
                                EastWestValueDir = 0;
                                NorthSouthDir = 1;
                            }
                            else if (NorthSouthDir == 1)
                            {
                                NorthSouthDir = 0;
                                EastWestValueDir = 1;
                            }
                        }
                        else if (instr.Value == 180)
                        {
                            if (EastWestValueDir == 1)
                            {
                                EastWestValueDir = -1;
                                NorthSouthDir = 0;
                            }
                            else if (NorthSouthDir == -1)
                            {
                                NorthSouthDir = 1;
                                EastWestValueDir = 0;
                            }
                            else if (EastWestValueDir == -1)
                            {
                                EastWestValueDir = 1;
                                NorthSouthDir = 0;
                            }
                            else if (NorthSouthDir == 1)
                            {
                                NorthSouthDir = -1;
                                EastWestValueDir = 0;
                            }
                        }
                        else if (instr.Value == 270)
                        {
                            if (EastWestValueDir == 1)
                            {
                                EastWestValueDir = 0;
                                NorthSouthDir = 1;
                            }
                            else if (NorthSouthDir == -1)
                            {
                                NorthSouthDir = 0;
                                EastWestValueDir = 1;
                            }
                            else if (EastWestValueDir == -1)
                            {
                                EastWestValueDir = 0;
                                NorthSouthDir = -1;
                            }
                            else if (NorthSouthDir == 1)
                            {
                                NorthSouthDir = 0;
                                EastWestValueDir = -1;
                            }
                        }
                        break;
                    case "L":
                        if (instr.Value == 90)
                        {
                            if (EastWestValueDir == 1)
                            {
                                EastWestValueDir = 0;
                                NorthSouthDir = 1;
                            }
                            else if (NorthSouthDir == 1)
                            {
                                NorthSouthDir = 0;
                                EastWestValueDir = -1;
                            }
                            else if (EastWestValueDir == -1)
                            {
                                EastWestValueDir = 0;
                                NorthSouthDir = -1;
                            }
                            else if (NorthSouthDir == -1)
                            {
                                NorthSouthDir = 0;
                                EastWestValueDir = 1;
                            }
                        }
                        else if (instr.Value == 180)
                        {
                            if (EastWestValueDir == 1)
                            {
                                EastWestValueDir = -1;
                                NorthSouthDir = 0;
                            }
                            else if (NorthSouthDir == -1)
                            {
                                NorthSouthDir = 1;
                                EastWestValueDir = 0;
                            }
                            else if (EastWestValueDir == -1)
                            {
                                EastWestValueDir = 1;
                                NorthSouthDir = 0;
                            }
                            else if (NorthSouthDir == 1)
                            {
                                NorthSouthDir = -1;
                                EastWestValueDir = 0;
                            }
                        }
                        else if (instr.Value == 270)
                        {
                            if (EastWestValueDir == 1)
                            {
                                EastWestValueDir = 0;
                                NorthSouthDir = -1;
                            }
                            else if (NorthSouthDir == -1)
                            {
                                NorthSouthDir = 0;
                                EastWestValueDir = -1;
                            }
                            else if (EastWestValueDir == -1)
                            {
                                EastWestValueDir = 0;
                                NorthSouthDir = 1;
                            }
                            else if (NorthSouthDir == 1)
                            {
                                NorthSouthDir = 0;
                                EastWestValueDir = 1;
                            }
                        }
                        break;
                    case "F":
                        NorthValue = NorthValue + NorthSouthDir * instr.Value;
                        EastValue = EastValue + EastWestValueDir * instr.Value;
                        break;
                }
                Console.WriteLine("instr " + instr.Direction+instr.Value);
                Console.WriteLine("x= " + EastValue);
                Console.WriteLine("y= " + NorthValue);
                Console.WriteLine("Dir NS " + NorthSouthDir);
                Console.WriteLine("Dir EW " + EastWestValueDir);
                Console.WriteLine("");
            });
        }

        private static List<Instruction> ExtractInstructions(List<String> Instructions)
        {
            var InstructionList = new List<Instruction>();

            Instructions.ForEach(line =>
            {
                var Instr = new Instruction();
                if (!String.IsNullOrEmpty(line))
                {
                    Instr.Direction = Regex.Match(line, @"[A-Z]").Value;
                    Instr.Value = Int32.Parse(line.Substring(1));
                }
                InstructionList.Add(Instr);
            });

            return InstructionList;
        }

        public class Instruction
        {
            public String Direction { get; set; }
            public int Value { get; set; }

        }
    }
}
