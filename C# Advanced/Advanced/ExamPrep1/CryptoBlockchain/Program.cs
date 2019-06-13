using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CryptoBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex1 = new Regex(@"\[[^{}\[]+?\]|{[^\[{}]+?}");

            Regex regex2 = new Regex(@"[0-9]{3}");


            int n = int.Parse(Console.ReadLine());
            string blockchain = "";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                blockchain += input;
            }

            MatchCollection matches = regex1.Matches(blockchain);
            List<string> valid = new List<string>();
            string output = "";

            foreach (Match match in matches)
            {
                valid.Add(match.ToString());
            }

            for (int i = 0; i < valid.Count; i++)
            {
                string nums = "";
                for (int j = 0; j < valid[i].Length; j++)
                {
                    char currentChar = valid[i][j];
                    if (Char.IsDigit(currentChar))
                    {
                        nums += currentChar;
                    }
                }

                if (nums.Length % 3 != 0)
                {
                    continue;
                }

                MatchCollection numMatches = regex2.Matches(nums);

                foreach (var item in numMatches)
                {
                    int num = int.Parse(item.ToString());
                    num -= valid[i].Length;
                    char ch = (char)num;
                    output += ch;
                }
            }
            Console.WriteLine(output);
        }
    }
}
