using System;
using System.Text;

namespace lab_10
{

    internal class TimeArray
    {
        private static int count = 0;
        private readonly Time[] arr;

        public static int Count
        {
            get { return count; }
        }

        public int Len
        {
            get { return arr.Length; }
        }

        public Time this[int i]
        {
            get
            {
                checkIndex(i);
                return arr[i];
            }
            set
            {
                checkIndex(i);
                arr[i] = value;
            }
        }

        private void checkIndex(int i)
        {
            if (i < 0 || i >= arr.Length)
            {
                throw new ArgumentOutOfRangeException($"Индекс должен быть в диапазоне от 0 до {arr.Length - 1}");
            }
        }

        public TimeArray()
        {
            count++;
            arr = new Time[8];
            for (int i = 0; i < Count; i++)
            {
                this[i] = new Time();
            }
        }

        public TimeArray(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Длина массива должна быть больше нуля");
            }
            count++;
            arr = new Time[length];
            for (int i = 0; i < arr.Length; i++)
            {
                this[i] = new Time(Random.Shared.Next(0, 24), Random.Shared.Next(0, 60));
            }
        }

        public TimeArray(Time[] input)
        {
            count++;
            arr = new Time[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                this[i] = input[i];
            }
        }

        public void Print()
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("(массив пуст)");
                return;
            }
            for (int i = 0; i < Len; i++)
            {
                Console.WriteLine($"{this[i]} ");
            }
        }

        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < Len; i++)
            {
                if (i > 0)
                {
                    res += ", ";
                }
                res += this[i].ToString();
            }
            return res.ToString();
        }
        public Time min()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Коллекция пуста");
            }
            Time min = this[0];
            for (var i = 0; i < Len; ++i) 
            {
                if (this[i] < min)
                {
                    min = this[i];
                }
            }
            return min;
        }
    }
}
