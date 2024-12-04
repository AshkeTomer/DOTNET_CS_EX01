using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string k_StemCharacter = "|Z|";
            char currentLetter = 'A';

            int[] levels = { 1, 3, 5, 7, 9 }; 
            int treeWidth = levels.Sum();    
            
            int rowNumber = 1; 
            foreach (int levelWidth in levels)
            {
                string row = string.Empty;

                for (int i = 0; i < levelWidth && currentLetter <= 'Y'; i++)
                {
                    row += currentLetter;
                    currentLetter++;
                }

                Console.WriteLine($"{rowNumber,-2} {row.PadLeft(treeWidth / 2 + row.Length / 2, ' ')}");
                rowNumber++;
            }

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"{rowNumber,-2} {k_StemCharacter.PadLeft(treeWidth / 2 + k_StemCharacter.Length / 2, ' ')}");
                rowNumber++;
            }
        }
    }
}