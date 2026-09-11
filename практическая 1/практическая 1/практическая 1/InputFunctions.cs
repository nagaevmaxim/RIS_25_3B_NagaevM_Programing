using System;
using System.Collections.Generic;
using System.Text;

namespace практическая_1
{
    internal class InputFunctions
    {
        public static void ReadInput(string num_name, ref int output)
        {
            Console.Write($"Введите число {num_name}:");
            var input = Console.ReadLine();
            var inputIsNum = int.TryParse(input, out output);
            while (!inputIsNum)
            {
                Console.Write($"Ошибка! Введите число {num_name} заново: ");
                input = Console.ReadLine();
                inputIsNum = int.TryParse(input, out output);
            }
           
        }

        public static void ReadInput(string num_name, ref double output)
        {
            Console.Write($"Введите число {num_name}:");
            var input = Console.ReadLine();
            var inputIsNum = double.TryParse(input, out output);
            while (!inputIsNum)
            {
                Console.Write($"Ошибка! Введите число {num_name} заново: ");
                input = Console.ReadLine();
                inputIsNum = double.TryParse(input, out output);
            }
        }
    }
}
