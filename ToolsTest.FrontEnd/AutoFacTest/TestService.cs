using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsTest.FrontEnd.AutoFacTest
{
    public class TestService
    {
        ITestPrice _priceDal;
        ITestDealer _dealerDal;

        public TestService(ITestDealer dealerDal, ITestPrice priceDal)
        {
            _priceDal = priceDal;
            _dealerDal = dealerDal;

        }

        public Int32 RegisterDealer(Int32 dealerId)
        {
            return _dealerDal.AddDealer(dealerId);
        }

        public List<Int32> GetDealers()
        {
            return _dealerDal.GetDealer();
        }

        public Int32 PublicPrice(Int32 price)
        {
            return _priceDal.WirteData(price);
        }

    }
}
