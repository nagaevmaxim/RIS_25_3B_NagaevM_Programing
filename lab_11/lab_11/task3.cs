using lab_10_library;
using System;
using System.Diagnostics;

namespace lab_11
{
    public class task3
    {
        public static void execute()
        {
            Console.WriteLine("Создание коллекций из 1000 элементов");
            TestCollections collections = new TestCollections();
            Console.WriteLine($"Коллекции созданы, элементов в каждой: {collections.RepublicList.Count}");

            do
            {
                int select = UserInterface.selectOption(new string[]
                {
                    "Добавить элемент", "Удалить элемент", "Измерить время поиска", "Выход"
                });

                if (select == 4)
                {
                    return;
                }

                switch (select)
                {
                    case 1:
                        Console.Clear();
                        addItem(collections);
                        UserInterface.wait();
                        break;
                    case 2:
                        Console.Clear();
                        deleteItem(collections);
                        UserInterface.wait();
                        break;
                    case 3:
                        Console.Clear();
                        measureSearch(collections);
                        UserInterface.wait();
                        break;
                }
            } while (true);
        }

        static void addItem(TestCollections collections)
        {
            Republic republic = new Republic();
            republic.Init();

            if (collections.RepublicDict.ContainsKey(republic) ||
                collections.RepublicDictStr.ContainsKey(republic.ToString()))
            {
                Console.WriteLine("Элемент с такими данными уже есть в коллекции");
                return;
            }

            collections.AddNode(republic);
            Console.WriteLine("Элемент:");
            republic.Show();
            Console.WriteLine("Добавлен");
        }

        static void deleteItem(TestCollections collections)
        {
            if (collections.RepublicList.Count == 0)
            {
                Console.WriteLine("Коллекция пуста, удалять нечего");
                return;
            }

            Republic[] items = new Republic[collections.RepublicList.Count];
            collections.RepublicList.CopyTo(items, 0);

            Console.WriteLine($"Введите индекс от 0 до {items.Length - 1} для удаления");
            var count = items.Length - 1;
            int indToDelete = UserInterface.readInt((int res) => (res >= 0 & res <= count));

            Republic deleted = items[indToDelete];
            collections.DeleteNode(deleted);

            Console.WriteLine("Элемент:");
            deleted.Show();
            Console.WriteLine("Удалён из всех коллекций");
        }

        static void measureSearch(TestCollections collections)
        {


            Republic[] items = new Republic[collections.RepublicList.Count];
            collections.RepublicList.CopyTo(items, 0);

            Republic first = items[0];
            Republic middle = items[items.Length / 2];
            Republic last = items[items.Length - 1];
            Republic absent = createAbsentRepublic(collections);

            Console.WriteLine($"Время поиска в коллекциях (элементов в каждой: {items.Length})");
            Console.WriteLine();

            measureElement(collections, "Первый элемент", first);
            measureElement(collections, "Средний элемент", middle);
            measureElement(collections, "Последний элемент", last);
            measureElement(collections, "Элемент, которого нет в коллекции", absent);
        }

        static void measureElement(TestCollections collections, string title, Republic element)
        {
            string elementStr = element.ToString();
            State elementBase = element.BaseState;

            Console.WriteLine(title);
            Console.WriteLine(elementStr);
            Console.WriteLine();

            Stopwatch sw = Stopwatch.StartNew();

            bool found = collections.RepublicList.Contains(element);
            sw.Stop();
            string not = found ? " " : " не ";
            Console .WriteLine($"В LinkedList<Republic> элемент{not}найден за {sw.ElapsedTicks} тиков");

            sw = Stopwatch.StartNew();
            found = collections.RepublicListStr.Contains(elementStr);
            sw.Stop();
            not = found ? " " : " не ";
            Console.WriteLine($"В LinkedList<string> элемент{not}найден за {sw.ElapsedTicks} тиков");

            sw = Stopwatch.StartNew();
            found = collections.RepublicDict.ContainsKey(element);
            sw.Stop();
            not = found ? " " : " не ";
            Console.WriteLine($"В SortedDictionary<Republic, State> элемент{not}найден за {sw.ElapsedTicks} тиков");

            sw = Stopwatch.StartNew();
            found = collections.RepublicDictStr.ContainsKey(elementStr);
            sw.Stop();
            not = found ? " " : " не ";
            Console.WriteLine($"В SortedDictionary<string, State> элемент{not}найден за {sw.ElapsedTicks} тиков");

            sw = Stopwatch.StartNew();
            found = collections.RepublicDictStr.ContainsValue(elementBase);
            sw.Stop();
            not = found ? " " : " не ";
            Console.WriteLine($"В SortedDictionary<string, State> по значению элемент{not}найден за {sw.ElapsedTicks} тиков");

            Console.WriteLine();
        }

        static Republic createAbsentRepublic(TestCollections collections)
        {
            Republic candidate = new Republic();
            do
            {
                candidate.RandomInit();
            } while (collections.RepublicDictStr.ContainsKey(candidate.ToString()));
            return candidate;
        }

    }
}
