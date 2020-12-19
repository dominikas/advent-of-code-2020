using System.Linq;
using System.Collections.Generic;

using System.Text.RegularExpressions;
using System;

namespace advent_of_code_2020
{
    class DayFifteen
    {
        static void Main(string[] args)
        {

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\domin\source\repos\advent-of-code-2020\inputs\day15.txt");
            List<string> StringList = new List<string>(lines);
            PlayMemoryGame(StringList);
        }

        public static void PlayMemoryGame(List<string> InputList)
        {
            var InputNumbers = new List<Number>();

            for (int i = 0; i < InputList.Count(); i++)
            {
                var Element = new Number();
                Element.Value = Int32.Parse(InputList[i]);
                Element.Index = i + 1;
                InputNumbers.Add(Element);
            }

            int Counter = InputNumbers.Count() + 1;
            while (InputNumbers.Count() != 2020)
            {
                int LastNumber = InputNumbers[InputNumbers.Count() - 1].Value;
                if (InputNumbers.Count(x => x.Value == LastNumber) == 1)
                {
                    var ZeroElement = new Number();
                    ZeroElement.Value = 0;
                    ZeroElement.Index = Counter;
                    InputNumbers.Add(ZeroElement);
                }
                else
                {
                    var Element = new Number();
                    var OccurencesList = InputNumbers.FindAll(x => x.Value == LastNumber);
                    OccurencesList.Reverse();
                    Element.Index = Counter;
                    Element.Value = OccurencesList[0].Index - OccurencesList[1].Index;
                    InputNumbers.Add(Element);
                }

                Counter++;
            }
            Console.WriteLine("2020th number is " + InputNumbers.Last().Value);
        }

        public class Number
        {
            public int Value { get; set; }
            public int Index { get; set; }
        }
    }
}
