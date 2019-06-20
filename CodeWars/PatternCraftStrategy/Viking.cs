using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.PatternCraftStrategy
{
    public class Viking : IUnit
    {
        public IMoveBehavior MoveBehavior { get; set; }
        public int Position { get; set; }
        public Viking()
        {
            MoveBehavior = new Walk();
        }
        public void Move() => MoveBehavior.Move(this);
    }
}
