using System;
using System.Collections.Generic;
using static System.Console;

namespace TimeInWords
{
    class Program
    {
        private static void Fill(ICollection<Clocks> list)
        {
            list.Add(new Clocks(1, "one"));
            list.Add(new Clocks(2, "two"));
            list.Add(new Clocks(3, "thee"));
            list.Add(new Clocks(4, "four"));
            list.Add(new Clocks(5, "five"));
            list.Add(new Clocks(6, "six"));
            list.Add(new Clocks(7, "seven"));
            list.Add(new Clocks(8, "eight"));
            list.Add(new Clocks(9, "nine"));
            list.Add(new Clocks(10, "ten"));
            list.Add(new Clocks(11, "eleven"));
            list.Add(new Clocks(12, "twelve"));
            list.Add(new Clocks(13, "thirteen"));
            list.Add(new Clocks(14, "fourteen"));
            list.Add(new Clocks(15, "fifteen"));
            list.Add(new Clocks(16, "sixteen"));
            list.Add(new Clocks(17, "seventeen"));
            list.Add(new Clocks(18, "eighteen"));
            list.Add(new Clocks(19, "nineteen"));
            list.Add(new Clocks(20, "twenty"));
        }

        private struct Clocks
        {
            public int Value;
            public string Name;

            public Clocks(int value, string name)
            {
                Value = value;
                Name = name;
            }

            public override string ToString()
            {
                return Name + " " + Value;
            }
        }

        private static void Main()
        {
            const string oclock = "o`clock";
            var h = Convert.ToInt32("5");
            var m = Convert.ToInt32("59"); // 28 to 60 - 32 


            var clocks = new List<Clocks>();
            Fill(clocks);

            string hourName;
            string minuteName;
            string minuteStr;

            switch (m)
            {
                case 0:
                    hourName = clocks.Find(clock => clock.Value == h).Name;
                    WriteLine(hourName + " " + oclock);
                    break;
                case 15:
                    hourName = clocks.Find(clock => clock.Value == h).Name;
                    WriteLine("quarter past " + hourName);
                    break;
                case 30:
                    hourName = clocks.Find(clock => clock.Value == h).Name;
                    WriteLine("half past " + hourName);
                    break;
                case 45:
                    hourName = clocks.Find(clock => clock.Value == h + 1).Name;
                    WriteLine("quarter to " + hourName);
                    break;
                case >=1 and <=20:
                    hourName = clocks.Find(clock => clock.Value == h).Name;
                    minuteName = clocks.Find(clock => clock.Value == m).Name;
                    minuteStr = m == 1 ? " minute" : "minutes";
                    WriteLine(minuteName + minuteStr + " past " + hourName);
                    break;
                case >= 21 and <=29:
                    hourName = clocks.Find(clock => clock.Value == h).Name;
                    minuteName = clocks.Find(clock => clock.Value == m - (m / 10) * 10).Name;
                    WriteLine("twenty " + minuteName + " minutes past " + hourName);
                    break;
                case >= 31 and <=39:
                    hourName = clocks.Find(clock => clock.Value == h + 1).Name;
                    minuteName = clocks.Find(clock => clock.Value == 60 - m - ((60 - m) / 10) * 10).Name;
                    WriteLine("twenty " + minuteName + " minutes to " + hourName);
                    break;
                case >= 40 and <=59:
                    hourName = clocks.Find(clock => clock.Value == h + 1).Name;
                    minuteName = clocks.Find(clock => clock.Value == 60 - m).Name;
                    minuteStr = 60 - m == 1 ? " minute" : "minutes";
                    WriteLine(minuteName + minuteStr + " to " + hourName);
                    break;
            }
        }
    }
}