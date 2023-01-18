using Hillel_Calculator_on_Git;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]   
    public class ConsoleTests
    {
        [TestMethod]
        [DataRow("94 + 242*5 / 2", "Результат : 699")]
        [DataRow("(9 + 3) * (8 / ( 1 + 3))", "Результат : 24")]
        public void TestConsole(string str, string expected)
        {

            Program program = new Program();
            

            var textReader = new StringReader(str);
            Console.SetIn(textReader);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            program.Calculate();

            var result = stringWriter.ToString();

            StringAssert.Contains(result, expected);
        }
    }
}
