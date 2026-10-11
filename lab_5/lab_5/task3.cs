using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace lab_5
{
    internal class task3
    {
        public static void task3_execute()
        {
            Console.WriteLine("Введите строку: ");
            String str = Console.ReadLine();
            
            MatchCollection matchesSentences = Regex.Matches(str, @"[^.?!]*[.?!]");

            string res = "";

            foreach (Match sentence in matchesSentences)
            {
                MatchCollection matchesWords = Regex.Matches(sentence.Value, @"[A-Za-zА-Яа-яЁё0-9]+[\s,:;]+");
                var firstWord = true;
                foreach (Match word in matchesWords)
                {
                    if (firstWord)
                    {
                        firstWord = false;
                        continue;
                    }
                    res += word.Value.Trim() + " ";
                }
                if (matchesWords.Count > 1)
                {
                    res = res.TrimEnd();
                    Match mark = Regex.Match(sentence.Value, @"[.?!]");
                    res += mark.Value + " ";
                }
                
            }

            res = res.TrimEnd(' ', ',', ';', ':');

            Console.Write($"Результат: {res}");
            Console.Write("Для возвращения на начальный экран введите любое значение: ");
            Console.ReadLine();
        }

    }
}
