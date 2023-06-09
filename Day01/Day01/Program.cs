﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Day01
{
    /*                    METHODS          
                                                               
                ╔══════╗ ╔═══╗ ╔══════════╗ ╔════════════════╗ 
                ║public║ ║int║ ║SomeMethod║ ║(int someParam) ║ 
                ╚══════╝ ╚═══╝ ╚══════════╝ ╚════════════════╝ 
                    │      │         │               │         
              ┌─────┘      │         └──┐            └───┐     
         ┌────▼────┐   ┌───▼───┐   ┌────▼───┐       ┌────▼────┐
         │ Access  │   │ Return│   │ Method │       │Parameter│
         │ modifier│   │ type  │   │  Name  │       │  list   │
         └─────────┘   └───────┘   └────────┘       └─────────┘
    
            Vocabulary:
        
                  method (or function): https://www.w3schools.com/cs/cs_methods.php
                      a block of code that can be referenced by name to run the code it contains.

                  parameter: https://www.w3schools.com/cs/cs_method_parameters.php
                      a variable in the method definition.The list of parameters appear between the ( ) in a method header.

                  arguments:
                      when a method is called, arguments are the data you pass into the method's parameters
        
                  return type: https://www.w3schools.com/cs/cs_method_parameters_return.php
                      the value returned when a method finishes.
                      A return type must be specified on a method.
                      If no data is returned, use void.
    
        
                  List<T>: https://www.tutorialsteacher.com/csharp/csharp-list#:~:text=C%23%20-%20List%3CT%3E%201%20List%3CT%3E%20Characteristics%20List%3CT%3E%20equivalent,8%20Check%20Elements%20in%20List%20...%20More%20items
                    a collection of strongly typed objects that can be accessed by index. Indexes start at 0.



             Lecture videos:
                  METHODS LECTURE:
                  https://fullsailedu-my.sharepoint.com/:v:/g/personal/ggirod_fullsail_com/EW0hLKhQiBdFjOGq1WG6oRoB9TTQWJd1L9ic6VRiEYwgdg?e=J7uZXt
                  Chapters: Method Basics through Method Examples

                  LIST LECTURE:
                  https://fullsailedu-my.sharepoint.com/:v:/g/personal/ggirod_fullsail_com/ERG1iZHKJgFIoj6W8dhxPPgBIIY-Ot1b6Ueh-50Ggfcikg?e=goT9d6
                  Chapters: Array Basics through Looping Examples.

     */
    internal class Program
    {
        static void Info(List<string> names)
        {
            //Count: # of items in the list
            //Capacity: Length of the internal array
            Console.WriteLine($"Count: {names.Count}\tCapacity: {names.Capacity}");
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            /*
              Calling a method
                use the methods name.
                1) if the method needs data (i.e. has parameters), you must pass data to the method that matches the parameter types
                2) if the method returns data, it is usually best to store that data in a variable on the line where you call the method.
             
            */

            /*
                ╔══════════════════════════╗ 
                ║Parameters: Pass by Value.║
                ╚══════════════════════════╝ 
             
                Copies the value to a new variable in the method.
                
                For example, the AddOne method has a parameter called localNumber. localNumber is a variable that is local ONLY to the method.
                The value of the variable in main, number, is COPIED to the variable in AddOne, localNumber.
              
            */
            int number = 5;
            int plusOne = AddOne(number);
            //$ - interpolated string
            Console.WriteLine($"{number} + 1 = {plusOne}");

            /*
                CHALLENGE 1:

                    call the Sum method on the t1000 calculator. 
                    Print the sum that is returned.
             
            */
            Calculator t1000 = new Calculator();
            Calculator.DoIt();//b/c DoIt is static

            int number1 = 5, number2 = 2;
            int summer = t1000.Sum(number1, number2);
            Console.WriteLine(summer);




            /*   
                ╔═════════╗ 
                ║ List<T> ║
                ╚═════════╝ 
                
                [  Creating a List  ]
                
                List<T>  - the T is a placeholder for a type. It is a "Generic Type Parameter" to the class.
                
                When you want to create a List variable, replace T with whatever type of data you want to store in the List.
            */
            List<string> names;//value? null
            //creating an instance of the list class 
            names = new List<string>(10);// { "Bats", "Elon", "Bruce", "NOT Aquaman" };
            Info(names);//Count: 0   Capacity: 1? 10?
            //this list stores strings and only strings.
            names.Add("Clark");//adds to the end of the list
            Info(names);//Count: 1   Capacity: 4
            names.Add("Stephen");
            names.Add("Bruce");
            names.Add("Barry");
            names.Add("Alfred");
            //names.Insert(2, "Diana");
            Info(names);//Count: 5   Capacity: 5? 20?
            names.Add("Arthur");
            names.Add("Joseph");
            names.Add("John");
            names.Add("Ryan");
            Info(names);//Count: 9   Capacity: 12
            names.Add("Paul");
            names.Add("Truman");
            Info(names);//Count: 11   Capacity: 20?
            names.TrimExcess();
            Info(names);
            /*
                CHALLENGE 2:

                    Create a list that stores floats. Call the variable grades.
             
            */
            /*
                CHALLENGE 3:

                    Add a few grades to the grades list you created in CHALLENGE 2.
             
            */
            Random rando = new Random();
            List<float> grades = new List<float>() { rando.Next(101) };
            for (int i = 0; i < 10; i++)
                grades.Add((float)rando.NextDouble() * 100);






            /*   
                ╔═════════╗ 
                ║ List<T> ║
                ╚═════════╝ 

                [  Adding items to a List  ]

                There are 2 ways to add items to a list:
                1) on the initializer. 
                2) using the Add method. 
            */
            List<char> letters = new List<char>() { 'B', 'a', 't', 'm', 'a', 'n' };
            letters.Add('!');







            /*   
                ╔═════════╗ 
                ║ List<T> ║
                ╚═════════╝ 

                [  Looping over a List  ]

                You can loop over a list with a for loop or a foreach loop.
                1) for loop. use the Count property in the for condition.
                2) foreach loop
            */
            for (int i = 0; i < letters.Count; i++)
                Console.Write($" {letters[i]}");

            foreach (var letter in letters)
                Console.Write($" {letter}");


            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine($"Hello. My name is {names[i]}.");
            }

            foreach (string name in names)
            {

            }

            var anon = new { Name = "Bob" };//anonymous type
            /*
                CHALLENGE 4:

                    1) Fix the Average method of the calculator class to calculate the average of the list parameter.
                    2) Call the Average method on the t1000 variable and pass your grades list to the method.
                    3) print the average that is returned.
             
            */


            Console.ReadKey(true);
        }

        private static int AddOne(int localNumber)
        {
            return localNumber + 1;
        }


    }

    class Calculator
    {
        public static void DoIt()
        {

        }

        public int Sum(int num1, int num2)
        {
            return num1 + num2;
        }


        public float Average(List<float> numbers)
        {
            float avg = 0F;

            float sum = 0;
            //loop over the numbers and calculate the average
            int index = 0;
            while(index < numbers.Count)
            {
                sum += numbers[index];
                ++index;
            }
            avg = sum / numbers.Count;

            avg = numbers.Average();

            return avg;
        }
    }
}
