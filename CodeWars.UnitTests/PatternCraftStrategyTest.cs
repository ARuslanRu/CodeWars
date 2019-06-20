using NUnit.Framework;
using System;
using CodeWars.PatternCraftStrategy;

namespace CodeWars.UnitTests
{
    [TestFixture]
    public class PatternCraftStrategyTest
    {
        private Random random = new Random();

        [Test]
        public void _0_WalkMove()
        {
            IUnit viking = new Viking();

            viking.Move();
            Assert.AreEqual(1, viking.Position);
            viking.Move();
            Assert.AreEqual(2, viking.Position);
        }

        [Test]
        public void _1_FlyMove()
        {
            IUnit viking = new Viking();
            viking.MoveBehavior = new Fly();

            viking.Move();
            Assert.AreEqual(10, viking.Position);
            viking.Move();
            Assert.AreEqual(20, viking.Position);
        }

        [Test]
        public void _2_MixMove()
        {
            IUnit viking = new Viking();

            viking.Move();
            Assert.AreEqual(1, viking.Position);

            viking.MoveBehavior = new Fly();
            viking.Move();
            Assert.AreEqual(11, viking.Position);
        }


        [Test]
        public void _3_RandomTests()
        {
            for (int n = 0; n < 10; n++)
            {
                IUnit viking = new Viking();
                int position = viking.Position;

                for (int i = 0; i < 10; i++)
                {
                    if (random.NextDouble() <= 0.5)
                    {
                        viking.MoveBehavior = new Fly();
                        position += 10;
                    }
                    else
                    {
                        viking.MoveBehavior = new Walk();
                        position += 1;
                    }
                    viking.Move();
                }

                Assert.AreEqual(position, viking.Position);
            }
        }
    }
}
