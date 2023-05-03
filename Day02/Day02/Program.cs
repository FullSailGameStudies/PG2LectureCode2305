using System;
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
            List<double> grades = new();
            for (int i = 0; i < 10; i++)
                grades.Add(randy.NextDouble() * 100);

            //double min, max, avg;
            //CalculateStats(grades, out min, out max, out avg);
            (double min, double max, double avg) = CalculateStats(grades);
            PrintGrades(grades);
            Console.ResetColor();
            ColorCode(min);
            Console.WriteLine($"Min: {min:N2}");
            ColorCode(max);
            Console.WriteLine($"Max: {max:N2}");
            ColorCode(avg);
            Console.WriteLine($"Average: {avg:N2}");
            Console.ResetColor();






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
            bool found = dc.Remove("Aquaman");//only removes the FIRST Aquaman

            dc.RemoveAt(dc.Count - 1);//removes the last item

            /*
                CHALLENGE 3:

                    Using the list of grades you created in CHALLENGE 2,                     
                    Remove all failing grades.
                    Print the grades.
            */
            //for (int i = 0; i < grades.Count; i++)
            //{
            //    if (grades[i] < 59.5)
            //    {
            //        grades.RemoveAt(i);
            //        i--;
            //    }
            //}
            //for (int i = 0; i < grades.Count; )
            //{
            //    if (grades[i] < 59.5)
            //        grades.RemoveAt(i);
            //    else
            //        ++i;
            //}
            for (int i = grades.Count - 1; i >= 0; i--)
            {
                if (grades[i] < 59.5)
                    grades.RemoveAt(i);
            }

            PrintGrades(grades);



        }

        private static void PrintGrades(List<double> grades)
        {
            Console.WriteLine("--GRADES--");
            foreach (var pg2Grade in grades)
            {
                //(condition) ? <true case> : <false case>
                ColorCode(pg2Grade);
                //,7 -- right-aligns in 7 spaces
                //:N2 -- number w/ 2 decimal places
                Console.WriteLine($"{pg2Grade,7:N2}");
            }
            Console.ResetColor();
        }

        private static void ColorCode(double grade)
        {
            Console.ForegroundColor =   (grade < 59.5) ? ConsoleColor.Red :
                                        (grade < 69.5) ? ConsoleColor.DarkYellow :
                                        (grade < 79.5) ? ConsoleColor.Yellow :
                                        (grade < 89.5) ? ConsoleColor.Blue :
                                        ConsoleColor.Green;
        }

        private static void CalculateStats(List<double> grades, out double min, out double max, out double avg)
        {
            //min = grades.Min();
            //max = grades.Max();
            //avg = grades.Average();

            min = double.MaxValue;
            max = double.MinValue;
            double sum = 0;
            foreach (var grade in grades)
            {
                sum += grade;
                min = Math.Min(min, grade);
                max = Math.Max(max, grade);
            }
            avg = sum / grades.Count;
        }


        private static (double,double,double) CalculateStats(List<double> grades)
        {
            //min = grades.Min();
            //max = grades.Max();
            //avg = grades.Average();

            double min = double.MaxValue;
            double max = double.MinValue;
            double sum = 0;
            foreach (var grade in grades)
            {
                sum += grade;
                min = Math.Min(min, grade);
                max = Math.Max(max, grade);
            }
            double avg = sum / grades.Count;
            return (min, max, avg);
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
