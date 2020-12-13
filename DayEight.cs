using System;
using System.Linq;
using System.Collections.Generic;

using System.Text.RegularExpressions;

namespace advent_of_code_2020
{
    class DayEight
    {
        /*
        static void Main(string[] args)
        {
            string[] Lines = System.IO.File.ReadAllLines(@"C:\Users\domin\source\repos\advent-of-code-2020\day8.txt");
            List<string> StringList = new List<string>(Lines);
            RunInstructions(StringList);
        }
        */
        public static void RunInstructions(List<String> Instructions)
        {
            var InstructionList = ExtractInstructions(Instructions);
            double Accumulator = 0;
            double Index = 0;

            while (!InstructionList[Convert.ToInt32(Index)].hasRun)
            {
                InstructionList[Convert.ToInt32(Index)].hasRun = true;
                var instr = InstructionList[Convert.ToInt32(Index)];

                if (instr.InstructionName.Equals("nop"))
                {
                    Index++;
                }
                else if (instr.InstructionName.Equals("acc"))
                {
                    if (instr.Sign.Equals("+"))
                    {
                        Accumulator = Accumulator + instr.Number;
                    }
                    else if (instr.Sign.Equals("-"))
                    {
                        Accumulator = Accumulator - instr.Number;
                    }
                    Index++;
                }
                else if (instr.InstructionName.Equals("jmp"))
                {
                    if (instr.Sign.Equals("+"))
                    {
                        Index = Index + instr.Number;
                    }
                    else if (instr.Sign.Equals("-"))
                    {
                        Index = Index - instr.Number;
                    }
                    
                }

            }

            Console.WriteLine("Accumulator " + Accumulator);
        }

        private static List<Instruction> ExtractInstructions(List<String> Instructions)
        {
            var InstructionList = new List<Instruction>();

            Instructions.ForEach(line =>
            {
                var Instr = new Instruction();
                if (!String.IsNullOrEmpty(line))
                {
                    Instr.InstructionName = Regex.Match(line, @"[a-z]{3}").Value;
                    Instr.Sign = Regex.Match(line, @"(\+|\-)").Value;
                    Instr.Number = Int32.Parse(Regex.Match(line, @"[0-9]+").Value);
                    Instr.hasRun = false;
                }
                InstructionList.Add(Instr);
            });

            return InstructionList;
        }

        public class Instruction
        {
            public String InstructionName { get; set; }
            public String Sign { get; set; }
            public double Number { get; set; }
            public bool hasRun { get; set; }
        }
    }
}
