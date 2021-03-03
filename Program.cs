using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace ConsoleApp3
{
    class Program
    {
		// notlar altindaki 5-aynì firmalardan olan alacaklar borçlar excel.
        static void Main(string[] args)
        {
            Dictionary<int, string> companies = new Dictionary<int, string>();
            companies.Add(0, "CompanyA"); companies.Add(1, "CompanyB"); companies.Add(2, "CompanyC"); companies.Add(3, "CompanyD");
            companies.Add(4, "CompanyE"); companies.Add(5, "CompanyF"); companies.Add(6, "CompanyG"); companies.Add(7, "CompanyH");
            companies.Add(8, "CompanyI"); companies.Add(9, "CompanyJ"); companies.Add(10, "CompanyK"); companies.Add(11, "CompanyL");
            companies.Add(12, "CompanyM"); companies.Add(13, "CompanyN"); companies.Add(14, "CompanyO"); companies.Add(15, "CompanyP");
            companies.Add(16, "CompanyR"); companies.Add(17, "CompanyJ"); companies.Add(18, "CompanyK"); companies.Add(19, "CompanyZ");
            companies.Add(20, "CompanyAA"); companies.Add(21, "CompanyCC"); companies.Add(22, "CompanyDD"); companies.Add(23, "CompanyEE");
            companies.Add(24, "CompanyBB"); companies.Add(25, "CompanyFF"); companies.Add(26, "CompanyGG"); companies.Add(27, "CompanyHH");
            companies.Add(28, "CompanyA"); companies.Add(29, "CompanyFF"); companies.Add(30, "CompanyGG"); companies.Add(31, "CompanyHH");
            companies.Add(32, "CompanyE"); companies.Add(33, "CompanyA"); companies.Add(34, "CompanyZZ"); companies.Add(35, "CompanyY");
            List<Row> fromList = new List<Row>();
            List<Row> toList = new List<Row>();

            Dictionary<string, int> done = new Dictionary<string, int>();
            int Code = 0;

            Random rn = new Random();
            Console.Out.WriteLine($"fromList -------");
            for (int i = 0; i < 24; i++)
            {
                
                int fci = rn.Next(0, 36);
                int cost = rn.Next(0, 16);
                Row r = new Row("100." + Code, companies[fci], cost * 1000);
                fromList.Add(r);
                Console.Out.WriteLine($"Code: {r.code}, Name: {r.name}, Balance: {r.balance}");
                Code++;
            }

            Code = 0;
            Console.Out.WriteLine($"toList   -------");
            for (int i = 0; i < 18; i++)
            {
                int fci = rn.Next(0, 36);
                int cost = rn.Next(0, 40);
                Row r = new Row("200." + Code, companies[fci], cost * 500);
                toList.Add(r);
                Console.Out.WriteLine($"Code: {r.code}, Name: {r.name}, Balance: {r.balance}");
                Code++;
            }



            foreach (var r in fromList)
            {
                if (done.ContainsKey(r.code))
                    continue;
                int fromSum = 0;
                int fromCount = 0;
                List<Row> fromRows = new List<Row>();
                foreach (var r2 in fromList)
                {
                    if (!done.ContainsKey(r2.code) && r.name.Equals(r2.name))
                    {
                        fromSum += r2.balance;
                        fromCount++;
                        done.Add(r2.code, 1);
                        fromRows.Add(r2);
                    }
                }

                int toSum = 0;
                int toCount = 0;
                List<Row> toRows = new List<Row>();
                foreach (var r2 in toList)
                {
                    if (!done.ContainsKey(r2.code) && r.name.Equals(r2.name))
                    {
                        toSum += r2.balance;
                        toCount++;
                        done.Add(r2.code, 1);
                        toRows.Add(r2);
                    }
                }

                Console.Out.WriteLine($"Row: {r.ToString()} : fromCount {fromCount} - fromSum {fromSum}, toCount{toCount} - toSum {toSum}");
                if (fromCount > 0 && toCount > 0)
                {
                    Console.Out.WriteLine($"- Row: {r.ToString()} : fromCount {fromCount} - fromSum {fromSum}, toCount{toCount} - toSum {toSum}");
                    if (fromSum > toSum)
                        Console.Out.WriteLine("to --> from");
                    else
                        Console.Out.WriteLine("from --> to");
                    foreach (var rr in fromRows)
                        Console.Out.WriteLine($"   from {rr.ToString()}");
                    foreach (var rr in toRows)
                        Console.Out.WriteLine($"     to {rr.ToString()}");
                }
                if (!done.ContainsKey(r.code))
                    done.Add(r.code, 1);
            }

            Console.Out.WriteLine("Done");
        }


        public class Row
        {
            public string code;
            public string name;
            public int balance;
            public Row(string c, string n, int b)
            {
                this.code = c;
                this.name = n;
                this.balance = b;
            }

            public string ToString()
            {
                return $"code: {this.code}, name: {this.name}, balance{this.balance}";
            }
        }

    }
}
