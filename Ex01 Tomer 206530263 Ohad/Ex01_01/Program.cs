﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int k_BinaryLength = 8;
            int[] numbers = new int[3];
            string[] binaryInputs = new string[3];

            Console.WriteLine("Please enter three 8-digit binary numbers:");

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"Enter binary number {i + 1}: ");
                string input = Console.ReadLine();

                while (input.Length != k_BinaryLength || !IsBinary(input))
                {
                    Console.WriteLine("Invalid input. Please enter exactly 8 binary digits (0s and 1s).");
                    input = Console.ReadLine();
                }

                binaryInputs[i] = input;
                numbers[i] = Convert.ToInt32(input, 2);
            }

            int[] sortedNumbers = numbers.OrderBy(n => n).ToArray();
            Console.WriteLine("\nNumbers in ascending order:");
            Console.WriteLine(string.Join(", ", sortedNumbers));
            
            double average = numbers.Average();
            Console.WriteLine($"Average of numbers: {average:F2}");

            int[] longestStreaks = new int[3];
            int[] switchesCount = new int[3];
            int[] countOfOnes = new int[3];
            int[] countOfZeros = new int[3];

            for (int i = 0; i < binaryInputs.Length; i++)
            {
                longestStreaks[i] = GetLongestStreak(binaryInputs[i]);
                switchesCount[i] = CountSwitches(binaryInputs[i]);
                countOfOnes[i] = binaryInputs[i].Count(c => c == '1');
                countOfZeros[i] = binaryInputs[i].Count(c => c == '0');
            }

            int numberWithLeastOnes = numbers[Array.IndexOf(countOfOnes, countOfOnes.Min())];
            int numberWithMostZeros = numbers[Array.IndexOf(countOfZeros, countOfZeros.Max())];

            Console.WriteLine("\nLongest streak of a single bit in each number:");
            for (int i = 0; i < binaryInputs.Length; i++)
            {
                Console.WriteLine($"Binary {binaryInputs[i]}: Longest streak = {longestStreaks[i]}");
            }

            Console.WriteLine("\nNumber of switches from 0 to 1 for each number:");
            for (int i = 0; i < binaryInputs.Length; i++)
            {
                Console.WriteLine($"Binary {binaryInputs[i]}: Switches = {switchesCount[i]}");
            }

            Console.WriteLine($"\nNumber with the least 1s: {numberWithLeastOnes} (Binary: {Convert.ToString(numberWithLeastOnes, 2).PadLeft(k_BinaryLength, '0')})");
            Console.WriteLine($"Number with the most 0s: {numberWithMostZeros} (Binary: {Convert.ToString(numberWithMostZeros, 2).PadLeft(k_BinaryLength, '0')})");
        }

        static bool IsBinary(string input)
        {
            return input.All(c => c == '0' || c == '1');
        }

        static int GetLongestStreak(string binary)
        {
            int maxStreak = 0;
            int currentStreak = 0;
            char previousChar = binary[0];

            foreach (char bit in binary)
            {
                if (bit == previousChar)
                {
                    currentStreak++;
                    maxStreak = Math.Max(maxStreak, currentStreak);
                }
                else
                {
                    currentStreak = 1;
                }

                previousChar = bit;
            }

            return maxStreak;
        }

        static int CountSwitches(string binary)
        {
            int switches = 0;

            for (int i = 0; i < binary.Length - 1; i++)
            {
                if (binary[i] == '0' && binary[i + 1] == '1')
                {
                    switches++;
                }
            }

            return switches;
        }
    }
}