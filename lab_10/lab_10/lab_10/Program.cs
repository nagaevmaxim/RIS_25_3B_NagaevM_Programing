using lab_10;
using lab_10_library;
using System.Net.Http.Headers;

int select;
bool parsed;

State[] states = new State[20];
for (var i = 0; i < 5; i++)
{
    states[i] = new State();
}
for (var i = 5; i < 10; i++)
{
    states[i] = new Monarchy();
}
for (var i = 10; i < 15; i++)
{
    states[i] = new Kingdom();
}
for (var i = 15; i < 20; i++)
{
    states[i] = new Republic();
}

for (var i = 0; i < states.Length; i++)
{
    states[i].RandomInit();
}
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
                Console.Clear();
                task1();
                UserInterface.wait();
                break;
            }
        case 2:
            {
                Console.Clear();
                task2();
                UserInterface.wait();
                break;
            }
        case 3:
            Console.Clear();
            task3();
            UserInterface.wait();
            break;
    }
} while (select >= 1 && select <= 3);



void task1()
{ 


    for (var i = 0; i < 20; i++)
    {
        selectInit(ref states[i], i);
    }

    for (var i = 0; i < 20; i++)
    {
        states[i].Show();
        Console.WriteLine();
    }
    

}

void selectInit(ref State state, int i)
{
    if (i % 5 == 0)
    {
        states[i].Init();
    }
    else
    {
        states[i].RandomInit();
    }
}

void task2()
{
    int request = UserInterface.selectRequest();
    switch (request)
    {
        case 1:
            Console.Clear();
            Requests.stateCapital[] capitals;
            Requests.capitals(out capitals, ref states);
            for (var i = 0; i < capitals.Length; i++)
            {
                Console.WriteLine($"Столица страны {capitals[i].StateName} : {capitals[i].Capital}");
            }
            UserInterface.wait();
            break;
        case 2:
            Console.Clear();
            List<string> monarches;
            Requests.monarches(out monarches, ref states);
            Console.Write("Монархии: ");
            for (var i = 0; i < monarches.Count; i++)
            {
                Console.Write($"{monarches[i]}, ");
            }
            Console.WriteLine();
            break;
        case 3:
            Console.Clear();
            Console.Write("Введите срок n для поиска: ");
            int n = UserInterface.readInt((res) => (res > 0));
            List<string> heads;
            Requests.republicHeadsTermSmallerN(out heads, n, ref states);
            Console.WriteLine($"Лидеры республик со сроком меньше {n}: ");
            for (var i = 0; i < heads.Count; i++)
            {
                Console.Write($"{heads[i]} ");
            }
            Console.WriteLine();
            break;
    }
}

void task3()
{


    Array.Sort(states, new PopulationComparer());
    Console.WriteLine("Массив, отсортироанный по численности населения стран: ");
    for (var i = 0; i < 20; i++)
    {
        states[i].Show();
        Console.WriteLine();
    }

    UserInterface.waitContinue();

    Array.Sort(states);
    Console.WriteLine("Массив, отсортироанный по площади стран: ");
    for (var i = 0; i < 20; i++)
    {
        states[i].Show();
        Console.WriteLine();
    }

    UserInterface.waitContinue();

    State targetState = new State();
    Console.WriteLine("Введите госуларство для поиска по площади: ");
    targetState.Init();
    int index = Array.BinarySearch(states, targetState);
    if (index >= 0)
    {
        Console.WriteLine($"Государство найдено под индексом {index}");
        states[index].Show();
    } else
    {
        Console.WriteLine("Государство не найдено");
    }

    UserInterface.waitContinue();

    Console.WriteLine("Объекты IInit:");

    IInit[] initArray = new IInit[10] {
        new State(),  new State (),
        new Monarchy(), new Monarchy(),
        new Kingdom(), new Kingdom(),
        new Republic(), new Republic(),
        new City(), new City()};
    for (var i = 5; i < 10; i++)
    {
        if (i % 2 == 0)
        {
            initArray[i].Init();
        } else
        {
            initArray[i].RandomInit();
        }
    }

    for (var i = 0; i < 10; i++)
    {
        initArray[i].Show();
        Console.WriteLine();
    }

    UserInterface.waitContinue();

    Console.WriteLine($"Создание клона и проверхностной копии первого госуарства");
    State original = states[0];
    Console.WriteLine("оригинал (states[0])");
    original.Show();
    Console.WriteLine();

    State shallow = original.ShallowCopy();
    State deep = (State)original.Clone();

    Console.WriteLine("Меняем столицу у оригинала на Санкт-Петербург");
    original.Capital.Name = "Санкт-Петербург";
    Console.WriteLine($"стлица оригинала: {original.Capital.Name}");
    Console.WriteLine($"столица поверхностной копии: {shallow.Capital.Name}");
    Console.WriteLine($"столица глубокой копии: {deep.Capital.Name}");
}