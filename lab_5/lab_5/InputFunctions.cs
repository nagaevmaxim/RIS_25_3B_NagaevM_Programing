using System;
using System.Collections.Generic;
using System.Text;

namespace lab_5
{
    internal class InputFunctions
    {
        public static void ReadInput(string num_name, out int output)
        {
            Console.Write($"Введите {num_name}:");
            var input = Console.ReadLine();
            var inputIsNum = int.TryParse(input, out output);
            while (!inputIsNum)
            {
                Console.Write($"Ошибка! Введите число {num_name} заново: ");
                input = Console.ReadLine();
                inputIsNum = int.TryParse(input, out output);
            }

        }


        public static void ReadInput(string num_name, out uint output)
        {
            Console.Write($"Введите {num_name}:");
            var input = Console.ReadLine();
            var inputIsNum = uint.TryParse(input, out output);
            while (!inputIsNum || output > int.MaxValue)
            {
                Console.Write($"Ошибка! Введите число {num_name} заново: ");
                input = Console.ReadLine();
                inputIsNum = uint.TryParse(input, out output);
            }

        }

        public static void ReadInput(string num_name, out double output)
        {
            Console.Write($"Введите {num_name}:");
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
