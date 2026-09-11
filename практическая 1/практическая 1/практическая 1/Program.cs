using практическая_1;

Console.Write("Задача 1:\n\n");
var n = 0;
InputFunctions.ReadInput("n", ref n);
var m = 0;
InputFunctions.ReadInput("m", ref m);


Console.WriteLine($"\nВыражение n++*--m = {n++ * --m}");
Console.WriteLine($"Выражение n--<m++ = {n-- < m++}");
Console.WriteLine($"Выражение --n>--m = {--n > --m}");

var x = 0.0;
InputFunctions.ReadInput("x", ref x);

Console.Write("\nПопытка вычислить занчение выражения (abs(x+1))^(1/4)+1/x^2\n");


if (x == 0)
    Console.WriteLine("Ошибка! Возникло деление на 0.");
else
{
    double res = Math.Pow(Math.Abs(x + 1), (1 / 4)) + 1 / Math.Pow(x, 2);
    Console.WriteLine($"Результат вычисления: {res}");
}

Console.Write("\nЗадача 2:\n");

var x1 = 0.0;
var y1 = 0.0;

InputFunctions.ReadInput("X_1",ref x1);
InputFunctions.ReadInput("Y_1", ref y1);

var inArea = ((x1 * y1 >= 0) && ((y1 <= 1 - x1) && (y1 >= -1 - x1))) 
    || ((x1 * y1 < 0) && ((Math.Pow(x1, 2) + Math.Pow(y1, 2)) <= 1));

if (inArea)
    Console.WriteLine($"Точка ({x1}; {y1}) принадлежит закрашенной области");
else
    Console.WriteLine($"Точка ({x1}; {y1}) не принадлежит закрашенной области");

Console.Write("\nЗадача 3:\n");

float floatA = 1000.0f, floatB = 0.0001f;

float floatDivided = PowFloat((floatA - floatB), 4) - (PowFloat(floatA, 4) + 6 * PowFloat(floatA, 2) * PowFloat(floatB, 2) + PowFloat(floatB, 4));
float floatDivider = 4 * floatA * PowFloat(floatB, 3) + 4 * PowFloat(floatA, 3) * floatB;

Console.WriteLine($"Значение выражения ((a-b)^4 - (a^4 + 6*a^2*b^2 + b^2)) / (4a*b^3 + 4*a^3*b), вычисленное с использованием типа float: {floatDivided / floatDivider}");

double doubleA = 1000.0, doubleB = 0.0001;

double doubleDivided = Math.Pow((doubleA - doubleB), 4) - (Math.Pow(doubleA, 4) + 6 * Math.Pow(doubleA, 2) * Math.Pow(doubleB, 2) + Math.Pow(doubleB, 4));
double doubleDivider = 4 * doubleA * Math.Pow(doubleB, 3) + 4 * Math.Pow(doubleA, 3) * doubleB;

Console.WriteLine($"Значение выражения ((a-b)^4 - (a^4 + 6*a^2*b^2 + b^2)) / (4a*b^3 + 4*a^3*b), вычисленное с использованием типа double: {doubleDivided / doubleDivider}");



float PowFloat(float x,int y) {
    var res = 1.0f;
    for (var i = 0; i <y; i++)
        res *= x;
    return res;
}