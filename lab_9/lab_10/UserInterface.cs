using System;

namespace lab_10
{
    internal static class UserInterface
    {

        public static bool selectMenu(out int inputInt)
        {
            Console.Clear();
            Console.WriteLine("1. Задача 1 (класс Time, вычитание минут)");
            Console.WriteLine("2. Задача 2 (перегрузка операций)");
            Console.WriteLine("3. Задача 3 (коллекция TimeArray, поиск минимума)");
            Console.Write("Выберите пункт 1-3 или введите любое другое значение для выхода: ");
            string? input = Console.ReadLine();
            return int.TryParse(input, out inputInt);
        }

        public static int selectInitMethod()
        {
            Console.Clear();
            Console.WriteLine("Варианты заполнения массива:");
            Console.WriteLine("1. Массив из 8 значений по умолчанию");
            Console.WriteLine("2. Массив из случайных значений");
            Console.WriteLine("3. Заполнение вручную");
            Console.Write("Введите значение от 1 до 3: ");
            return readInt((res) => (res >= 1 && res <= 3));
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

        public static void readHoursAndMinutes(out int hours, out int minutes)
        {
            Console.WriteLine("Введите часы и минуты через пробел: ");
            while (true)
            {
                string input = Console.ReadLine() ?? string.Empty;
                string[] parts = input.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 2
                    && int.TryParse(parts[0], out hours)
                    && int.TryParse(parts[1], out minutes)
                    && hours >= 0
                    && minutes >= 0
                    && minutes <= 59)
                {
                    return;
                }
                Console.Write("Ошибка! Введите часы и минуты повторно через пробел: ");
            }
        }

        public static Time initTimeFromKeyboard()
        {
            readHoursAndMinutes(out int h, out int m);
            return new Time(h, m);
        }

        public static void fillArrFromKeyboard(Time[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Элемент с индексом {i}:");
                readHoursAndMinutes(out int h, out int m);
                arr[i] = new Time(h, m);
            }
        }
    }
}
