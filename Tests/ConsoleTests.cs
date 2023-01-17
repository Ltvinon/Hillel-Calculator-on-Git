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
        public void TestConsole()
        {

            Program program = new Program();
            

            var textReader = new StringReader("94 + 242*5 / 2");
            Console.SetIn(textReader);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            program.Calculate();

            var result = stringWriter.ToString();

            StringAssert.Contains(result, "Результат : 699");
        }
    }
}
