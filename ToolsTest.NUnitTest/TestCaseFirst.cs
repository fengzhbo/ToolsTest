using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ToolsTest.FrontEnd;

namespace ToolsTest.NUnitTest
{
    [TestFixture]
    public class TestCaseFirst
    {
        [TestCase]
        public void TestForTest()
        {
            var forTestInstance = new Moq.Mock<IForTest>();

            forTestInstance.Setup(test => test.HandleString("test")).Returns("TEST");

            Assert.AreEqual("TEST",forTestInstance.Object.HandleString("test"));

        }
    }
}
