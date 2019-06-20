using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using CodeWars.PatternCraftAdapter;


namespace CodeWars.UnitTests
{
    [TestFixture]
    public class PatternCraftAdapterTest
    {
        static IEnumerable<MethodInfo> GetExtensionMethods(Assembly assembly, Type extendedType)
        {
            var query = from type in assembly.GetTypes()
                        where type.IsSealed && !type.IsGenericType && !type.IsNested
                        from method in type.GetMethods(BindingFlags.Static
                            | BindingFlags.Public | BindingFlags.NonPublic)
                        where method.IsDefined(typeof(ExtensionAttribute), false)
                        where method.GetParameters()[0].ParameterType == extendedType
                        select method;
            return query;
        }

        [Test]
        public void _0_Mario_Does_Not_Have_Attack()
        {
            Assert.IsFalse(GetExtensionMethods(typeof(Mario).Assembly, typeof(Mario)).Any(em => em.Name == "Attack"), "Extension methods are not allowed");
        }

        [Test]
        public void _1_MarioAdapter_Can_Attack()
        {
            var marioAdapter = new MarioAdapter(new Mario());
            var target = new Target { Health = 33 };

            marioAdapter.Attack(target);

            Assert.AreEqual(30, target.Health);
        }

        [Test]
        public void _2_All_Units_Attack()
        {
            var units = new List<IUnit>
        {
            new Marine(),
            new Zealot(),
            new Zergling(),
            new MarioAdapter(new Mario())
        };

            var target = new Target { Health = 22 };

            units.ForEach(unit => unit.Attack(target));

            Assert.AreEqual(0, target.Health);
        }
    }
}