using System.Linq;
using System.Collections.Generic;

using System.Text.RegularExpressions;
using System;

namespace advent_of_code_2020
{
    class DaySeven
    {
        /*
        static void Main(string[] args)
        {
            
            string[] Lines = System.IO.File.ReadAllLines(@"C:\Users\domin\source\repos\advent-of-code-2020\day7_1.txt");
            List<string> StringList = new List<string>(Lines);

            FindHowMuchShinyGoldBagCanHandle(StringList);
            
        }
    */
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
            var ShinyGold = DirectBags.Distinct().Count();
            var ElementsCount = 0;
            var ElementsSum = DirectBags.Count();
            var isValueChanged = true;
            var Bags = new List<BagRules>();
            var AllBags = new List<BagRules>();
            while (isValueChanged)
            {
                var InnerBags = new List<BagRules>();
                DirectBags.ForEach(bag =>
                {
                    Bags = FindBags(BagRulesList, bag.MainBag.Replace(" bags contain", ""));
                    InnerBags = InnerBags.Concat(Bags).ToList();
                    AllBags = AllBags.Concat(Bags).ToList();
                });
                DirectBags = InnerBags.Distinct().ToList();
                ElementsCount += InnerBags.Distinct().Count();
                if (InnerBags.Distinct().Count() == 0)
                {
                    isValueChanged = false;
                }
            }
            var All = AllBags.Distinct().Count();
            All = All + ShinyGold - 1;
            ElementsSum += ElementsCount;
            Console.WriteLine("Sum " + All);
        }

        public static void FindHowMuchShinyGoldBagCanHandle(List<string> StringList)
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
            var NumberOfBags = new List<int>();
            var shinyGoldBag = "2 shiny gold bags";
            var firstRatio = new List<int>();
            firstRatio.Add(1);
            var shinyGoldList = new List<String>();
            shinyGoldList.Add(shinyGoldBag);
            var DirectBags = new List<BagRules>();
            var AllBags = new List<int>();
            DirectBags = FindMainRuleByColour(BagRulesList, shinyGoldList);
            NumberOfBags = FindInsideBagsNumber(DirectBags, firstRatio);
            AllBags = AllBags.Concat(NumberOfBags).ToList();
            var ShinyGold = DirectBags.Distinct().Count();
            var ElementsCount = 0;
            var ElementsSum = DirectBags.Count();
            var isValueChanged = true;
            var Bags = new List<BagRules>();


            while (isValueChanged)
            {
                var InnerBags = new List<BagRules>();
                DirectBags.ForEach(bag =>
                {
                    Bags = FindMainRuleByColour(BagRulesList, bag.InsideBags);
                    InnerBags = InnerBags.Concat(Bags).ToList();
                    NumberOfBags = FindInsideBagsNumber(Bags, firstRatio);
                    firstRatio = NumberOfBags;
                    AllBags = AllBags.Concat(NumberOfBags).ToList();
                });
                DirectBags = InnerBags.Distinct().ToList();
                ElementsCount += InnerBags.Distinct().Count();
                if (InnerBags.Distinct().Count() == 0)
                {
                    isValueChanged = false;
                }
            }
            Console.WriteLine("Sum " + AllBags.Sum());

        }

        public static List<BagRules> FindMainRuleByColour(List<BagRules> AllBagRules, List<String> BagColour)
        {
            var DirectBags = new List<BagRules>();

            BagColour.ForEach(colour =>
            {
                colour = Regex.Replace(colour.Substring(2), @"bag[\D]", "").Trim();
                AllBagRules.ForEach(directRule =>
                {
                    if (!String.IsNullOrEmpty(colour))
                    {
                        if (directRule.MainBag.Contains(colour))
                        {
                            DirectBags.Add(directRule);
                        }
                    }
                });
            });

            return DirectBags;
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

        public static List<int> FindInsideBagsNumber(List<BagRules> BagList, List<int> Ratios)
        {
            var Count = new List<int>();
            var IndexCounter = 0;
            var ratio = Ratios.Sum();
            /*
            if (Ratios.Count != 0)
            {
                BagList.ForEach(directRule =>
                {
                    if (BagList.Count() != Ratios.Count())
                    {
                        ratio = Ratios.Sum();
                    }
                    else
                    {
                        ratio = Ratios[IndexCounter];
                    }
                    while (ratio > 0)
                    {
                        Count = Count.Concat(directRule.NumberOfBags).ToList();
                        ratio--;
                    }

                    IndexCounter++;
                });
            */
            BagList.ForEach(directRule =>
            {
                while (ratio > 0)
                {
                    Count = Count.Concat(directRule.NumberOfBags).ToList();
                    ratio--;
                }
            });

            return Count;
        }

        public class BagRules
        {
            public String MainBag { get; set; }
            public List<String> InsideBags { get; set; }
            public List<int> NumberOfBags { get; set; }
        }
    }
}

