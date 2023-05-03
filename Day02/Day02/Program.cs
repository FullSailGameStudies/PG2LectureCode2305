﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Day02
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


    
    ╔═══════════╗ 
    ║Return type║ Return type defines the type of the data being returned.
    ╚═══════════╝
    │
    │
    └── If NO data is returned, then use "void" for the return type.
    │    public void PrintSomething()
    │    {
    │        Console.WriteLine("Something");
    │    }
    │
    │
    └── If a method returns data, then the return type must match the type of the data being returned.
        public float GetMyGrade()
        {
            return 99.9F; //returning a float so set return type to float
        }

    ╔══════════╗ 
    ║Parameters║ Parameters define the data passed to the method.
    ╚══════════╝
    │
    │
    └── If NO data is passed to the method, leave the parenthesis empty. EX: ( )
    │    public void PrintSomething()
    │   {  }
    │
    │
    └── If passing data to the method, then define the variable the method will use to store the data.
        Parameters are just variables therefore parameters need 2 things: <type> <name>
        Example:
        public void PrintMyGrade(float myGrade)
        {
            Console.WriteLine($"My grade is {myGrade}");
        }

        

     */
    internal class Program
    {
        static Random randy = new Random();
        static void Main(string[] args)
        {

            /*   
                ╔══════════════════════════════╗ 
                ║Parameters: Pass by Reference.║
                ╚══════════════════════════════╝ 
                Sends the variable itself to the method. The method parameter gives the variable a NEW name (i.e. an alias)
                  
                NOTE: if the method assigns a new value to the parameter, the variable used when calling the method will change too.
                    This is because the parameter is actually just a new name for the other variable.
            */
            string spider = "Spiderman";
            Console.WriteLine(spider);
            bool isEven = PostFix(ref spider);
            Console.WriteLine($"{spider}. Is Even? {isEven}");
            string theMan = "Batman";
            isEven = PostFix(ref theMan);


            /*
                CHALLENGE 1:

                    Write a method to curve the grade variable.
                    1) pass it in by reference
                    2) calculate a 5% curve
                    3) curve the parameter in the method
                    4) return the curve amount
             
            */
            double grade = randy.NextDouble() * 100;
            Console.WriteLine($"My grade is {grade:N2}.");
            double curved = CurveGrade(ref grade);
            Console.WriteLine($"My grade was curved by {curved:N2} to {grade:N2}.");




            /*  
                ╔═══════════════════════════╗ 
                ║Parameters: Out Parameters.║
                ╚═══════════════════════════╝  
                  A special pass by reference parameter. 
                  DIFFERENCES:
                    the out parameter does NOT have to be initialized before sending to the method
                    the method MUST assign a value to the parameter before returning

            */
            Console.ReadKey();
            ConsoleColor randoColor; //don't have to initialize it
            GetRandomColor(out randoColor);
            Console.BackgroundColor = randoColor;
            Console.WriteLine("Hello Gotham!");
            Console.ResetColor();


            /*
                CHALLENGE 2:

                    Write a method to calculate the stats on a list of grades
                    1) create a list of grades in main and add a few grades to it
                    2) create a method to calculate the min, max, and avg. 
                       use out parameters to pass this data back from the method.
                    3) print out the min, max, and avg
             
            */






            /*   
                ╔═════════╗ 
                ║ List<T> ║
                ╚═════════╝ 

                [  Removing from a List  ]

                There are 2 main ways to remove from a list:
                1) bool Remove(item).  will remove the first one in the list that matches item. returns true if a match is found else removes false.
                2) RemoveAt(index). will remove the item from the list at the index

            */
            List<string> dc = new() { "Batman", "Wonder Woman", "Aquaman", "Superman", "Aquaman" };
            bool found = dc.Remove("Aquaman");

            dc.RemoveAt(dc.Count - 1);//removes the last item

            /*
                CHALLENGE 3:

                    Using the list of grades you created in CHALLENGE 2, remove the min and max grades from the list.
                    Print the grades.
            */




        }

        private static double CurveGrade(ref double grade)
        {
            double curveAmount = grade * 0.05;
            grade += curveAmount;
            return curveAmount;
        }

        private static void GetRandomColor(out ConsoleColor outColor)
        {
            //the method MUST initialize the outColor parameter
            outColor = (ConsoleColor)randy.Next(16);

        }

        static bool PostFix(ref string hero) //hero is now an alias to the variable used when calling PostFix. In this case, hero is an alias to the spider variable.
        {
            int postFix = randy.Next(100);
            hero += $"-{postFix}"; //updating hero now also updates spider
            return postFix % 2 == 0; //isEven
        }
    }
}
