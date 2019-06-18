using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeWars.Tests
{
    [TestClass]
    public class StringExtensionsTest
    {
        #region <7kyu>
        [TestMethod]
        public void SayHelloAndSayGoodbye()
        {
            const string name = "Alex";
            Assert.AreEqual("Hello, Alex!", name.SayHello());
            Assert.AreEqual("Goodbye, Alex. See you again soon!", name.SayGoodbye());
        }
        #endregion

        #region <8kyu>
        [TestMethod]
        public void IsUpperCaseTest()
        {
            Assert.AreEqual(false, "c".IsUpperCase());
            Assert.AreEqual(true, "C".IsUpperCase());
            Assert.AreEqual(false, "ACSKLDFJSgSKLDFJSKLDFJ".IsUpperCase());
        }
        #endregion
    }
}
