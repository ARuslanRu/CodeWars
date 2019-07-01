using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using CodeWars.PatternCraftDecorator;


namespace CodeWars.UnitTests
{
    [TestFixture]
    public class PatternCraftDecorator
    {
        private Random random = new Random();

        [Test]
        public void _0_SingleUpgrade()
        {
            IMarine marine = new Marine(10, 1);

            Assert.AreEqual(11, new MarineWeaponUpgrade(marine).Damage);
            Assert.AreEqual(11, new MarineWeaponUpgrade(marine).Damage);
        }

        [Test]
        public void _1_DoubleUpgrade()
        {
            IMarine marine = new Marine(15, 1);
            marine = new MarineWeaponUpgrade(marine);
            marine = new MarineWeaponUpgrade(marine);

            Assert.AreEqual(17, marine.Damage);
        }

        [Test]
        public void _2_TripleUpgrade()
        {
            IMarine marine = new Marine(20, 1);
            marine = new MarineWeaponUpgrade(marine);
            marine = new MarineWeaponUpgrade(marine);
            marine = new MarineWeaponUpgrade(marine);

            Assert.AreEqual(23, marine.Damage);
        }

        [Test]
        public void _3_RandomTests()
        {
            for (int n = 0; n < 10; n++)
            {
                int dmg = random.Next(10, 50);
                int armor = random.Next(10, 50);

                IMarine marine = new Marine(dmg, armor);

                for (int i = 0; i < 10; i++)
                {
                    if (random.NextDouble() <= 0.5)
                    {
                        marine = new MarineWeaponUpgrade(marine);
                        dmg++;
                    }
                    else
                    {
                        marine = new MarineArmorUpgrade(marine);
                        armor++;
                    }
                }

                Assert.AreEqual(dmg, marine.Damage);
                Assert.AreEqual(armor, marine.Armor);
            }

        }
    }
}
