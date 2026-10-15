using System;
using System.Collections.Generic;
using System.Text;

namespace lab_5
{
    internal class task1
    {
        public static void task1_execute()
        {

            uint row, col;
            InputFunctions.ReadInput("количество строк массива", out row);
            InputFunctions.ReadInput("количество столбцов массива", out col);
            int[,] arr = new int[row, col];
            Random rand = new Random();

            if (row == 0 || col == 0)
            {
                Console.WriteLine("Таблица пустая!");
            }

            Console.WriteLine("Выберите способ заполнения: 0. Рандомные числа. 1.Числа с клавиатуры:");
            uint fillMethod;
            InputFunctions.ReadInput("0-1", out fillMethod);

            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    if (fillMethod == 1)
                    {
                        arr[i, j] = rand.Next() % 1000;
                    } else
                    {
                        InputFunctions.ReadInput($"arr[{i}, {j}]", out arr[i, j]);
                    }
                }
            }
            printArr(ref arr);
            deleteCol(ref arr);
            printArr(ref arr);
            Console.Write("Для возвращения на начальный экран введите любое значение: ");
            Console.ReadLine();
        }



        private static void printArr(ref int[,] arr)
        {
            Console.WriteLine("Вывод массива: ");
            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        private static void deleteCol(ref int[,] arr)
        {
            if (arr.GetLength(1) == 0) return;
            uint k;
            do {
                InputFunctions.ReadInput("номер столбца для удаления", out k);
            } while (k < 0 || k >= arr.GetLength(1));
            int[,] newArr = new int[arr.GetLength(0), arr.GetLength(1)-1];
            for (var i = 0; i < arr.GetLength(0); i++) {
                var sourceIndex = i * arr.GetLength(1);
                var destIndex = i * newArr.GetLength(1);
                Array.Copy(arr, sourceIndex, newArr, destIndex, k);
                sourceIndex += (int)k+1;
                destIndex += (int)k;
                var length = (int)arr.GetLength(1) - k - 1;
                Array.Copy(arr, sourceIndex, newArr, destIndex, length);
            }
            arr = newArr;
        }
    }
}