using lab_10_library;
using System;
using System.Collections.Generic;

namespace lab_11
{

    public class PopulationStackComparer : IComparer<State>
    {
        public int Compare(State? x, State? y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (x is null) return -1;
            if (y is null) return 1;
            return x.Population.CompareTo(y.Population);
        }
    }


    public class task2
    {
        public static void execute()
        {
            Stack<State> stack = new Stack<State>();
            stack.Push(new Monarchy("Россия", "Москва", 140000000, 170000000, "Путин В.В", true));
            stack.Push(new Kingdom("Соединённое Королевство", "Лондон", 70000000, 250500, "КорольКарл III", true, "Винздоры"));
            stack.Push(new Republic("Беларусь", "Минск", 9000000, 207600, "Президент", "Лукашенко А. Г.", 4));

            do
            {
                int select = UserInterface.selectOption(new string[]{
                    "Добавить элемент", "Удалить элемент", "Выполнить запрос",
                    "Вывод всех элементов коллекции", "Создание клона", "Отсортировать коллекцию",
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
                        addNewItem(ref stack);
                        UserInterface.wait();
                        break;
                    case 2:
                        Console.Clear();
                        deleteItem(ref stack);
                        UserInterface.wait();
                        break;
                    case 3:
                        Console.Clear();
                        executeRequests(ref stack);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Вывод всех элементов коллекции (от вершины стека к основанию):");
                        forEachShow(ref stack);
                        UserInterface.wait();
                        break;
                    case 5:
                        Console.Clear();
                        clone(ref stack);
                        UserInterface.wait();
                        break;
                    case 6:
                        Console.Clear();
                        sortStack(ref stack);
                        UserInterface.wait();
                        break;
                }
            } while (true);
        }

        static void clone(ref Stack<State> stack)
        {
            Stack<State> copy = createStack(stack);
            Console.WriteLine("Клон коллекции создан, вывод элементов клона:");
            forEachShow(ref copy);
        }

        static Stack<State> createStack(Stack<State> stack)
        {
            State[] items = stack.ToArray();
            Stack<State> result = new Stack<State>(items.Length);
            for (int i = items.Length - 1; i >= 0; i--)
            {
                result.Push(items[i]);
            }
            return result;
        }

        static void forEachShow(ref Stack<State> stack)
        {
            if (stack.Count == 0)
            {
                Console.WriteLine("Коллекция пуста");
                return;
            }

            foreach (State state in stack)
            {
                state.Show();
                Console.WriteLine();
            }
        }

        static void executeRequests(ref Stack<State> stack)
        {
            do
            {
                int req = UserInterface.selectOption(new string[]
                {
                    "Количество Монархий", "Вывести все Королевства", "Вывести все Республики", "Выход"
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
                        foreach (State state in stack)
                        {
                            if (state is Monarchy)
                                res++;
                        }
                        Console.WriteLine($"Монархий: {res}");
                        UserInterface.wait();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Все королевства: ");
                        foreach (State state in stack)
                        {
                            Kingdom? kingdom = state as Kingdom;
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
                        foreach (State state in stack)
                        {
                            Republic? republic = state as Republic;
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

        static void deleteItem(ref Stack<State> stack)
        {
            if (stack.Count == 0)
            {
                Console.WriteLine("Коллекция пуста, удалять нечего");
                return;
            }

            Console.WriteLine($"Введите позицию от 0 (вершина стека) до {stack.Count - 1} (основание) для удаления");
            var count = stack.Count - 1;
            int indToDelete = UserInterface.readInt((int res) => (res >= 0 & res <= count));

            State[] items = stack.ToArray();
            State deleted = items[indToDelete];
            Stack<State> result = new Stack<State>(items.Length - 1);
            for (int i = items.Length - 1; i >= 0; i--)
            {
                if (i != indToDelete)
                {
                    result.Push(items[i]);
                }
            }
            stack = result;

            Console.WriteLine("Элемент:");
            deleted.Show();
            Console.WriteLine("Удалён");
        }

        static void addNewItem(ref Stack<State> stack)
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
            stack.Push(newState);
            Console.WriteLine("Элемент:");
            newState.Show();
            Console.WriteLine("Добавлен на вершину стека");
        }

        static void sortStack(ref Stack<State> stack)
        {
            if (stack.Count < 2)
            {
                Console.WriteLine("Коллекция уже отсортирована");
                return;
            }

            State[] items = stack.ToArray();

            Array.Sort(items, new PopulationStackComparer());

            Stack<State> sorted = new Stack<State>(items.Length);
            for (int i = items.Length - 1; i >= 0; i--)
            {
                sorted.Push(items[i]);
            }
            stack = sorted;
            Console.WriteLine("Коллекция отсортирована по населению (по возрастанию при обходе сверху вниз)");
        }

    }
}
