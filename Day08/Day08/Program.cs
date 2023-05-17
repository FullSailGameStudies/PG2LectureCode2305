using Day08CL;
using System.Threading.Channels;

namespace Day08
{
    /*                    DERIVING CLASSESS          
                                                               
                                ╔═════════╗     ╔══════════╗ 
                 public  class  ║SomeClass║  :  ║OtherClass║ 
                                ╚═════════╝     ╚══════════╝
                                     │                │         
                                     └──┐             └──┐             
                                   ┌────▼────┐      ┌────▼────┐      
                                   │ Derived │      │  Base   │    
                                   │  Class  │      │  Class  │     
                                   └─────────┘      └─────────┘     

    
                CONSTRUCTORS: the derived constructor must call a base constructor
                public SomeClass(.....) : base(....)


     */
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
                CHALLENGE 1:

                    In the Day08CL project, add a new class, Pistol, that derives from Weapon.
                    Pistol should have properties for Rounds and MagCapacity.
                    Add a constructor that calls the base constructor
             
            */
            Person bob = new Person(13, "Robert");
            Employee serf = new Employee(10000, 22, "Steev");


            //Weapon pewpew = new Weapon();
            Pistol pewpew = new Pistol(15, 35, 500, 10);
            Console.WriteLine($"Range: {pewpew.Range}");





            /*  
                ╔═══════════╗ 
                ║ UPCASTING ║ - converting a derived type variable to a base type variable
                ╚═══════════╝ 
                
                This is ALWAYS safe.

                DerivedType A = new DerivedType();
                BaseType B = A;
            



                CHALLENGE 2:
                    Create a List of Weapon. Create several Pistols and add them to the list of weapons.
            */
            // UPCASTING
            //from a DERIVED (employee) to a BASE (Person)
            Person peep = serf;//upcasting. always safe.
            //Console.WriteLine($"Salary: {peep.Salary}");
            peep = bob;

            int num = 5;//4 bytes
            long bigNum = num;//implicit cast
            num = (int)bigNum;//explicit cast

            List<Weapon> weapons = new List<Weapon>();
            weapons.Add(pewpew);
            weapons.Add(WeaponFactory.CreatePistol(5, 10, 200, 50));//upcasting
            weapons.Add(new Knife(true, 1, 15));


            /*  
                ╔═════════════╗ 
                ║ DOWNCASTING ║ - converting a base type variable to a derived type variable
                ╚═════════════╝ 
                
                This is NOT SAFE!!!!!

            
                BaseType B = new DerivedType(); //upcasting
                DerivedType A = B; !! Build ERROR !!
            

                3 ways to downcast safely...
                1) explicit cast inside of a try-catch
                    try {  DerivedType A = B;  }
                    catch(Exception) { }

                2) use the 'as' keyword
                    NOTE: null will be assigned to A if B cannot be cast to DerivedType
                    DerivedType A = B as DerivedType;
                    if(A != null) { can use A }

                3) use 'is' in pattern matching
                    if(B is DerivedType A) { can use A }



                CHALLENGE 3:
                    Loop over the list of weapons.
                    Call ShowMe on each weapon.
                    Downcast to a Pistol and print the rounds and mag capacity of each pistol
            */
            Console.WriteLine("   Dora's Stash   ");
            foreach (var weapon in weapons)
            {
                weapon.ShowMe();
                if(weapon is Pistol bang)
                    Console.WriteLine($"\tRounds: {bang.Rounds}\tMagazine Capacity: {bang.MagCapacity}");                
                else if(weapon is Knife slasher)
                    Console.WriteLine($"\tIs double-sided? {slasher.DoubleSided}");
            }

            try
            {
                Employee ceo = (Employee)bob;//NOT SAFE!
            }
            catch (Exception)
            {
            }

            //use the 'as' keyword
            //if the casting doesn't work, NULL will be assigned to the variable
            Employee emp1 = bob as Employee;
            if(emp1 != null)
                Console.WriteLine($"Salary: {emp1.Salary}");

            //use pattern matching (the 'is' keyword)            
            if (bob is Employee emp2)
            {
                Console.WriteLine($"Salary: {emp2.Salary}");
            }






            /*  
                ╔═════════════╗ 
                ║ OVERRIDING  ║ - changing the behavior of a base method
                ╚═════════════╝ 
                
                2 things are required to override a base method:
                1) add 'virtual' to the base method
                2) add a method to the derived class that has the same signature as the base. put 'override' to the derived method


                FULLY OVERRIDING:
                    not calling the base method from the derived method

                EXTENDING:
                    calling the base method from the derived method




                CHALLENGE 4:
                    Override Weapon's ShowMe method in the Pistol method.
                    In Pistol's version, call the base version and print out the rounds and magCapacity
            */
        }
    }
}