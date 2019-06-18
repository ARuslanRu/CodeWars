using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeWars.Tests
{
    [TestClass]
    public class StringExtensionsTest
    {
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
