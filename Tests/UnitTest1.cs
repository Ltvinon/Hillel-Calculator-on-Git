using Hillel_Calculator_on_Git;
using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Extensions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Program = Hillel_Calculator_on_Git.Program;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIsDelim()
        {
            Program program = new Program();
            bool result = program.IsDelim('=');
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        [DataRow('+')]
        [DataRow('-')]
        [DataRow('/')]
        [DataRow('*')]
        [DataRow('(')]
        [DataRow(')')]
        public void TestIsOper(char c)
        {
            Program program = new Program();
            bool result = program.IsOper(c);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        [DataRow('+', 2)]
        [DataRow(' ', 5)]
        public void TestGetPriurity(char c, int n)
        {
            Program program = new Program();
            int result = program.GetPriurity(c);
            Assert.AreEqual(result, n);
        }

        [TestMethod]
        [DataRow("(9 + 3) * (8 / ( 1 + 3))+2,1", "9 3 + 8 1 3 + / * 2,1 + ")]
        public void TestToPoland(string str, string result)
        {
            Program program = new Program();
            var current = program.ToPoland(str);
            Assert.AreEqual(result, current);
        }

        [TestMethod]
        [DataRow("9 3 + 8 1 3 + / * 2,1 + ", 26.1)]
        public void TestCount(string str, double result)
        {
            Program program = new Program();
            var current = program.Count(str);
            Assert.AreEqual(result, current);
        }

        [TestMethod]
        public void TestZero()
        {
            Program program = new Program();
            var expected = double.Parse("∞");
            var temp = program.ToPoland("24 / 0");
            var current = program.Count(temp);
            
            Assert.AreEqual(expected, current);
        }


    }
}