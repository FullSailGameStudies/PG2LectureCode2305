using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Day04
{
    internal class Program
    {
        static void BubbleSort(List<string> unsorted)
        {
            int count = unsorted.Count;
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < count; i++)
                {
                    int comp = unsorted[i - 1].CompareTo(unsorted[i]);
                    if (comp > 0)
                    {
                        /*
                        int temp = unsorted[i - 1];
                        unsorted[i-1] = unsorted[i];
                        unsorted[i] = temp;
                         */
                        (unsorted[i], unsorted[i-1]) = (unsorted[i-1], unsorted[i]);
                        swapped = true;
                    }
                }
                --count;
            } while (swapped);
        }

        static void Method(int N)
        {
            if(N < 200)
            {
                ++N;
                Method(N);
            }
            Console.WriteLine("WE'RE DONE!!!!");
        }
        static ulong[] _fibs;
        static void Main(string[] args)
        {
            Stopwatch sw = new();
            int max = 145;
            _fibs = new ulong[max];
            _fibs[0] = 0;
            _fibs[1] = 1;
            for (uint i = 0; i < max; i++)
            {
                sw.Restart();
                ulong fibResult = Fib(i);
                sw.Stop();
                long ms = sw.ElapsedMilliseconds;
                Console.Write($"Fib({i}) = {fibResult}");
                Console.CursorLeft = 50;
                Console.WriteLine($"{ms} (ms)");
            }

            Method(1);
            string s1 = "Batman", s2 = "Aquaman";
            //CompareTo
            //  -1  LESS THAN
            //   0  EQUAL TO
            //   1  GREATER THAN
            int compareResult = s1.CompareTo(s2);
            if(compareResult < 0) 
                Console.WriteLine($"{s1} is LESS THAN {s2}");
            else if (compareResult > 0)
                Console.WriteLine($"{s1} is GREATER THAN {s2}");
            else
                Console.WriteLine($"{s1} is EQUAL TO {s2}");

            List<string> A = new() { "Wonder Woman", "Batman", "Superman", "Flash", "Aquaman", "Blue Beetle", "Lobo" };
            foreach (var i in A) Console.Write($"{i} ");
            Console.WriteLine();
            BubbleSort(A);
            foreach (var i in A) Console.Write($"{i} ");
            Console.ReadKey();
            /*
                ╔═══════╗ 
                ║Sorting║
                ╚═══════╝ 
             
                Sorting is used to order the items in a list/array is a specific way
             
                CHALLENGE:

                    Convert this BubbleSort pseudo-code into a C# method             
                     
                    procedure bubbleSort(A : list of sortable items)
                      n := length(A)
                      repeat
                          swapped := false
                          for i := 1 to n - 1 inclusive do
                              if A[i - 1] > A[i] then
                                  swap(A, i - 1, i)
                                  swapped = true
                              end if
                          end for
                          n := n - 1
                      while swapped
                    end procedure
                    
            */






            /*
                ╔═════════╗ 
                ║Recursion║
                ╚═════════╝ 
             
                Recursion happens when a method calls itself. This creates a recursive loop.
                
                All recursive methods need an exit condition, something that prevents the loop from continuing.
              
            */
            int N = 0;
            //RecursiveLoop(N);
            Console.ResetColor();


            /*
                CHALLENGE:

                    convert this for loop to a recursive method called Bats. Call Bats here in Main.
             
                    for(int i = 0;i < 100;i++)
                    {
                        Console.Write((char)78);
                        Console.Write((char)65);
                        Console.Write(' ');
                    }
            */
            Console.WriteLine();
            Console.WriteLine();
            Bats(0);
            Console.WriteLine();
            List<int> b = new() { 66, 65, 84, 77, 65, 78, 33, 33 };
            foreach (var item in b) Console.Write((char)item);
            Console.WriteLine();

        }

        static void Bats(int i)
        {
            if(i < 100)
            {
                Console.Write((char)78);
                Console.Write((char)65);
                Console.Write(' ');
                Bats(i+1);
            }

            ulong f = Factorial(5);
            Console.WriteLine($"5! = {f}");
        }

        static ulong Fib(uint N)
        {
            if (N == 0) return 0;

            if (_fibs[N] != 0)
                return _fibs[N];

            ulong f = Fib(N - 1) + Fib(N - 2);
            _fibs[N] = f;
            return f;
        }

        static ulong Factorial(uint N)
        {
            ulong result = 1;
            if(N > 1)
            {
                result = N * Factorial(N - 1);
            }
            return result;
        }


        static void RecursiveLoop(int N)
        {
            //an Exit Condition. This will stop the loop when N >= Console.WindowWidth
            if (N < Console.WindowWidth)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(' ');
                Thread.Sleep(20);

                RecursiveLoop(N + 1);//calls itself which makes the method recursive

                Thread.Sleep(20);
                Console.CursorLeft = N;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write(' ');
            }
        }
    }
}
