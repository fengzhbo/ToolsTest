using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsTest.FrontEnd.AutoFacTest
{
    public class ImplementFirstPrice : ITestPrice
    {
        private List<Int32> priceData = new List<int>();

        public int WirteData(int price)
        {
            priceData.Add(price);

            return price;
        }

        public List<int> GetPrice()
        {
            return priceData;
        }
    }

    public class ImplementFirstDealer : ITestDealer
    {
        private List<Int32> dealerData = new List<int>();

        public int AddDealer(int dealerID)
        {
            dealerData.Add(dealerID);

            return dealerID;
        }

        public List<int> GetDealer()
        {
            return dealerData;
        }
    }

}
