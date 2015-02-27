using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ToolsTest.FrontEnd.StackExchange
{
    public class dal_dapper
    {
        public List<Dealer> GetVendorList()
        {
            string sql = @"SELECT top 10000 [VendorID]
      ,[VendorName]
      ,[VendorBizMode]
      ,[CityID]
      ,[CityName]
      ,[ProvinceID]
      ,[ProvinceName]
      ,[LocationID]
      ,[LocationName]
      ,[VendorTel]
      ,[VendorStatus]
      ,[VendorFullName]
      ,[VendorSaleAddr]
      ,[MainBrand]
      ,[GoogleMapLat]
      ,[GoogleMapLng]
      ,[SaleRegionType]
  FROM [Membersite].[dbo].[VendorInfo] order by VendorID desc";

            SqlConnection conn = new SqlConnection("server=192.168.87.63;database=membersite;User ID=epuser;password=ep123");

            return conn.Query<Dealer>(sql).ToList();

        }

    }
}
