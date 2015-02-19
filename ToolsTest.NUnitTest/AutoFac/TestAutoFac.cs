using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using NUnit.Framework;
using ToolsTest.FrontEnd.AutoFacTest;

namespace ToolsTest.NUnitTest.AutoFac
{
    [TestFixture]
    public class TestAutoFac
    {
        private IContainer iocContainer;

        [TestFixtureSetUp]
        public void InitTest()
        {

            var builder = new ContainerBuilder();

            builder.Register<ImplementFirstPrice>().As<ITestPrice>();

            builder.Register<ImplementFirstDealer>().As<ITestDealer>();

            builder.Register<ImplementSecondPrice>().As<ITestPrice>();

            builder.Register<ImplementSecondDealer>().As<ITestDealer>();

            builder.RegisterType<TestService>().AsSelf();

            iocContainer = builder.Build();
        }

        [TestFixtureTearDown]
        public void DisposeTest()
        {
            if (iocContainer != null)
            {
                iocContainer.Dispose();
            }

        }


        [TestCase]
        public void TestPrice()
        {
            ITestPrice priceDal = iocContainer.Resolve<ITestPrice>();

            Int32 priceID = 5;
            Int32 willPriceID = 5;

            Int32 retPriceID = priceDal.WirteData(priceID);

            Assert.AreEqual(retPriceID, willPriceID);

        }



    }
}
