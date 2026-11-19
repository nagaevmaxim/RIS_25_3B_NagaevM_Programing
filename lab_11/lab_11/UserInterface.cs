using System;
using System.Collections.Generic;
using System.Text;

namespace lab_11
{
    internal class UserInterface
    {
        public static bool selectMenu(out int inputInt)
        {
            Console.Clear();
            Console.WriteLine("1. Задача 1 (ArrayList)");
            Console.WriteLine("2. Задача 2 (Stack)");
            Console.WriteLine("3. Задача 3 (TestCollections)");
            Console.Write("Выберите пункт 1-3 или введите любое другое значение для выхода: ");
            string? input = Console.ReadLine();
            return int.TryParse(input, out inputInt);
        }


        public static int selectOption(string[] options)
        {
            Console.Clear();
            for (var i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i+1}: {options[i]}");
            }
            Console.Write($"Выберите пункт 1-{options.Length}: ");
            return readInt((res) => (res >= 1 && res <= options.Length));
        }

        


        public static int readInt(Func<int, bool> condition)
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int res) && condition(res))
                {
                    return res;
                }
                Console.Write("Ошибка! Введите заново: ");
            }
        }

        public static void wait()
        {
            Console.WriteLine("Для выхода введите любое значение: ");
            Console.ReadLine();
        }
        public static void waitContinue()
        {
            Console.WriteLine("Введите любое значение, чтобы продолжить: ");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
