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

            #region 同个服务注册多个实现时，后边的会覆盖前边的
            builder.RegisterType<ImplementSecondPrice>().As<ITestPrice>();

            builder.RegisterType<ImplementSecondDealer>().As<ITestDealer>();

            builder.RegisterType<ImplementFirstPrice>().As<ITestPrice>();

            builder.RegisterType<ImplementFirstDealer>().As<ITestDealer>();
            #endregion


            #region 注册同一个服务不同实现，但是用不同的名字，用特定的名字获取或者不指定名字时，会获取先声明的
            builder.RegisterType<ImplementFirstPrice>().Named<ITestPrice>("FirstPrice");

            builder.RegisterType<ImplementFirstDealer>().Named<ITestDealer>("FirstDealer");

            builder.RegisterType<ImplementSecondPrice>().Named<ITestPrice>("SecondPrice");

            builder.RegisterType<ImplementSecondDealer>().Named<ITestDealer>("SecondDealer");
            #endregion

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

        [TestCase]
        public void TestPriceWithName()
        {
            ITestPrice priceDal = iocContainer.ResolveNamed<ITestPrice>("FirstPrice");

            ITestPrice priceDal2 = iocContainer.ResolveNamed<ITestPrice>("SecondPrice");

            Int32 priceID = 5;
            Int32 willPriceID = 5;


            Assert.IsInstanceOf<ImplementFirstPrice>(priceDal,"this is first price implement.");
            Assert.IsInstanceOf<ImplementSecondPrice>(priceDal2,"this is second price implement.");

            Assert.AreEqual(priceDal.WirteData(priceID), willPriceID);
            Assert.AreEqual(priceDal2.WirteData(priceID), willPriceID);

        }



    }
}
