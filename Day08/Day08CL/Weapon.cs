using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08CL
{
    public abstract class Weapon
    {
        public Weapon(int range, int damage)
        {
            Range = range;
            Damage = damage;
        }

        protected int _range;

        public int Range
        {
            get { return _range; }
            set { _range = value; }
        }

        public int Damage { get; }

        public virtual void ShowMe()
        {
            Console.WriteLine($"Range: {Range} Damage: {Damage}");
        }
    }
}
