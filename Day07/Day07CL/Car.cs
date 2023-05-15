using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07CL
{
    public class Car
    {
        #region Fields
        //_camelCasingNamingConvention
        private ConsoleColor _exteriorColor;

        public static int NumberOfCarsMade = 0;
        #endregion

        #region Properties
        //full property. has a backing field.
        public ConsoleColor ExteriorColor
        {
            //same as...
            //public ConsoleColor GetExteriorColor() {return _exteriorColor;}
            get { return _exteriorColor; }

            //same as..
            //public void SetExteriorColor(ConsoleColor value) {_exteriorColor = value;}
            set { 
                if(value != ConsoleColor.DarkYellow)
                    _exteriorColor = value; 
            }
        }

        //auto-property.
        //Compiler provides the backing field and the code for get and set.
        public string Make { get; private set; } = "Ford";
        public string Model { get; private set; } = "T";
        #endregion

        #region Ctor (constructor)
        public Car(string make, string model, ConsoleColor exteriorColor) 
        {
            //make = Make;//BACKWARDS! WRONG!
            Make = make;//assign the parameter to the property/field
            Model = model;
            ExteriorColor = exteriorColor;

            ++NumberOfCarsMade;
        }
        #endregion

        #region Methods

        //NON-static methods can access non-static AND static members
        //static methods can ONLY access static members

        public void MyVehicle()//hidden parameter called 'this'. points to the instance that was used.
        {
            Console.WriteLine($"My ride is a {this.ExteriorColor} {this.Make} {this.Model}! sweet.");

        }
        public static void VehicleReport()//no 'this' parameter
        {
            Console.WriteLine($"We've constructed {NumberOfCarsMade} cars.");
            //Console.WriteLine($"{Make} {Model} {ExteriorColor}");
        }
        #endregion
    }
}
