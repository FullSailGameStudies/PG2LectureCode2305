using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08CL
{
    public class Employee : Person
    {
        //I need a ctor that CALLS a Person ctor
        public Employee(float salary, int age, string name) : base(age, name)//calls the base ctor like a method
        {
            Salary = salary;
        }

        public override void Eat(string food)
        {
            Console.WriteLine($"Going on a break now. {Name} will be back in 2 hours.");
            base.Eat(food);
        }

        public float Salary { get; set; }
    }
}
