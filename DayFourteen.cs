using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace advent_of_code_2020
{
    class DayFourteen
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string[] Lines = System.IO.File.ReadAllLines(@"C:\Users\domin\source\repos\advent-of-code-2020\day14_1.txt");
            List<string> StringList = new List<string>(Lines);
            RunDockingProgram(StringList);
        }

        public static void RunDockingProgram(List<String> StringList)
        {
            var DockingDataList = new List<DockingData>();
            DockingDataList = ExtractData(StringList);
            DockingDataList = ConvertValueToBinary(DockingDataList);
            var Memory = new string[66000];
            DockingDataList.ForEach(data =>
            {
                Memory = UseMask(data, Memory);
            });
            SumOfMemoryElements(Memory);
        }


        private static List<DockingData> ExtractData(List<String> InputList)
        {
            var DockingDataList = new List<DockingData>();
            var element = new DockingData();
            element.MemoryList = new List<Memory>();
            var memoryELement = new Memory();
            var MaskCounter = 0;
            InputList.ForEach(line =>
            {
                if (line.Contains("mask"))
                {
                    MaskCounter++;
                    if (MaskCounter == 2)
                    {
                        DockingDataList.Add(element);
                        MaskCounter = 1;
                        element = new DockingData();
                        element.MemoryList = new List<Memory>();
                    }
                    var mask = Regex.Split(line, @"mask = (.*)").ToList()[1].ToString();
                    element.Mask = mask;
                }
                else if (line.Contains("mem"))
                {
                    memoryELement = new Memory();
                    var Value = Regex.Match(line, @"= [0-9]*").Value.Replace("= ", "");
                    var Index = Regex.Match(line, @"\[[0-9]*\]").Value.Replace("[", "").Replace("]", "");
                    memoryELement.Value = Int32.Parse(Value);
                    memoryELement.Index = Int32.Parse(Index);
                    element.MemoryList.Add(memoryELement);
                }
            });
            DockingDataList.Add(element);
            return DockingDataList;

        }
        private static List<DockingData> ConvertValueToBinary(List<DockingData> Input)
        {
            var ChangedInput = Input;
            var ZeroMask = "000000000000000000000000000000000000";
            var FinalBit = "";
            var TestOfZeros = "";

            ChangedInput.ForEach(element =>
            {
                element.MemoryList.ForEach(value =>
                {
                    var BitValue = Convert.ToString(value.Value, 2);
                    if (BitValue.Count() != 36)
                    {
                        TestOfZeros = ZeroMask.Substring(BitValue.Count());
                        FinalBit = String.Concat(TestOfZeros, BitValue);
                        value.BitValue = FinalBit;
                    }
                });
            });

            return ChangedInput;
        }

        private static string[] UseMask(DockingData input, string[] MemoryInput)
        {
            var output = input;
            var MemoryOutput = MemoryInput;
            var ResultAlfa = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            output.MemoryList.ForEach(element =>
            {
                for (int i = 0; i < element.BitValue.Count(); i++)
                {
                    if (input.Mask[i].Equals(Char.Parse("X")))
                    {
                        StringBuilder sb = new StringBuilder(ResultAlfa);
                        sb[i] = element.BitValue[i];
                        ResultAlfa = sb.ToString();
                    }
                    else if (input.Mask[i].Equals(Char.Parse("0")))
                    {
                        StringBuilder sb = new StringBuilder(ResultAlfa);
                        sb[i] = Char.Parse("0");
                        ResultAlfa = sb.ToString();
                    }
                    else if (input.Mask[i].Equals(Char.Parse("1")))
                    {
                        StringBuilder sb = new StringBuilder(ResultAlfa);
                        sb[i] = Char.Parse("1");
                        ResultAlfa = sb.ToString();
                    }
                }
                element.Result = ResultAlfa;
                MemoryOutput[element.Index] = ResultAlfa;
            });
            return MemoryOutput;
        }

        private static double SumOfMemoryElements(string[] MemoryInput)
        {
            double Sum = 0;
            foreach (string element in MemoryInput)
            {
                if (element != null)
                {
                    Sum += Convert.ToInt64(element, 2);
                }
            }
            Console.WriteLine("Sum " + Sum);
            return Sum;
        }
        public class DockingData
        {
            public string Mask { get; set; }
            public List<Memory> MemoryList { get; set; }
        }

        public class Memory
        {
            public int Value { get; set; }
            public String BitValue { get; set; }
            public int Index { get; set; }
            public String Result { get; set; }
        }

    }



}
