using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_of_code_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<int> a = new List<int>();
            List<int> b = new List<int>();
            List<char> c = new List<char>();
            List<string> s = new List<string>();
            using (StreamReader sr = new StreamReader("e"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] lineSplit = line.Split(" ");
                    string[] things = lineSplit[0].Split("-");
                    a.Add(Convert.ToInt32(things[0]));
                    b.Add(Convert.ToInt32(things[1]));
                    c.Add(lineSplit[1][0]);
                    s.Add(lineSplit[2]);
                }
            }
            int valid = 0;
            for (int aa = 0; aa < s.Count; aa++)
            {
                int times = s[aa].Count(s => s == c[aa]);
                //  Console.WriteLine($"times {c[aa]} is in {s[aa]}: {times}     {a[aa]}-{b[aa]}");
                if (times >= a[aa] && times <= b[aa])
                {
                    valid++;
                }
            }
            Console.WriteLine(valid);
            valid = 0;

            for (int aa = 0; aa < s.Count; aa++)
            {
                bool ta = s[aa][a[aa] - 1] == c[aa];
                bool tb = s[aa][b[aa] - 1] == c[aa];
                //Console.WriteLine($"{s[aa][a[aa] - 1] } or {s[aa][b[aa] - 1] } is {c[aa]} {ta} {tb}");
                if (ta && !tb)
                {
                    valid++;
                }
                if (tb && !ta)
                {
                    valid++;
                }
            }
            Console.WriteLine(valid);
        }
    }
}