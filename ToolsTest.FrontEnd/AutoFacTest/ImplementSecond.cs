using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsTest.FrontEnd.AutoFacTest
{
    public class ImplementSecondPrice : ITestPrice
    {
        private HashSet<Int32> priceSet = new HashSet<int>();

        public int WirteData(int price)
        {
            if (priceSet.Add(price))
            {
                return price;
            }
            else
            {
                return 0;
            }

        }

        public List<int> GetPrice()
        {
            return priceSet.ToList<Int32>();
        }
    }

    public class ImplementSecondDealer : ITestDealer
    {
        private HashSet<Int32> dealerSet = new HashSet<int>();

        public int AddDealer(int dealerID)
        {
            if (dealerSet.Add(dealerID))
            {
                return dealerID;
            }
            else
            {
                return 0;
            }
        }

        public List<int> GetDealer()
        {
            return dealerSet.ToList<Int32>();
        }
    }
}
