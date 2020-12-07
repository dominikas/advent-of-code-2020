using System.Linq;
using System.Collections.Generic;

using System.Text.RegularExpressions;
using System;

namespace advent_of_code_2020
{
    class DaySeven
    {

        static void Main(string[] args)
        {
            string[] Lines = System.IO.File.ReadAllLines(@"C:\Users\domin\source\repos\advent-of-code-2020\day7.txt");
            List<string> StringList = new List<string>(Lines);

            FindBagsColourNumber(StringList);
        }

        public static void FindBagsColourNumber(List<string> StringList)
        {
            var BagRulesList = new List<BagRules>();
            StringList.ForEach(line =>
            {
                var Rule = new BagRules();
                Rule.InsideBags = new List<String>();
                Rule.NumberOfBags = new List<int>();
                if (!String.IsNullOrEmpty(line))
                {
                    Rule.MainBag = Regex.Match(line, @"\w* \w* bags contain").Value;
                    Regex.Matches(line, @"[0-9] \w* \w* bag[\D]").ToList().ForEach(match =>
                    {
                        Rule.InsideBags.Add(match.Value);
                        Rule.NumberOfBags.Add(Int32.Parse(match.Value.Substring(0, 1)));
                    });

                }
                BagRulesList.Add(Rule);
            });
            BagRulesList.Count();
            String shinyGoldBag = "shiny gold";
            var DirectBags = new List<BagRules>();

            DirectBags = FindBags(BagRulesList, shinyGoldBag);
            var ElementsCount = 0;
            var ElementsSum = DirectBags.Count();
            var isValueChanged = true;
            var Bags = new List<BagRules>();

            while (isValueChanged)
            {
                var InnerBags = new List<BagRules>();
                DirectBags.ForEach(bag =>
                {
                    Bags = FindBags(BagRulesList, bag.MainBag.Replace(" bags contain", ""));
                    InnerBags = InnerBags.Concat(Bags).ToList();
                });
                DirectBags = InnerBags.Distinct().ToList();
                ElementsCount += InnerBags.Distinct().Count();
                if (InnerBags.Distinct().Count() == 0)
                {
                    isValueChanged = false;
                }
            }

            ElementsSum += ElementsCount;
            Console.WriteLine("Sum " + ElementsSum);
        }

        public static List<BagRules> FindBags(List<BagRules> AllBagRules, String BagColour)
        {
            var DirectBags = new List<BagRules>();

            AllBagRules.ForEach(directRule =>
            {
                if (directRule.InsideBags.Find(Bag => Bag.Contains(BagColour)) != null)
                {
                    DirectBags.Add(directRule);
                }
            });
            return DirectBags;
        }
        public class BagRules
        {
            public String MainBag { get; set; }
            public List<String> InsideBags { get; set; }
            public List<int> NumberOfBags { get; set; }
        }
    }
}

