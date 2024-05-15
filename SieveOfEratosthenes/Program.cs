public class Project
{

    static void Main()
    {
        int n = 30;

        List<int> primes = new List<int>();
        int[] lowestPrimeFactors = new int[n];
        for (int i = 2; i <= n; i++)
        {
            if (lowestPrimeFactors[i - 2] == 0)
            {
                primes.Add(i);
                lowestPrimeFactors[i - 2] = i;
            }

            foreach (int p in primes)
            {
                if (p <= lowestPrimeFactors[i - 2] && p * i <= n) lowestPrimeFactors[p * i - 2] = p;
                else break;
            }
        }

        Console.WriteLine("Liczby pierwsze mniejsze lub równe {0}:", n);
        Console.WriteLine(string.Join(", ", primes));

    }
}