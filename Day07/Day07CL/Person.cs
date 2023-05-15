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

        public int Age 
        { 
            get { return _age; } 
            set { 
                if(value >= 0 && value <= 125)
                    _age = value; 
            } 
        }

        public string Name { get; set; }
    }
}
