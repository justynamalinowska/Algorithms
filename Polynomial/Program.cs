using System;

class Program
{
    static double EvaluatePolynomial(double[] coefficients, double x)
    {
        double result = 0.0;

        for (int i = coefficients.Length - 1; i >= 0; i--)
        {
            result = result * x + coefficients[i];
        }
        return result;
    }

    static void Main()
    {
        double[] coefficients = { 2.0, -3.0, 1.0 }; // Współczynniki wielomianu: 2x^2 - 3x + 1
        double x = 1; 

        double result = EvaluatePolynomial(coefficients, x);
        Console.WriteLine("Wartość wielomianu dla x = {0} wynosi: {1}", x, result);
    }
}