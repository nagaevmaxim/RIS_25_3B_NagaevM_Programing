using lab_5;

int input;

do
{
    Console.Clear();
    Console.WriteLine("1. Двумерный массив");
    Console.WriteLine("2. Рваный массив");
    Console.WriteLine("3. Строка символов");
    Console.WriteLine("0. Выход");
    InputFunctions.ReadInput("нужный вариант", out input);
    switch (input)
    {
        case 1:
            task1.task1_execute();
            break;
        case 2: 
            task2.task2_execute();
            break;
        case 3:
            task3.task3_execute();
            break;
    }
} while(input != 0);






