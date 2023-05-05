using System;
using System.Collections.Generic;
using System.Linq;

namespace Day03
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
        static void Main(string[] args)
        {


            /*   
                ╔═══════════════════════════════╗ 
                ║Parameters: optional parameters║
                ╚═══════════════════════════════╝ 
                
                Unless specified, parameters to a method are required.
                However, you can make parameters optional, meaning when calling the method, you aren't required to pass values for the optional parameters.

                REQUIREMENT:
                    - all optional parameters have to be at the end of the list of parameters
                    - in the list of parameters, assign a value to any parameter you want to be optional
            */
            string file = "highScores";
            string postfile = PostFix(file); //if you don't pass a value, the default value will be used for the optional parameter
            postfile = PostFix(file, 5); //if a value is passed, it will be used for the optional parameter



            /*
                CHALLENGE 1:

                    Write a ColorWriteLine method to print a message with a foreground color in the console. ConsoleColor
                    1) add a string message parameter AND an optional color parameter. 
                        Choose whatever default color you want.
                    2) in the method, set the foreground color to the optional parameter
                    3) print the message
             
            */

            List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] iNums = new int[] { 1, 2, 3, 4, 5, };
            List<int> n1 = new();
            for (int i = 0; i < iNums.Length; i++)
            {
                n1.Add(iNums[i]);
            }
            List<int> n2 = new(iNums);
            List<int> n3 = iNums.ToList();
            var n4 = numbers.ToList();
            ShowMe(n4);

            List<int> n5 = new();
            MakeList(ref n5);
            Console.WriteLine("--NUMBERS--");
            foreach (int number in n5) { 
                Console.WriteLine(number);
            }
            Console.ReadKey();


            ColorWriteLine("Because I'm BATMAN!");
            ColorWriteLine("Because I'm BATMAN!", ConsoleColor.DarkCyan);
            Random randy = new Random();
            while (true)
            {
                Console.CursorLeft = randy.Next(Console.WindowWidth);
                Console.CursorTop = Console.WindowHeight / 2;
                //Console.SetCursorPosition(randy.Next(Console.WindowWidth), randy.Next(Console.WindowHeight));
                ColorWriteLine("    BATMAN     ", (ConsoleColor)randy.Next(16));
            }

        }

        static void MakeList(ref List<int> list)
        {
            list = new();//creates a new list
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }
        }

        static void ShowMe(List<int> nums)//pass by...value. COPY. copying the memory address.
        {
            for (int i = 0; i < nums.Count; i++)
            {
                nums[i] *= 5;
                Console.WriteLine(nums[i]);
            }
        }
        static void ColorWriteLine(string message, ConsoleColor color = ConsoleColor.Red)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        static string PostFix( string fileName, int postFixNumber = 1) //postFixNumber is optional
        {
            return fileName + postFixNumber;
        }
    }
}
