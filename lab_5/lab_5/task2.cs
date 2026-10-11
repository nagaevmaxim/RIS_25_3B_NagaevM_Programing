using System;
using System.Collections.Generic;
using System.Text;

namespace lab_5
{
    internal class task2
    {
        private static readonly Random rand = new Random();
        public static void task2_execute()
        {
            Console.WriteLine("Рваный массив:");
            uint row;
            InputFunctions.ReadInput("количество строк массива", out row);
            int[][] arr = new int[row][];
            fillArr(ref arr, 0);
            printArr(ref arr);
            addRows(ref arr);
            printArr(ref arr);

            Console.Write("Для возвращения на начальный экран введите любое значение: ");
            Console.ReadLine();
        }

        private static void fillArr(ref int[][] arr, int startInd)
        {
            for (var i = startInd; i < arr.Length; i++)
            {
                uint len;
                InputFunctions.ReadInput("длину строки", out len);
                arr[i] = new int[len];
                for(var j  = 0; j < len; j++)
                {
                    arr[i][j] = rand.Next() % 1000;
                }
            }
        }

        private static void printArr(ref int[][] arr)
        {
            Console.WriteLine("Вывод массива: ");
            for (var i = 0; i < arr.Length; i++)
            {
                for (var j = 0; j < arr[i].Length; j++)
                {
                    Console.Write($"{arr[i][j]} ");
                }
                Console.WriteLine();
            }
        }

        private static void addRows(ref int[][] arr)
        {
            uint k;
            InputFunctions.ReadInput("количество строк для добавления в конец массива", out k);
            int[][] newArr = new int[arr.Length+k][];
            Array.Copy(arr, 0, newArr, 0, arr.Length);
            fillArr(ref newArr, arr.Length);
            arr = newArr;
        }
    }

}
