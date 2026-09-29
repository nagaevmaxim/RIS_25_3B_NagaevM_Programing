using lab_3;

const int n = 35;
const double a = 0.1;
const double b = 0.8;
const double eps = 1e-4;
int k;
do
{
    InputFunctions.ReadInput("k >= 0", out k); //класс из прошлой лабораторной
} while (k <= 0);
double step = (b - a) / k;

Console.WriteLine("Вычисление функции y = -0.5*ln(1 - 2x*cons(pi/3) + x^2)");
Console.WriteLine($"для x изменяющегося от {a} до {b} с шагом {step} разложением степенного ряда для:");
Console.Write("n = 35 и e=0.0001\n\n");

Console.WriteLine("x y(точное) y(n=35) y(e=0.0001)");
for (var x = a; x <= b; x+= step)
{
    var y = FCalculate.FAccurate(x);
    var yN = FCalculate.FN(x, n);
    var yE = FCalculate.FE(x, eps);
    Console.WriteLine($"{x:F2}\t{y}\t{yN}\t{yE:f4}");
}

