using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ToolsTest.NUnitTest.NLogTest
{
    [TestFixture]
    public class NLogTest
    {
        NLog.Logger log = NLog.LogManager.GetLogger("NLogTest");

        [Test]
        public void Test()
        {

            try
            {
                log.Info("this is a info");
                Int32 dev = 1 - 1;
                Int32 i = 10 / dev;
            }
            catch (Exception ex)
            {
                log.Error("this is a error", ex);
            }

        }

    }
}
