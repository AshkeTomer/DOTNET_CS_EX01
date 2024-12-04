using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a 9-digit number:");
            string input = Console.ReadLine();

            if (input == null || input.Length != 9 || !input.All(char.IsDigit))
            {
                Console.WriteLine("Invalid input. Please enter a 9-digit number.");
                return;
            }

            int[] digits = input.Select(c => c - '0').ToArray();
            int rightMostDigit = digits[digits.Length - 1]; 
            
            int largerThanRightMost = digits.Count(d => d > rightMostDigit);

            int divisibleByFour = digits.Count(d => d % 4 == 0);

            int largestDigit = digits.Max();
            int smallestNonZeroDigit = digits.Where(d => d != 0).DefaultIfEmpty(1).Min(); 
            double ratio = smallestNonZeroDigit != 0 ? (double)largestDigit / smallestNonZeroDigit : 0;

            int twinCount = 0;
            foreach (var group in digits.GroupBy(d => d))
            {
                int count = group.Count();
                if (count > 1)
                {
                    twinCount += count; 
                }
            }

            Console.WriteLine($"Digits larger than the right-most digit: {largerThanRightMost}");
            Console.WriteLine($"Digits divisible by 4: {divisibleByFour}");
            Console.WriteLine($"Ratio of largest to smallest non-zero digit: {ratio:F2}");
            Console.WriteLine($"Number of twin digits: {twinCount}");
        }
    }
}