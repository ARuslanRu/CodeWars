using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.PatternCraftDecorator
{
    public class MarineWeaponUpgrade: IMarine
    {
        private IMarine marine;

        public MarineWeaponUpgrade(IMarine marine)
        {
            this.marine = marine;
            Damage = marine.Damage + 1;
            Armor = marine.Armor;
        }

        public int Damage { get; set; }

        public int Armor { get; set; }
    }
}
