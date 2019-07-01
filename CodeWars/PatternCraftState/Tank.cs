﻿namespace CodeWars.PatternCraftState
{
    public class Tank : IUnit
    {
        public Tank()
        {
            State = new TankState();
        }

        public IUnitState State { get; set; }

        public bool CanMove { get { return State.CanMove; } }
        public int Damage { get { return State.Damage; } }
    }
}
