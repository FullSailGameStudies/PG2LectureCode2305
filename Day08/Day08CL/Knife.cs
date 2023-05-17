using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08CL
{
    public class Knife : Weapon
    {
        public Knife(bool doubleSided, int range, int damage) : base(range, damage)
        {
            DoubleSided = doubleSided;
        }

        public bool DoubleSided { get; }

        public override void ShowMe()
        {
            base.ShowMe();
            Console.WriteLine($"\tIs double-sided? {DoubleSided}");
        }
    }
}
