using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Obliczanie przybliżonej wartości liczby π metodą Monte Carlo:");

        int pointsInsideCircle = 0;
        int totalPoints = 1000000;
        Random rand = new Random();

        for (int i = 0; i < totalPoints; i++)
        {
            double x = rand.NextDouble();
            double y = rand.NextDouble();

            if (x * x + y * y <= 1)
            {
                pointsInsideCircle++;
            }
        }
        double piApproximation = 4.0 * pointsInsideCircle / totalPoints;

        Console.WriteLine("Przybliżona wartość liczby π: {0}", piApproximation);
    }
}