﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Day04
{
    internal class Program
    {
        enum Weapon
        {
            Sword, Axe, Spear, Mace
        }

        //static int IndexOf(List<string> list, string searchItem)
        //{

        //}
        static void Main(string[] args)
        {
            /*
                ╔═════════╗ 
                ║Searching║
                ╚═════════╝ 
             
                There are 2 ways to search a list: linear search or binary search
             
                CHALLENGE 1:

                    Convert Linear Search algorithm into a method. 
                        The method should take 2 parameters: list of ints to search, int to search for.
                        The method should return -1 if NOT found or the index if found.
                     
                    The algorithm:
                        1) start at the beginning of the list
                        2) compare each item in the list to the search item
                        3) if found, return the index
                        4) if reach the end of the list, return -1 which means not found
                    
            */
            List<string> jla = new()
            { "Wonder Woman", "Superman", "Aquaman", "Batman", "Flash", "Green Lantern" };
            string name = "Batman";
            FindHero(jla, name);
            name = "Paul";
            FindHero(jla, name);
            Console.ReadKey();
            jla.Sort();






            /*   
                ╔══════════════════════════╗ 
                ║ Dictionary<TKey, TValue> ║
                ╚══════════════════════════╝ 
                
                [  Creating a Dictionary  ]
                
                Dictionary<TKey, TValue>  - the TKey is a placeholder for the type of the keys. TValue is a placeholder for the type of the values.
                
                When you want to create a Dictionary variable, replace TKey with whatever type of data you want to use for the keys and
                replace TValue with the type you want to use for the values.
            */
            Dictionary<string, double> menu = new()
            {
                // {key,value} key-value pair
                {"Egg roll", 2.99 },
                {"Banh mi", 8.99 }
                //{"Banh mi", 13.99 }//throws an exception, key is already in the dictionary!
            };

            Dictionary<Weapon, int> backpack = new Dictionary<Weapon, int>();//will store the counts of each kind of weapon





            /*  
                ╔══════════════════════════╗ 
                ║ Dictionary<TKey, TValue> ║
                ╚══════════════════════════╝ 

                [  Adding items to a Dictionary  ]

                There are 3 ways to add items to a Dictionaruy:
                1) on the initializer. 
                2) using the Add method. 
                3) using [key] = value
            */

            menu.Add("sushi", 4.99);
            menu.Add("quinoa", 3.59);
            if (!menu.TryAdd("quinoa", 3.59))
            {
                Console.WriteLine("Quinoa is already on the menu. (not sure why though)");
            }
            try
            {
                menu.Add("quinoa", 6.59);//throws exception
            }
            catch (ArgumentException agex)
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine("Quinoa is already on the menu. (not sure why though)");
            }

            menu["Lasagna"] = 24.19;
            menu["Steak"] = 25;
            menu["Burrito"] = 10;
            menu["Burrito"] = 12;//overwrites the value

            menu["Chocolate Waffles"] = 12.99;

            menu["Truffle pizza"] = 1000000;

            backpack = new Dictionary<Weapon, int>()
            {
                {Weapon.Sword, 5 }
            };
            backpack.Add(Weapon.Axe, 2);
            backpack[Weapon.Spear] = 1;

            /*
                CHALLENGE 2:

                    Create a Dictionary that stores names (string) and grades. Call the variable grades.
             
                CHALLENGE 3:

                    Add students and grades to your dictionary that you created in CHALLENGE 2.
             
            */
            Dictionary<string, double> grades = new Dictionary<string, double>();
            List<string> students = new()
            { "Paul", "Truman", "Ryan", "Edwin", "John", "Joseph", "Stephen", "David" };
            Random rando = new Random();
            foreach (var student in students)
            {
                grades[student] = rando.NextDouble() * 100;
            }





            /*   
                ╔══════════════════════════╗ 
                ║ Dictionary<TKey, TValue> ║
                ╚══════════════════════════╝ 

                [  Looping over a Dictionary  ]

                You should use a foreach loop when needing to loop over the entire dictionary.
               
            */
            for (int i = 0; i < menu.Count; i++)
            {
                KeyValuePair<string, double> menuItem = menu.ElementAt(i);
            }
            Console.OutputEncoding = Encoding.UTF8;
            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("jp-JP");
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("jp-JP");
            Console.WriteLine("-----G's International------");
            foreach (var menuItem in menu)
            {
                string item = menuItem.Key;
                double price = menuItem.Value;
                Console.WriteLine($"{price,15:C2} {item}");
            }
            Console.WriteLine();
            foreach (KeyValuePair<Weapon, int> weaponCount in backpack)
                Console.WriteLine($"You have {weaponCount.Value} {weaponCount.Key}");

            /*
                CHALLENGE 4:

                    Loop over your grades dictionary and print each student name and grade.
             
            */
            PrintGrades(grades);





            /*   
                ╔══════════════════════════╗ 
                ║ Dictionary<TKey, TValue> ║
                ╚══════════════════════════╝ 

                [  Checking for a key in a Dictionary  ]

                There are 2 ways to see if a key is in the dictionary:
                1) ContainsKey(key)
                2) TryGetValue(key, out value)
               
            */

            name = "Chicken Nuggets";
            if (menu.ContainsKey(name))
            {
                double menuPrice = menu[name];
                Console.WriteLine($"{name} costs {menuPrice:C2}");
            }
            if (menu.TryGetValue(name, out double nuggetPrice))
            {
                Console.WriteLine($"{name} costs {nuggetPrice:C2}");
            }



            if (backpack.ContainsKey(Weapon.Axe))
                Console.WriteLine($"{Weapon.Axe} count: {backpack[Weapon.Axe]}");

            if (backpack.TryGetValue(Weapon.Spear, out int spearCount))
                Console.WriteLine($"{Weapon.Spear} count: {spearCount}");


            /*
                CHALLENGE 5:

                    Using either of the 2 ways to check for a key, 
                    look for a specific student in the dictionary. 
                    If the student is found, print out the student's grade
                    else print out a message that the student was not found
             
            */
            do
            {
                Console.Write("Student to find: ");
                string studentName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(studentName)) break;

                if (grades.TryGetValue(studentName, out double studentGrade))
                    Console.WriteLine($"{studentName}'s grade is {studentGrade:N2}");
                else
                    Console.WriteLine($"{studentName} is not in PG2!");
            } while (true);


            double paul = grades["Paul"];//get the value for the key





            /*   
                ╔══════════════════════════╗ 
                ║ Dictionary<TKey, TValue> ║
                ╚══════════════════════════╝ 

                [  Updating a value for a key in a Dictionary  ]

                To update an exisiting value in the dictionary, use the [ ]
                
               
            */
            backpack[Weapon.Mace] = 0; //sell all maces



            /*
                CHALLENGE 6:

                    Pick any student and curve the grade (add 5) that is stored 
                    in the grades dictionary
             
            */

            do
            {
                PrintGrades(grades);
                Console.Write("Student to curve: ");
                string studentName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(studentName)) break;

                if (grades.TryGetValue(studentName, out double studentGrade))
                {
                    grades[studentName] = (studentGrade > 95) ? 100 : studentGrade + 5;
                    Console.WriteLine($"{studentName}'s grade was {studentGrade:N2}. Now it's {grades[studentName]:N2}.");
                }
                else
                    Console.WriteLine($"{studentName} is not in PG2!");
            } while (true);
        }

        private static void PrintGrades(Dictionary<string, double> grades)
        {
            Console.WriteLine("   May PG02   ");
            foreach (var student in grades)
            {
                double grade = student.Value;
                Console.ForegroundColor = (grade < 59.5) ? ConsoleColor.Red :
                                          (grade < 69.5) ? ConsoleColor.DarkYellow :
                                          (grade < 79.5) ? ConsoleColor.Yellow :
                                          (grade < 89.5) ? ConsoleColor.Blue :
                                          ConsoleColor.Green;
                Console.Write($"{student.Value,7:N2}");
                Console.ResetColor();
                Console.WriteLine($" {student.Key}");
            }
        }

        private static void FindHero(List<string> jla, string name)
        {
            int index = IndexOf(jla, name);
            if (index >= 0) Console.WriteLine($"{name} was found at index {index}.");
            else Console.WriteLine($"{name} was not found.");
        }

        private static int IndexOf(List<string> jla, string searchItem)
        {
            int index = -1;
            for (int i = 0; i < jla.Count; i++)
            {
                if (jla[i].Equals(searchItem, StringComparison.InvariantCultureIgnoreCase))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}
