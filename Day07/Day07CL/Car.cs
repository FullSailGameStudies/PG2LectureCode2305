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
        #endregion
    }
}
