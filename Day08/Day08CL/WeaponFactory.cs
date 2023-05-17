using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08CL
{
    public static class WeaponFactory
    {
        //EVERYTHING in the class must be static
        public static Weapon CreatePistol(int rounds, int magCapacity, int range, int damage)
        {
            return new Pistol(rounds, magCapacity, range, damage);
        }
    }
}
