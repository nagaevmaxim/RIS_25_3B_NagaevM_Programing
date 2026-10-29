using lab_10;

int select;
bool parsed;

Time first;
Time second;
Time copy;

do
{
    parsed = UserInterface.selectMenu(out select);
    if (!parsed)
    {
        break;
    }

    switch (select)
    {
        case 1:
            {
                initObjects();
                task1();
                break;
            }
        case 2:
            {
                initObjects();
                task2();
                break;
            }
        case 3:
            task3();
            break;
    }
} while (select >= 1 && select <= 3);

void initObjects()
{
    Console.WriteLine("Инициализация объектов времени:");
    first = new Time();
    Console.WriteLine($"Первое время (конструктор без параметров): {first}");

    second = UserInterface.initTimeFromKeyboard();
    Console.WriteLine($"Второе время (введено с клавиатуры): {second}");

    copy = new Time(second);
    Console.WriteLine($"Копия второго времени (конструктор копирования): {copy}");
    Console.WriteLine();
}


void task1()
{
    first.Minutes = 1;

    Console.WriteLine("Значения объектов класса:");
    first.Print("Первое время:");
    second.Print("Второе время:");
    copy.Print("Копия второго времени:");

    Console.Write("Введите количество минут для вычитания: ");
    int minus = UserInterface.readInt((res) => (res >= 0));

    try
    {
        Time afterMethod = copy.SubtractMinutes(minus);
        Console.WriteLine($"Метод класса: {copy} - {minus} = {afterMethod}");

        Time afterStatic = Time.Subtract(afterMethod, minus);
        Console.WriteLine($"Статическая функция: {afterMethod} - {minus} = {afterStatic}");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }

    Console.WriteLine($"Количество созданных объектов Time: {Time.Count}");
    pause();
}

void task2()
{
    Console.WriteLine("Унарные операции:");
    string before = copy.ToString();
    try
    {
        copy--;                      
        Console.WriteLine($"Вычитание минуты (--): {before} -> {copy}");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }

    Time zeroed = -second; 
    Console.WriteLine($"Сброс в ноль (унарный -): {second} -> {zeroed}");

    Console.WriteLine();
    Console.WriteLine("Преобразования типов:");
    printConversion("Первое время", first);
    printConversion("Второе время", second);
    printConversion("Копия второго времени", copy);

    Console.WriteLine();
    Console.WriteLine("Сравнение объектов:");
    printComparison("1 и 2", first, second);
    printComparison("1 и копия 2", first, copy);
    printComparison("2 и копия 2", second, copy);
    printComparison("2 и новая копия 2", second, new Time(second));

    pause();
}

void task3()
{
    int fillMethod = UserInterface.selectInitMethod();
    TimeArray array;
    switch (fillMethod)
    {
        case 1:
            array = new TimeArray();
            break;
        case 2:
            Console.Write("Введите длину массива: ");
            array = new TimeArray(UserInterface.readInt(res => res > 0));
            break;
        default:
            Console.Write("Введите длину массива: ");
            int length = UserInterface.readInt(res => res > 0);
            Time[] input = new Time[length];
            UserInterface.fillArrFromKeyboard(input);
            array = new TimeArray(input);
            break;
    }

    Console.WriteLine();
    Console.WriteLine("Полученный массив:");
    array.Print();

    try
    {
        Console.WriteLine();
        Console.WriteLine($"Минимальный элемент: {min(array)}");
    } catch (InvalidOperationException ex)
    {
        Console.WriteLine(ex.Message);
    }

    Console.WriteLine("Изменение элемента через индексатор: array[0] = 01:15");
    array[0] = new Time(1, 15);
    array.Print();

    Console.WriteLine("Проверка выхода индекса за границы массива:");
    try
    {
        Console.WriteLine($"array[{array.Len}] = {array[array.Len]}");
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine($"Перехвачено ожидаемое исключение: {ex.Message}");
    }

    Console.WriteLine($"Создано объектов Time: {Time.Count}, объектов TimeArray: {TimeArray.Count}");
    pause();
}


void printConversion(string label, Time time)
{
    Console.WriteLine($"{label} {time}: int -> {(int)time} (часы), bool -> {(bool)time} (признак ненулевого времени)");
}

void printComparison(string label, Time left, Time right)
{
    Console.WriteLine($"{label}: == {left == right} ({(left == right ? "равны" : "не равны")}), " +
                      $"!= {left != right} ({(left != right ? "не равны" : "равны")})");
}

void pause()
{
    Console.Write("Введите любое значение для выхода: ");
    Console.ReadLine();
}

public Time min(TimeArray arr)
{
    if (arr.Len == 0)
    {
        throw new InvalidOperationException("Коллекция пуста");
    }
    Time min = arr[0];
    for (var i = 0; i < arr.Len; ++i)
    {
        if (arr[i] < min)
        {
            min = arr[i];
        }
    }
    return min;
}
