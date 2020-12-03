using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace advent_of_code_2020
{
    class DayOne
    {
        /*static void Main(string[] args)
        {

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\domin\source\repos\advent-of-code-2020\day1.txt");
            List<string> stringList = new List<string>(lines);
            checkingTwoNumbersSumsTo2020(stringList);
            checkingThreeNumbersSumsTo2020(stringList);

        }
        */

        public static void checkingTwoNumbersSumsTo2020(List<string> array)
        {

            array.ForEach(number =>
            {
                var intNumber = Int32.Parse(number);
                Debug.WriteLine("Checking " + number);
                int searchedNumber = 2020 - intNumber;
                if (array.Contains(searchedNumber.ToString()))
                {
                    Debug.WriteLine("***** [" + number + "] *****");
                    var multiple = intNumber * searchedNumber;
                    Debug.WriteLine("***** [" + number + "]*[" + searchedNumber + "]=[" + multiple + "] *****");
                }
            });
        }

        public static void checkingThreeNumbersSumsTo2020(List<string> array)
        {
            array.ForEach(numberOne =>
            {
                var firstNumber = Int32.Parse(numberOne);
                Debug.WriteLine("***** [" + numberOne + "] *****");
                var searchedSum = 2020 - firstNumber;
                array.ForEach(numberTwo =>
                {
                    var secondNumber = Int32.Parse(numberTwo);
                    int thirdNumber = searchedSum - secondNumber;
                    if (array.Contains(thirdNumber.ToString()))
                    {
                        var multiple = firstNumber * secondNumber * thirdNumber;
                        Debug.WriteLine("***** [" + firstNumber + "]*[" + secondNumber + "]*[" + thirdNumber + "]=[" + multiple + "] *****");
                    }
                });
            }
            );
        }
    }
}
