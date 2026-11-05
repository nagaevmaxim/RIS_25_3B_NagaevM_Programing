using System;

namespace lab_10
{
    internal static class UserInterface
    {

        public static bool selectMenu(out int inputInt)
        {
            Console.Clear();
            Console.WriteLine("1. Задача 1 (заполнение массива всеми объектами иерархии и вывод)");
            Console.WriteLine("2. Задача 2 (Выполнение запросов)");
            Console.WriteLine("3. Задача 3 (Сортировка, поиск, создание объектов интерфейса)");
            Console.Write("Выберите пункт 1-3 или введите любое другое значение для выхода: ");
            string? input = Console.ReadLine();
            return int.TryParse(input, out inputInt);
        }

        public static int selectRequest()
        {
            Console.Clear();
            Console.WriteLine("1. Столицы всех государств");
            Console.WriteLine("2. Все монархи");
            Console.WriteLine("3. Лидеры республик со сроком полномичй менее n");
            Console.Write("Выберите пункт 1-3: ");
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

        public static void wait()
        {
            Console.WriteLine("Для выхода введите любое значение: ");
            Console.ReadLine();
        }
        public static void waitContinue()
        {
            Console.WriteLine("Введите любое значение, чтобы продолжить: ");
            Console.ReadLine();
            Console.Clear() ;
        }
    }
}
