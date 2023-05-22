using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day09
{
    enum Rarity
    {
        Common,Uncommon,Rare,Epic,Legendary
    }
    public static class Extensions
    {
        public static ConsoleColor GetColor(this double grade)
        {
            return (grade < 59.5) ? ConsoleColor.Red :
                   (grade < 69.5) ? ConsoleColor.DarkYellow :
                   (grade < 79.5) ? ConsoleColor.Yellow :
                   (grade < 89.5) ? ConsoleColor.Blue :
                   ConsoleColor.Green;
        }
        public static void PrintGrades(this List<double> grades)
        {
            foreach (var grade in grades)
            {
                Console.ForegroundColor = grade.GetColor();
                Console.WriteLine($"{grade,7:N2}");
                Console.ResetColor();
            }
        }
    }
}
