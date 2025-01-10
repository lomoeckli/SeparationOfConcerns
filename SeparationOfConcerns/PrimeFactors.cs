using System;
using System.Collections.Generic;

public class PrimeFactors
{
    // Methode zur Berechnung aller Primzahlen bis zur größten Zahl in der Liste mit dem Sieb des Eratosthenes
    private static List<int> SieveOfEratosthenes(int max)
    {
        var primes = new List<int>();
        var isPrime = new bool[max + 1];
        for (int i = 2; i <= max; i++)
        {
            isPrime[i] = true;
        }

        for (int i = 2; i * i <= max; i++)
        {
            if (isPrime[i])
            {
                for (int j = i * i; j <= max; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }

        for (int i = 2; i <= max; i++)
        {
            if (isPrime[i])
            {
                primes.Add(i);
            }
        }

        return primes;
    }

    // Methode zur Faktorisierung einer Liste von Zahlen
    public static void Factor(List<int> numbers)
    {
        if (numbers == null || numbers.Count == 0)
        {
            throw new ArgumentException("Die Liste darf nicht leer sein.");
        }

        // Finde die größte Zahl in der Liste, um die Primzahlen bis zu dieser Zahl zu berechnen
        int maxNumber = 0;
        foreach (var number in numbers)
        {
            if (number < 1)
            {
                throw new ArgumentException("Negative Zahlen sind nicht unterstützt.");
            }
            if (number > maxNumber)
            {
                maxNumber = number;
            }
        }

        // Berechne alle Primzahlen bis zur größten Zahl
        var primes = SieveOfEratosthenes(maxNumber);

        // Zweiter Schritt: Faktorisierung der Zahlen
        foreach (var number in numbers)
        {
            var factors = new List<int>();
            var remainder = number;

            foreach (var prime in primes)
            {
                while (remainder % prime == 0)
                {
                    factors.Add(prime);
                    remainder /= prime;
                }

                // Wenn der Rest 1 ist, brauchen wir keine weiteren Primzahlen mehr zu überprüfen
                if (remainder == 1)
                {
                    break;
                }
            }

            // Falls der Rest eine Primzahl ist, die größer als die größte berechnete Primzahl ist
            if (remainder > 1)
            {
                factors.Add(remainder);
            }

            // Ausgabe der Primfaktorzerlegung
            Console.Write($"{number}: ");
            foreach (var factor in factors)
            {
                Console.Write($"{factor} ");
            }
            Console.WriteLine();
        }
    }
}
