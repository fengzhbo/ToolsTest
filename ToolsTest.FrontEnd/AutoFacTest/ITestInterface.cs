using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsTest.FrontEnd.AutoFacTest
{
    public interface ITestPrice
    {
        Int32 WirteData(Int32 price);

        List<Int32> GetPrice();

    }

    public interface ITestDealer
    {

        Int32 AddDealer(Int32 dealerID);

        List<Int32> GetDealer();

    }
}
