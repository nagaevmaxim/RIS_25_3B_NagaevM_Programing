using lab_10_library;
using lab_11;
using System.Collections;

int select;
bool parsed;

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
                task1.execute();
                break;
            }
        case 2:
            {
                Console.Clear();
                task2.execute();
                break;
            }
        case 3:
            {
                Console.Clear();
                task3.execute();
                break;
            }
    }
} while (select >= 1 && select <= 3);