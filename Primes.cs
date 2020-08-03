using System;
using System.Collections.Generic;

namespace Exercise_4._3_Prime_Numbers
{
    public class Primes
    {
        public static int IsInt()
        {
            int number = 0;
            while (true)
            {
                string confirm = Console.ReadLine();
                if (!int.TryParse(confirm, out number))
                {
                    Console.WriteLine("Please have a valid input next time.");
                    IsInt();
                }
                else
                {
                    return number;
                }
            }

        }
        public static List<int> primes = new List<int>();

        // Function to generate N prime numbers using Sieve of Eratosthenes 
        public static void SieveOfEratosthenes()
        {
            int cap = 10000;
            bool[] IsPrime = new bool[cap];

            for (int i = 0; i < cap; i++)
            {
                IsPrime[i] = true;
            }

            for (int p = 2; p * p < cap; p++)
            {
                if (IsPrime[p] == true)
                {
                    for (int i = p * p; i < cap; i += p)
                    {
                        IsPrime[i] = false;
                    }
                }
            }

            //Adds to arraylist
            for (int p = 1; p < cap; p++)
            {
                if (IsPrime[p] == true)
                {
                    primes.Add(p);
                }
            }
            
        }
        public static bool GetPrime(int number)
        {
            SieveOfEratosthenes();
            while (true)
            {
                if (primes.Contains(primes[number]))
                {
                    
                    Console.WriteLine($"{number} prime number is {primes[number]}");
                    return true;
                }
                else
                {
                    return false;
                }
            } 
        }


        public static bool Quit()
        {
            //Method called to quit or restart.
            Console.WriteLine("");
            Console.WriteLine("Quit?. 'Y' to quit, any other key to restart.");
            string y = Console.ReadLine().ToLower();
            if (y == "y")
            {
                Environment.Exit(1);
                return false;
            }
            else
            {
                Console.Clear();
                return true;
            }
        }

        public static void Main()
        {
            bool flag = true;
            do
            {
                Console.WriteLine("Let's locate some primes!");
                Console.WriteLine("");
                Console.WriteLine("This application will find you any prime, in order, from first prime number on.");
                Console.WriteLine("");
                Console.Write("Which prime number are you looking for? ");

                int prime = IsInt();
                GetPrime(prime);
                flag = Quit();
            }
            while (true);
        }
    }
}