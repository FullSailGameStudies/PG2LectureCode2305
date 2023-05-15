using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07CL
{
    public class Person
    {
        private int _age;

        public Person(int age, string name)
        {
            Age = age;
            //?? null coalescing operator
            // use name if its not null. if it's null, throw exception
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public int Age 
        { 
            get { return _age; } 
            set { 
                if(value >= 0 && value <= 125)
                    _age = value; 
            } 
        }

        public string Name { get; set; }


        public void ItsMyBirthday()
        {
            Age++;
            Console.WriteLine($"It's my birthday! I turned {Age} years old today. Let's eat some cake!");
        }
    }
}
