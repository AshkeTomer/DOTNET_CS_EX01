using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a 10-character long string:");
            string input = Console.ReadLine();

            if (input.Length != 10)
            {
                Console.WriteLine("The input must be exactly 10 characters long.");
                return;
            }

            if (IsLettersOnly(input))
            {
                Console.WriteLine($"Is Palindrome: {IsPalindrome(input, 0, input.Length - 1)}");
                Console.WriteLine($"Lowercase Letters Count: {CountLowerCaseLetters(input)}");
                Console.WriteLine($"Is Descending Alphabetically Ordered: {IsAlphabeticallyOrdered(input)}");
            }
            else if (IsDigitsOnly(input))
            {
                Console.WriteLine($"Is Palindrome: {IsPalindrome(input, 0, input.Length - 1)}");
                Console.WriteLine($"Divisible by 4: {IsDivisibleByFour(input)}");
            }
            else
            {
                Console.WriteLine("The input must contain either only letters or only numbers.");
            }
        }

        static bool IsLettersOnly(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                    return false;
            }
            return true;
        }

        static bool IsDigitsOnly(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        static bool IsPalindrome(string input, int start, int end)
        {
            if (start >= end)
                return true;

            if (input[start] != input[end])
                return false;

            return IsPalindrome(input, start + 1, end - 1);
        }

        static int CountLowerCaseLetters(string input)
        {
            int count = 0;
            foreach (char c in input)
            {
                if (char.IsLower(c))
                    count++;
            }
            return count;
        }

        static bool IsAlphabeticallyOrdered(string input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] > input[i - 1])
                    return false;
            }
            return true;
        }

        static bool IsDivisibleByFour(string input)
        {
            int number = int.Parse(input);
            return number % 4 == 0;
        }
    }
}