using System.Linq;
using System.Collections.Generic;

using System.Text.RegularExpressions;
using System;

namespace advent_of_code_2020
{
    class DayFour
    {
        static void Main(string[] args)
        {
            string[] Lines = System.IO.File.ReadAllLines(@"C:\Users\domin\source\repos\advent-of-code-2020\day4.txt");
            List<string> StringList = new List<string>(Lines);
            var ValidPassports = CountValidPassportsPartTwo(StringList);
            Console.Write("Valid Pasports " + ValidPassports);
        }

        public static double CountValidPassportsPartOne(List<string> stringList)
        {
            var ElementsCounter = 0;
            var PassportsCounter = 0;

            stringList.ForEach(line =>
            {
                if (!String.IsNullOrEmpty(line))
                {
                    if (line.Contains("byr"))
                    {
                        ElementsCounter++;
                    }
                    if (line.Contains("iyr"))
                    {
                        ElementsCounter++;
                    }
                    if (line.Contains("eyr"))
                    {
                        ElementsCounter++;
                    }
                    if (line.Contains("hgt"))
                    {
                        ElementsCounter++;
                    }

                    if (line.Contains("ecl"))
                    {
                        ElementsCounter++;
                    }
                    if (line.Contains("pid"))
                    {
                        ElementsCounter++;
                    }
                    if (line.Contains("hcl"))
                    {
                        ElementsCounter++;
                    }
                }
                else
                {
                    if (ElementsCounter == 7)
                    {
                        PassportsCounter++;
                    }
                    ElementsCounter = 0;
                }
            });
            return PassportsCounter;
        }

        public static double CountValidPassportsPartTwo(List<string> stringList)
        {
            var ElementsCounter = 0;
            var PassportsCounter = 0;
            var LineCounter = 0;
            stringList.ForEach(line =>
            {
                LineCounter++;
                if (!String.IsNullOrEmpty(line))
                {
                    if (line.Contains("byr"))
                    {
                        var ByrValue = Regex.Match(line, @"byr:\d{4}").ToString().Replace("byr:", "");
                        if (Int32.Parse(ByrValue) >= 1920 && Int32.Parse(ByrValue) <= 2002)
                        {
                            ElementsCounter++;
                        }
                    }
                    if (line.Contains("iyr"))
                    {
                        var IyrValue = Regex.Match(line, @"iyr:\d{4}").ToString().Replace("iyr:", "");
                        if (Int32.Parse(IyrValue) >= 2010 && Int32.Parse(IyrValue) <= 2020)
                        {
                            ElementsCounter++;
                        }
                    }
                    if (line.Contains("eyr"))
                    {
                        var EyrValue = Regex.Match(line, @"eyr:\d{4}").ToString().Replace("eyr:", "");
                        if (Int32.Parse(EyrValue) >= 2020 && Int32.Parse(EyrValue) <= 2030)
                        {
                            ElementsCounter++;
                        }
                    }
                    if (line.Contains("hgt"))
                    {
                        var HgtCmValue = Regex.Match(line, @"hgt:[0-9]{3}cm").ToString().Replace("hgt:", "").Replace("cm", "");
                        var HgtInValue = Regex.Match(line, @"hgt:[0-9]{2}in").ToString().Replace("hgt:", "").Replace("in", "");
                        if (!String.IsNullOrEmpty(HgtCmValue))
                        {
                            if (Int32.Parse(HgtCmValue) >= 150 && Int32.Parse(HgtCmValue) <= 193)
                            {
                                ElementsCounter++;
                            }
                        }
                        if (!String.IsNullOrEmpty(HgtInValue))
                        {
                            if (Int32.Parse(HgtInValue) >= 59 && Int32.Parse(HgtInValue) <= 76)
                            {
                                ElementsCounter++;
                            }
                        }

                    }
                    if (line.Contains("hcl"))
                    {
                        var HclValue = Regex.Match(line, @"hcl:#[0-9a-f]{6}").ToString(); ;
                        if (!String.IsNullOrEmpty(HclValue))
                        {
                            ElementsCounter++;
                        }
                    }
                    if (line.Contains("ecl"))
                    {
                        var EclValue = Regex.Match(line, @"ecl:[a-z]*").ToString().Replace("ecl:", "");
                        if (EclValue.Equals("amb") || EclValue.Equals("blu") || EclValue.Equals("brn") || EclValue.Equals("gry")
                        || EclValue.Equals("grn") || EclValue.Equals("hzl") || EclValue.Equals("oth"))
                        {
                            ElementsCounter++;
                        }
                    }
                    if (line.Contains("pid"))
                    {
                        var PidValue = Regex.Match(line, @"pid:[\d]*").ToString().Replace("pid:", "");
                        if (!String.IsNullOrEmpty(PidValue) && PidValue.Length == 9)
                        {
                            ElementsCounter++;
                        }
                    }
                }
                else
                {
                    if (ElementsCounter == 7)
                    {
                        PassportsCounter++;
                    }
                    ElementsCounter = 0;
                }
            });
            return PassportsCounter;
        }
    }
}

