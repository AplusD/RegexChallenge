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
///https://m.habrahabr.ru/post/167015/

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
            Console.WriteLine("Task_1:");
            ///Mark repeat word by tag <strong> 
            /// https://callumacrae.github.com/regex-tuesday/challenge1.html
            /// Pattern: /\b([a-zA-Z'.\-]+)\s(\1)\b/gi  Change: $1 <strong>$2</strong>
            FindAndChange(text,
                @"\b([a-zA-Z'.\-]+)\s(\1)\b",
                "$1 <strong>$2</strong>");

            Console.WriteLine("Task_2:");
            ///Choose grayscale colors in CSS 
            ///http://callumacrae.github.io/regex-tuesday/challenge2.html
            //Pattern: /^((#([0-9a-z]?[0-9a-z])\3\3)|
            //(rgb\((([0-1]?\d?\d|2[0-5][0-5]|0*(\d\.)?\d|\d\d%|100%),\s*0*\6,\s*0*\6)\)$)|
            //(rgba\((([0-1]?\d?\d|2[0-5][0-5]|0*(\d\.)?\d|\d\d%|100%),\s*0*\10,\s*0*\10)(,(\d+\.)?\d+%?)\s?\))|
            //(hsl\((\d?\d(\.\d\d?)?%?),\s*(\d?\d(\.\d\d?)?%?)(,\s*\d?\d(\.\d\d?)?%?)\))|
            //(hsla\((\d?\d(\.\d\d?)?%?),\s*(\d?\d(\.\d\d?)?%?)(,\s*\d?\d(\.\d\d?)?%?)(,\s*\d?\d(\.\d\d?)?%?)\)))$/i
            FindMatches(text,
             @"((#([0-9a-z]?[0-9a-z])\3\3)|(rgb\((([0-1]?\d?\d|2[0-5][0-5]|0*(\d\.)?\d|\d\d%|100%),\s*0*\6,\s*0*\6)\)$)|(rgba\((([0-1]?\d?\d|2[0-5][0-5]|0*(\d\.)?\d|\d\d%|100%),\s*0*\10,\s*0*\10)(,(\d+\.)?\d+%?)\s?\))|(hsl\((\d?\d(\.\d\d?)?%?),\s*(\d?\d(\.\d\d?)?%?)(,\s*\d?\d(\.\d\d?)?%?)\))|(hsla\((\d?\d(\.\d\d?)?%?),\s*(\d?\d(\.\d\d?)?%?)(,\s*\d?\d(\.\d\d?)?%?)(,\s*\d?\d(\.\d\d?)?%?)\)))");

            Console.WriteLine("Task_3:");
            /// Select dates between 1000 and 2012. Each month have 30 days.
            /// http://callumacrae.github.io/regex-tuesday/challenge3.html
            /// Pattern:/^(1\d{3}|20(0\d|1[0-2]))/(0[1-9]|1[02])/(0[1-9]|[1-2]\d|30) (([0-1]\d|2[0-4]):[0-5]\d)(:[0-5]\d|60)?$/
            FindMatches(text,
            @"\b(1\d{3}|20(0\d|1[0-2]))/(0[1-9]|1[02])/(0[1-9]|[1-2]\d|30) (([0-1]\d|2[0-4]):[0-5]\d)(:[0-5]\d|60)?\b");

            Console.WriteLine("Task_4:");
            ///Change only *text* on tag <em>text</em>      
            ///http://callumacrae.github.io/regex-tuesday/challenge4.html
            //// /\*([A-Za-z0-9 ,.]+)\*/g  <em>$1</em>
            FindAndChange(text,
               @"\*([A-Za-z0-9 ]+)\*",
               "<em>$1</em>");

            Console.WriteLine("Task_5:");
            //Find numbers divided by ",."  8,205,500.4672         
            //Pattern:^\d{1,3}((,| )\d{3})*(.\d+)?$
            //https://callumacrae.github.com/regex-tuesday/challenge5.html
            FindMatches(text, @"\b\d{1,3}((,| )\d{3})*(.\d+)?\b");

            Console.WriteLine("Task_6:");
            ///Find IPv4 
            ///Pattern: /^(?:([0-1]?\d?\d|2[0-5][0-5]).?){3}\.?([0-1]?\d?\d|2[0-5][0-5])$/
            ///http://callumacrae.github.com/regex-tuesday/challenge6.html
            FindMatches(text,
            @"/^(?:([0-1]?\d?\d|2[0-5][0-5]).?){3}\.?([0-1]?\d?\d|2[0-5][0-5])$/");

            Console.WriteLine("Task_7:");
            ///Find domains 
            ///Pattern: /^(https|http)://(www\.)?[^-][a-zA-Z-\.0-9]{1,40}[^-.]\.[A-Za-z]{1,10}/?$/
            ///https://callumacrae.github.com/regex-tuesday/challenge7.html
            FindMatches(text, @"\b(https|http)://(www\.)?[^-][\w-\.]{1,40}[^-.]\.\w{1,10}/?\b");

            Console.WriteLine("Task_8:");
            ///Repeated point mark with *text*
            ///Pattern: /\* ([A-Za-z \*]*?)(\n)\* (\1)/gi
            ///* $1$2* **$3**
            ///http://callumacrae.github.io/regex-tuesday/challenge8.html
            FindAndChange(text,
                @"\b\* ([A-Za-z \*]*?)(\n)\* (\1)\b",
                @"* $1$2* **$3***");

            Console.WriteLine("Task_9:");
            ///Change MarkDown to HTML
            ///Pattern: /^\[([A-Za-z\s]*)\]\((http://[a-zA-Z-\.0-9]{1,40}\.[A-Za-z]{1,10}/?)\)$/g
            ///<a href="$2">$1</a>
            ///http://callumacrae.github.io/regex-tuesday/challenge9.html
            FindAndChange(text,
                @"\b\[([A-Za-z\s]*)\]\((http://[a-zA-Z-\.0-9]{1,40}\.[A-Za-z]{1,10}/?)\)\b",
                @"<a href=""$2"">$1</a>");

            Console.WriteLine("Task_10:");
            ///Divide text on tockins 
            ///Pattern: /(\s*|-{2,20})([A-Za-z]+)(\s|-{2,20}|;)/gi
            ///$2,
            ///http://callumacrae.github.io/regex-tuesday/challenge10.html
            FindAndChange(text,
                @"\b(\s*|-{2,20})([A-Za-z]+)(\s|-{2,20}|;)\b",
                @"$2,");

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
