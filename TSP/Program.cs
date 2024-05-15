using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static Random random = new Random();

    static int[,] distances = 
    {
        {0, 10, 15, 20},
        {10, 0, 35, 25},
        {15, 35, 0, 30},
        {20, 25, 30, 0}
    };

    static int populationSize = 50;
    static double mutationRate = 0.01;
    static int elitism = 2; 

    static int n = distances.GetLength(0); 

    static int[] CreateIndividual()
    {
        List<int> individual = Enumerable.Range(0, n).ToList(); 
        individual.RemoveAt(0);
        individual = Shuffle(individual); 
        return individual.ToArray();
    }

    static List<int> Shuffle(List<int> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
        return list;
    }

    static int CalculateDistance(int[] route)
    {
        int distance = 0;
        int currentCity = 0; 
        foreach (int nextCity in route)
        {
            distance += distances[currentCity, nextCity];
            currentCity = nextCity;
        }
        distance += distances[currentCity, 0];
        return distance;
    }

    static int[][] CreateInitialPopulation()
    {
        int[][] population = new int[populationSize][];
        for (int i = 0; i < populationSize; i++)
        {
            population[i] = CreateIndividual();
        }
        return population;
    }

    static int[][] Crossover(int[] parent1, int[] parent2)
    {
        int[] child1 = new int[n - 1];
        int[] child2 = new int[n - 1];
        int startPos = random.Next(n - 1);
        int endPos = random.Next(startPos, n - 1);
        for (int i = startPos; i <= endPos; i++)
        {
            child1[i] = parent1[i];
            child2[i] = parent2[i];
        }
        int[] remaining1 = parent2.Where(item => !child1.Contains(item)).ToArray();
        int[] remaining2 = parent1.Where(item => !child2.Contains(item)).ToArray();
        int index1 = 0;
        int index2 = 0;
        for (int i = 0; i < n - 1; i++)
        {
            if (child1[i] == 0)
            {
                child1[i] = remaining1[index1];
                index1++;
            }
            if (child2[i] == 0)
            {
                child2[i] = remaining2[index2];
                index2++;
            }
        }
        return new int[][] { child1, child2 };
    }

    static void Mutate(int[] individual)
    {
        for (int i = 0; i < n - 1; i++)
        {
            if (random.NextDouble() < mutationRate)
            {
                int j = random.Next(n - 1);
                int temp = individual[i];
                individual[i] = individual[j];
                individual[j] = temp;
            }
        }
    }

    static int[][] SelectParents(int[][] population)
    {
        List<int[]> parents = new List<int[]>();
        for (int i = 0; i < elitism; i++)
        {
            parents.Add(population[i]);
        }
        for (int i = elitism; i < populationSize; i++)
        {
            int index1 = random.Next(populationSize);
            int index2 = random.Next(populationSize);
            parents.Add(population[index1].Length < population[index2].Length ? population[index1] : population[index2]);
        }
        return parents.ToArray();
    }

    static int[][] GenerateNextGeneration(int[][] population)
    {
        int[][] nextGeneration = new int[populationSize][];
        int[][] parents = SelectParents(population);
        for (int i = 0; i < elitism; i++)
        {
            nextGeneration[i] = population[i];
        }
        for (int i = elitism; i < populationSize; i += 2)
        {
            int[][] children = Crossover(parents[i], parents[i + 1]);
            Mutate(children[0]);
            Mutate(children[1]);
            nextGeneration[i] = children[0];
            nextGeneration[i + 1] = children[1];
        }
        return nextGeneration;
    }

    static void Main()
    {
        int[][] population = CreateInitialPopulation();
        int generation = 0;
        int bestDistance = int.MaxValue;
        int[] bestRoute = null;
        while (generation < 1000) 
        {
            population = GenerateNextGeneration(population);
            foreach (int[] individual in population)
            {
                int distance = CalculateDistance(individual);
                if (distance < bestDistance)
                {
                    bestDistance = distance;
                    bestRoute = individual;
                }
            }
            generation++;
        }
        Console.WriteLine("Najkrótsza trasa:");
        Console.WriteLine(string.Join(" -> ", bestRoute));
        Console.WriteLine("Długość trasy: " + bestDistance);
    }
}
