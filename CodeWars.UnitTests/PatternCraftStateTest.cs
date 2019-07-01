using System;
using NUnit.Framework;
using CodeWars.PatternCraftState;

namespace CodeWars.UnitTests
{
    [TestFixture]
    public class PatternCraftStateTest
    {
        private Random random = new Random();

        [Test]
        public void _0_TankState()
        {
            IUnit tank = new Tank();

            Assert.AreEqual(true, tank.CanMove);
            Assert.AreEqual(5, tank.Damage);
        }

        [Test]
        public void _1_SiegeState()
        {
            IUnit tank = new Tank();
            tank.State = new SiegeState();

            Assert.AreEqual(false, tank.CanMove);
            Assert.AreEqual(20, tank.Damage);
        }

        [Test]
        public void _2_MixState()
        {
            IUnit tank = new Tank();

            Assert.AreEqual(true, tank.CanMove);
            tank.State = new SiegeState();
            Assert.AreEqual(20, tank.Damage);
        }

        [Test]
        public void _3_RandomTests()
        {
            for (int n = 0; n < 10; n++)
            {
                IUnit tank = new Tank();
                var canMove = tank.CanMove;
                var damage = tank.Damage;

                for (int i = 0; i < 10; i++)
                {
                    if (random.NextDouble() <= 0.5)
                    {
                        tank.State = new SiegeState();
                        canMove = false;
                        damage = 20;
                    }
                    else
                    {
                        tank.State = new TankState();
                        canMove = true;
                        damage = 5;
                    }

                    Assert.AreEqual(canMove, tank.CanMove);
                    Assert.AreEqual(damage, tank.Damage);
                }
            }
        }
    }
}
