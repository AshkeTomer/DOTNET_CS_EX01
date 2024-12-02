using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char currentLetter = 'A';

            Console.Write("Enter the height of the tree (up to 15): ");
            if (!int.TryParse(Console.ReadLine(), out int treeHeight) || treeHeight < 3 || treeHeight > 15)
            {
                Console.WriteLine($"Invalid height. Please enter a number between 3 and 15.");
                return;
            }

            int k_StemHeight = 2;
            int maxWidth = (treeHeight - 2) * 2 - 1; 
            
            for (int level = 1; level < treeHeight - 1; level++)
            {
                
                int lettersInLevel = level * 2 - 1; 
                string row = string.Empty;

                for (int i = 0; i < lettersInLevel; i++)
                {
                    row += currentLetter;

                    
                    if (currentLetter == 'Z')
                    {
                        currentLetter = 'A';
                    }
                    else
                    {
                        currentLetter++;
                    }
                }

                Console.WriteLine($"{level,-2} {row.PadLeft((maxWidth + row.Length) / 2)}");
            }

            currentLetter++;
            char stemCharacter = currentLetter > 'A' ? (char)(currentLetter - 1) : 'A';
            string stem = $"|{stemCharacter}|";

            for (int i = 0; i < k_StemHeight; i++)
            {
                Console.WriteLine($"{treeHeight - 1 + i,-2} {stem.PadLeft((maxWidth + stem.Length) / 2)}");
            }
        }
    }
}