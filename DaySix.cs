using System.Linq;
using System.Collections.Generic;

using System.Text.RegularExpressions;
using System;

namespace advent_of_code_2020
{
    class DaySix
    {

        static void Main(string[] args)
        {
            string[] Lines = System.IO.File.ReadAllLines(@"C:\Users\domin\source\repos\advent-of-code-2020\day6.txt");
            List<string> StringList = new List<string>(Lines);

            var Sum = FindSumOfQuestionsEveryoneAnswer(StringList);
            Console.WriteLine("The sum is " + Sum);
        }

        public static int FindSumOfQuestions(List<string> StringList)
        {
            var GroupsList = new List<String>();
            var GroupsAnswers = String.Empty;
            var LineCounter = 0;
            StringList.ForEach(Line =>
            {
                if (!String.IsNullOrEmpty(Line))
                {
                    GroupsAnswers += Line;
                    if (LineCounter == StringList.Count - 1)
                    {
                        GroupsList.Add(GroupsAnswers);
                    }
                }
                else
                {
                    GroupsList.Add(GroupsAnswers);
                    GroupsAnswers = String.Empty;
                }
                LineCounter++;
            });

            var GroupsAnswersList = new List<int>();
            var DistinctSum = 0;
            GroupsList.ForEach(answers =>
            {
                var Count = answers.Distinct().Count();
                DistinctSum += Count;
            });

            return DistinctSum;
        }

        public static int FindSumOfQuestionsEveryoneAnswer(List<string> StringList)
        {
            var GroupsList = new List<String>();
            var PeopleCounterList = new List<int>();
            var GroupsAnswers = String.Empty;
            var LineCounter = 0;
            var PeopleCounter = 0;
            StringList.ForEach(Line =>
            {
                if (!String.IsNullOrEmpty(Line))
                {
                    GroupsAnswers += Line;
                    PeopleCounter++;
                    if (LineCounter == StringList.Count - 1)
                    {
                        GroupsList.Add(GroupsAnswers);
                        PeopleCounterList.Add(PeopleCounter);
                    }
                }
                else
                {
                    GroupsList.Add(GroupsAnswers);
                    PeopleCounterList.Add(PeopleCounter);
                    GroupsAnswers = String.Empty;
                    PeopleCounter = 0;
                }
                LineCounter++;
            });

            var GroupsAnswersList = new List<int>();
            var DistinctSum = 0;
            LineCounter = 0;
            GroupsList.ForEach(answers =>
            {
                answers.Distinct().ToList().ForEach(element =>
                {
                    var count = answers.Count(x => x.Equals(element));
                    if (count == PeopleCounterList[LineCounter])
                    {
                        DistinctSum++;
                    }
                });
                LineCounter++;
            });

            return DistinctSum;
        }

    }
}

