using System.Linq;
using System.Collections.Generic;

using System.Text.RegularExpressions;
using System;

namespace advent_of_code_2020
{
    class DaySixteen
    {
        static void Main(string[] args)
        {

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\domin\source\repos\advent-of-code-2020\inputs\day16.txt");
            List<string> StringList = new List<string>(lines);
            string[] nearbyTickets = System.IO.File.ReadAllLines(@"C:\Users\domin\source\repos\advent-of-code-2020\inputs\day16_nearby.txt");
            List<string> nearbyTicketsList = new List<string>(nearbyTickets);

            var Rules = ExtractRules(StringList);
            var NearbyTickets = ExtractNearbyTickets(nearbyTicketsList);
            var ErrorRate = CheckValidityOfTickets(Rules, NearbyTickets);
            Console.WriteLine("Error rate = " + ErrorRate);

        }

        public static List<Range> ExtractRules(List<string> StringList)
        {
            var RangesList = new List<Range>();
            StringList.ForEach(line =>
            {
                var Values = Regex.Matches(line, @"[\d]*-[\d]*").ToList();
                Values.ForEach(x =>
                {
                    var Element = new Range();
                    var Numbers = Regex.Matches(x.Value, @"[\d]*").ToList();
                    Element.MinValue = Int32.Parse(Numbers[0].Value);
                    Element.MaxValue = Int32.Parse(Numbers[2].Value);
                    RangesList.Add(Element);
                });

            });

            return RangesList;
        }

        public static List<Ticket> ExtractNearbyTickets(List<string> StringList)
        {
            var NerabyTicketsList = new List<Ticket>();

            StringList.ForEach(line =>
            {
                var TicketNumbers = Regex.Matches(line, @"[\d]*").ToList();
                TicketNumbers.ForEach(ticket =>
                {
                    if (!String.IsNullOrEmpty(ticket.Value))
                    {
                        var Ticket = new Ticket();
                        Ticket.Number = Int32.Parse(ticket.Value);
                        Ticket.IsValid = false;
                        NerabyTicketsList.Add(Ticket);
                    }
                });
            });

            return NerabyTicketsList;
        }

        public static int CheckValidityOfTickets(List<Range> RangeList, List<Ticket> TicketList)
        {
            var NumberOfInvalidTickets = 0;
            var RulesCounter = 0;
            TicketList.ForEach(ticket =>
            {
                while (RulesCounter < RangeList.Count())
                {
                    if (ticket.Number >= RangeList[RulesCounter].MinValue && ticket.Number <= RangeList[RulesCounter].MaxValue)
                    {
                        ticket.IsValid = true;
                        break;
                    }
                    RulesCounter++;
                }
                RulesCounter = 0;
            });
            var InvalidTicketsList = TicketList.FindAll(x => x.IsValid == false);
            var ErrorRate = 0;
            InvalidTicketsList.ForEach(x =>
            {
                ErrorRate += x.Number;
            });
            return ErrorRate;
        }
        public class Range
        {
            public int MaxValue { get; set; }
            public int MinValue { get; set; }
        }
        public class Ticket
        {
            public int Number { get; set; }
            public bool IsValid { get; set; }
        }
    }
}
