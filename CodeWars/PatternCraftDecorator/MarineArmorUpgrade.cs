using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.PatternCraftDecorator
{
    public class MarineArmorUpgrade : IMarine
    {
        private IMarine marine;

        public MarineArmorUpgrade(IMarine marine)
        {
            this.marine = marine;
            Damage = marine.Damage;
            Armor = marine.Armor + 1;
        }

        public int Damage { get; set; }

        public int Armor { get; set; }
    }
}
