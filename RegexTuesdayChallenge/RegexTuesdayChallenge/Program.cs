using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

///Azamat Dzhonov 
///8/8/2016 
///Regex Tuesday Challenge 
///https://callumacrae.github.com/regex-tuesday/
///Link on Habr

namespace RegexTuesdayChallenge
{
    class Program
    {
        private const string DIVIDELINE = "==================================";
        private const string FILE_PATH = "input";
        static void Main(string[] args)
        {
            string text;
            using (StreamReader sr = new StreamReader(FILE_PATH))
            {
                text = sr.ReadToEnd();
            }
           
            Console.WriteLine(text + Environment.NewLine);
            DoTasks(text);
            Console.ReadKey();
        }

        public static void DoTasks(String text)
        {
            //Console.WriteLine("Task_1:");
            /////Mark repeat word by tag <strong> 
            ///// Pattern pass all test
            ///// https://callumacrae.github.com/regex-tuesday/challenge1.html
            ///// Pattern: /\b([a-zA-Z'.\-]+)\s(\1)\b/gi  Change: $1 <strong>$2</strong>
            //FindAndChange(text,
            //    @"\b([a-zA-Z'.\-]+)\s(\1)\b",
            //    "$1 <strong>$2</strong>");


            //Console.WriteLine("Task_3:");
            ///// Select dates between 1000 and 2012. Each month have 30 days.
            ///// Pattern pass all test
            ///// http://callumacrae.github.io/regex-tuesday/challenge3.html
            ///// Pattern:/^(1\d{3}|20(0\d|1[0-2]))/(0[1-9]|1[02])/(0[1-9]|[1-2]\d|30) (([0-1]\d|2[0-4]):[0-5]\d)(:[0-5]\d|60)?$/
            //FindMatches(text,
            //@"\b(1\d{3}|20(0\d|1[0-2]))/(0[1-9]|1[02])/(0[1-9]|[1-2]\d|30) (([0-1]\d|2[0-4]):[0-5]\d)(:[0-5]\d|60)?\b");

            //Console.WriteLine("Task_4:");
            /////Change only *text* on tag <em>text</em>
            /////Pattern pass 7 test from 11
            /////http://callumacrae.github.io/regex-tuesday/challenge4.html
            ////// /\*([A-Za-z0-9 ,.]+)\*/g  <em>$1</em>
            //FindAndChange(text,
            //   @"\*([A-Za-z0-9 ]+)\*",
            //   "<em>$1</em>");

            //Console.WriteLine("Task_5:");
            ////Find numbers divided by ",."  8,205,500.4672 
            ////Pattern pass 27 test from 31
            ////Pattern:^\d{1,3}((,| )\d{3})*(.\d+)?$
            ////https://callumacrae.github.com/regex-tuesday/challenge5.html
            //FindMatches(text, @"\b\d{1,3}((,| )\d{3})*(.\d+)?\b");

            ////Console.WriteLine("Task_6:");
            ///////Find IPv4
            ////FindMatches(text,
            ////    @"");

            //Console.WriteLine("Task_7:");
            /////Test pass 38 test from 41
            /////Pattern: /^(https|http)://(www\.)?[^-][\w-\.]{1,40}[^-.]\.\w{1,10}/?$/
            /////https://callumacrae.github.com/regex-tuesday/challenge7.html
            //FindMatches(text, @"\b(https|http)://(www\.)?[^-][\w-\.]{1,40}[^-.]\.\w{1,10}/?\b");

            //Console.WriteLine("Task_8:");
            //FindAndChange(text,
            //    @"\b([a-zA-Z'.\- ]+)+\s(\1)+\b",
            //    @"*$1*");
             

        }
        public static void FindAndChange(String text, String pattern, String change)
        {
            Regex regex = new Regex(pattern);
            String new_text = regex.Replace(text, change);
            Console.WriteLine(DIVIDELINE);
            Console.WriteLine(new_text);
            Console.WriteLine();
        }
       
        public static void FindMatches(String text, String pattern)
        {
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);
            Console.WriteLine(DIVIDELINE);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
            Console.WriteLine();
        }

    }
}
