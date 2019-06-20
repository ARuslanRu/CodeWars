using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.PatternCraftStrategy
{
    public class Walk : IMoveBehavior
    {
        public void Move(IUnit unit)
        {
            unit.Position += 1;
        }
    }
}
