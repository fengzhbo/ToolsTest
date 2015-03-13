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

        public List<VendorPrice> GetVendorPriceList()
        {
            string sql = @"SELECT TOP 10000 
		PriceID,DealerID,p.CarID,SalePrice,SubscribePrice,DeliveryWaitdays,Ready,Favourable,SmsPrice,
		ISNULL(NewsID,10000000) AS NewsID,
		ISNULL(FavorablePrice,10000) AS FavorablePrice,
		ISNULL(CarReferPrice,100000) AS CarReferPrice,
		ISNULL(nc.PresentPrice,2000) AS PresentPrice,
		GETDATE() AS NewsPubTime,
		GETDATE() as EndDateTime,
		1 AS StoreState
    FROM dbo.VendorPrice p
    LEFT JOIN
    (
		SELECT 
		news.NewsID,news.VendorID,car.CarId,car.FavorablePrice,
		car.CarReferPrice,news.PresentPrice,news.NewsPubTime,news.EndDateTime,
		car.StoreState
		FROM dbo.VendorPromotionNewsCar car
		INNER JOIN dbo.VendorNews news ON car.NewsID=news.NewsID
		WHERE news.IsTemplateNews=1
		AND news.StartDateTime>=GETDATE()-1 
		AND news.EndDateTime<=GETDATE()
    )
    AS nc ON nc.CarId=p.CarID AND nc.VendorID=p.DealerID
    ORDER BY PriceID DESC";

            SqlConnection conn = new SqlConnection("server=192.168.87.63;database=membersite;User ID=epuser;password=ep123");

            return conn.Query<VendorPrice>(sql).ToList();

        }

    }
}
