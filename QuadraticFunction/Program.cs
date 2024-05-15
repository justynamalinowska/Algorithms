using System;

class Program
{
    static double EvaluateCubicFunction(double a, double b, double c, double d, double x)
    {
        return a * x * x * x + b * x * x + c * x + d;
    }

    static void Main()
    {
        double a, b, c, d;

        Console.WriteLine("Podaj współczynniki funkcji sześciennej ax^3 + bx^2 + cx + d:");
        Console.Write("a: ");
        a = Double.Parse(Console.ReadLine());
        Console.Write("b: ");
        b = Double.Parse(Console.ReadLine());
        Console.Write("c: ");
        c = Double.Parse(Console.ReadLine());
        Console.Write("d: ");
        d = Double.Parse(Console.ReadLine());
        
        Console.Write("Podaj wartość x: ");
        double x = Double.Parse(Console.ReadLine());
        
        double result = EvaluateCubicFunction(a, b, c, d, x);
        
        Console.WriteLine("Wartość funkcji dla x = {0} wynosi: {1}", x, result);
    }
}