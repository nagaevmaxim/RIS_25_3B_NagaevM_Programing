using System;

namespace lab_10
{
    internal class Time
    {
        private int hours = 0;
        private int minutes = 0;

        private static int count;

        public static int Count
        {
            get { return count; }
        }

        public int Hours
        {
            get { return hours; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Ошибка! Часы не могут быть отрицательными");
                }
                hours = value;
            }
        }

        public int Minutes
        {
            get { return minutes; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentOutOfRangeException( "Ошибка! Минуты должны быть в диапазоне от 0 до 59");
                }
                minutes = value;
            }
        }

        private int TotalMinutes
        {
            get { return hours * 60 + minutes; }
        }

        public Time() {
            count++; 
        }

        public Time(int h, int m)
        {
            Hours = h;
            Minutes = m;
            count++;
        }

        public Time(Time other)
        {
            Hours = other.Hours;
            Minutes = other.Minutes;
            count++;
        }

        public override string ToString()
        {
            return $"{Hours:00}:{Minutes:00}";
        }

        public void Print(string prefix)
        {
            Console.WriteLine($"{prefix} {this}");
        }

        public static Time Subtract(Time time, int minutes)
        {

            if (time.TotalMinutes < minutes)
            {
                throw new InvalidOperationException(
                    $"Из объекта {time} нельзя вычесть {minutes} мин: результат был бы отрицательным");
            }
            int rest = time.TotalMinutes - minutes;
            return new Time(rest / 60, rest % 60);
        }

        public Time SubtractMinutes(int minutes)
        {
            return Subtract(this, minutes);
        }

        public static Time operator -(Time time)
        {
            return new Time(0, 0);
        }

        public static Time operator --(Time time)
        {
            return Subtract(time, 1);
        }

        public static implicit operator int(Time time)
        {
            return time.Hours;
        }

        public static explicit operator bool(Time time)
        {
            return time.Hours != 0 || time.Minutes != 0;
        }

        public static bool operator ==(Time? left, Time? right)
        {
            if (left is null || right is null)
            {
                return false;
            }
            return left.Hours == right.Hours && left.Minutes == right.Minutes;
        }

        public static bool operator !=(Time? left, Time? right)
        {
            if (left is null || right is null)
            {
                return true;
            }
            return left.Hours != right.Hours && left.Minutes != right.Minutes;
        }

        public static bool operator <(Time left, Time right)
        {
            return left.TotalMinutes < right.TotalMinutes;
        }

        public static bool operator >(Time left, Time right)
        {
            return left.TotalMinutes > right.TotalMinutes;
        }

        public override bool Equals(object? obj)
        {
            return obj is Time;
            
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes);
        }
       
    }
}
