using lab_10_library;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lab_11
{

    public class PopulationArrayListComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            var s1 = x as State;
            var s2 = y as State;
            if (ReferenceEquals(s1, s2)) return 0;
            if (s1 is null) return -1;
            if (s2 is null) return 1;
            return s1.Population.CompareTo(s2.Population);
        }
    }


    public class task1
    {
        public static void execute() {
            ArrayList aList = new ArrayList();
            aList.Add(new Monarchy("Россия", "Москва", 140000000, 170000000, "Путин В.В", true));
            aList.Add(new Kingdom("Соединённое Королевство", "Лондон", 70000000, 250500, "КорольКарл III", true, "Винздоры"));
            aList.Add(new Republic("Беларусь", "Минск", 9000000, 207600, "Президент", "Лукашенко А. Г.", 4));

            do
            {
                int select = UserInterface.selectOption(new string[]{ 
                    "Добавить элемент", "Удалить элемент", "Выпонить запрос", 
                    "Вывод всех элемнтов коллекции", "Создание клона", "Отсортировать коллекцию",
                    "Выход"
                });

                if (select == 7)
                {
                    return;
                }

                switch (select)
                {
                    case 1:
                        Console.Clear();
                        addNewItem(ref aList);
                        UserInterface.wait();
                        break;
                    case 2:
                        Console.Clear();
                        deleteItem(ref aList);
                        UserInterface.wait();
                        break;
                    case 3:
                        Console.Clear();
                        executeRequests(ref aList);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Вывод всех элементов коллекции:");
                        forEachShow(ref aList);
                        UserInterface.wait();
                        break;
                    case 5:
                        Console.Clear();
                        clone(ref aList);
                        UserInterface.wait();
                        break;
                    case 6:
                        Console.Clear();
                        aList.Sort(new PopulationArrayListComparer());
                        Console.WriteLine("Коллекция отортированна");
                        UserInterface.wait();
                        break;
                }
            } while (true);
        }

        static void clone(ref ArrayList aList)
        {
            ArrayList clone = (ArrayList)aList.Clone();
            Console.WriteLine("Клон коллекции создан, вывод элементов клона:");
            forEachShow(ref clone);
        }

        static void forEachShow(ref ArrayList aList)
        {
            
            foreach (object stateObj in aList)
            {
                State state = stateObj as State;

                Monarchy? monarchy = state as Monarchy;
                state = (monarchy != null)? monarchy : state;

                Kingdom? kingdon = state as Kingdom;
                state = (kingdon != null) ? kingdon : state;

                Republic? republic = state as Republic;
                state = (republic != null) ? republic : state;

                state.Show();
                Console.WriteLine();
            }
        }

        static void executeRequests(ref ArrayList aList)
        {
            do
            {
                int req = UserInterface.selectOption(new string[]
                {
                    "Количество Монархий", "Вывести все Королевства", "Количество республик", "Выход"
                });
                if (req == 4)
                {
                    return;
                }
                switch (req)
                {
                    case 1:
                        Console.Clear();
                        var res = 0;
                        for (var i = 0; i < aList.Count; i++)
                        {
                            if (aList[i] is Monarchy)
                                res++;
                        }
                        Console.WriteLine($"Монархий: {res}");
                        UserInterface.wait();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Все королевтсва: ");
                        for (var i = 0; i < aList.Count; i++)
                        {
                            Kingdom? kingdom = aList[i] as Kingdom;
                            if (kingdom == null)
                                continue;
                            kingdom.Show();
                            Console.WriteLine();
                        }
                        UserInterface.wait();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Все республики: ");
                        for (var i = 0; i < aList.Count; i++)
                        {
                            Republic? republic = aList[i] as Republic;
                            if (republic == null)
                                continue;
                            republic.Show();
                            Console.WriteLine();
                        }
                        UserInterface.wait();
                        break;
                }
            } while (true);
        }

        static void deleteItem(ref ArrayList aList)
        {
            Console.WriteLine($"Введите индекс от 0 до {aList.Count - 1} для удаления");
            var count = aList.Count - 1;
            int indToDelete = UserInterface.readInt((int res) => (res >= 0 & res <= count));
            State deleted = (State)aList[indToDelete];
            aList.RemoveAt(indToDelete);
            Console.WriteLine("Элемент:");
            deleted.Show();
            Console.WriteLine("Удалён");
        }

        static void addNewItem(ref ArrayList aList)
        {
            State newState;
            int type = UserInterface.selectOption(new string[]
            {
                "Государство", "Монархия", "Королевство", "Республика"
            });
            switch (type)
            {
                case 2:
                    newState = new Monarchy();
                    break;
                case 3:
                    newState = new Kingdom();
                    break;
                case 4:
                    newState = new Republic();
                    break;
                default:
                    newState = new State();
                    break;
            }
            Console.Clear();
            newState.Init();
            aList.Add(newState);
            Console.WriteLine("Элемент:");
            newState.Show();
            Console.WriteLine("Добавлен");
        }
    }
}
