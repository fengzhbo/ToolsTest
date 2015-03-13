using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace ToolsTest.FrontEnd.StackExchange
{
    public class RedisClient
    {
        private static ConnectionMultiplexer redis;

        private static void InitConnection()
        {
            redis = ConnectionMultiplexer.Connect("192.168.87.134");
        }

        static RedisClient()
        {
            InitConnection();
        }

        public static ConnectionMultiplexer Create()
        {
            if (redis == null || !redis.IsConnected)
            {
                InitConnection();
            }

            return redis;
        }

        #region 初始化数据

        public static void InsertVendorPrice_Model()
        {
            var listPrices = new dal_dapper().GetVendorPriceList();

            foreach (var dd in listPrices)
            {
                SaveToRedis(dd);
            }

        }

        public static void InsertVendorInfo_Field()
        {
            var listDealers = new dal_dapper().GetVendorList();

            IDatabase db = redis.GetDatabase(2);

            foreach (Dealer dd in listDealers)
            {
                HashEntry[] entrys = new HashEntry[] 
                { 
                    new HashEntry("VendorID", dd.VendorID),
                    new HashEntry("VendorName", String.IsNullOrEmpty(dd.VendorName)?"":dd.VendorName),
                    new HashEntry("VendorBizMode",dd.VendorBizMode),
                    new HashEntry("CityID",dd.CityID),
                    new HashEntry("CityName",String.IsNullOrEmpty(dd.CityName)?"":dd.CityName),

                    new HashEntry("ProvinceID",dd.ProvinceID),
                    new HashEntry("ProvinceName", String.IsNullOrEmpty(dd.ProvinceName)?"":dd.ProvinceName),
                    new HashEntry("LocationID",dd.LocationID),
                    new HashEntry("LocationName", String.IsNullOrEmpty(dd.LocationName)?"":dd.LocationName),
                    new HashEntry("VendorTel",String.IsNullOrEmpty(dd.VendorTel)?"":dd.VendorTel),

                    new HashEntry("VendorStatus",dd.VendorStatus),
                    new HashEntry("VendorFullName",String.IsNullOrEmpty(dd.VendorFullName)?"":dd.VendorFullName),
                    new HashEntry("VendorSaleAddr", String.IsNullOrEmpty(dd.VendorSaleAddr)?"":dd.VendorSaleAddr),
                    new HashEntry("MainBrand",String.IsNullOrEmpty(dd.MainBrand)?"":dd.MainBrand),
                    new HashEntry("GoogleMapLat",String.IsNullOrEmpty(dd.GoogleMapLat)?"":dd.GoogleMapLat),

                    new HashEntry("GoogleMapLng",String.IsNullOrEmpty(dd.GoogleMapLng)?"":dd.GoogleMapLng),
                    new HashEntry("SaleRegionType",dd.SaleRegionType)
                };

                db.HashSet("vendorinfo:" + dd.VendorID.ToString(), entrys);
            }

        }

        public static void InsertVendorInfo_Model()
        {
            var listDealers = new dal_dapper().GetVendorList();

            foreach (Dealer dd in listDealers)
            {
                SaveToRedis(dd);
            }

        }

        private static void SaveToRedis(VendorPrice price)
        {
            IDatabase db = redis.GetDatabase(1);

            using (MemoryStream ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize<VendorPrice>(ms, price);

                db.HashSet("vendorprice", "id:" + price.PriceId.ToString(), ms.ToArray());
            }

        }

        private static void SaveToRedis(Dealer dealer)
        {
            IDatabase db = redis.GetDatabase(1);

            using (MemoryStream ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize<Dealer>(ms, dealer);

                db.HashSet("vendorinfo", "id:" + dealer.VendorID.ToString(), ms.ToArray());
            }

        }
        #endregion

        public static void ReadDataOnly_Model()
        {
            IDatabase db = redis.GetDatabase(1);

            db.HashGet("vendorinfo", "id:100035099");

        }

        public static Dealer ReadDataOnly_Model_Deserialize()
        {
            IDatabase db = redis.GetDatabase(1);

            RedisValue redisValue = db.HashGet("vendorinfo", "id:100035099");

            Dealer dealer = new Dealer();

            if (redisValue != RedisValue.Null)
            {
                using (MemoryStream ms = new MemoryStream((byte[])redisValue))
                {
                    dealer = ProtoBuf.Serializer.Deserialize<Dealer>(ms);
                }
            }

            return dealer;

        }

        public static List<Dealer> ReadDataOnly_Model_Deserialize_List()
        {
            IDatabase db = redis.GetDatabase(1);

            RedisValue[] fields = new RedisValue[] {
            
                "id:100035099",
                "id:100035098",
                "id:100035097",
                "id:100035096",
                "id:100035095",
                "id:100035094",
                "id:100035093",
                "id:100035092",
                "id:100035091",
                "id:100035090",
                "id:100035089",
                "id:100035088",
                "id:100035087",
                "id:100035086",
                "id:100035085",
                "id:100035084",
                "id:100035083",
                "id:100035082",
                "id:100035081",
                "id:100035080",
                "id:100035079",
                "id:100035078",
                "id:100035077",
                "id:100035076",
                "id:100035075",
                "id:100035074",
                "id:100035073",
                "id:100035072",
                "id:100035071",
                "id:100035070"
            
            
            };

            RedisValue[] redisValues = db.HashGet("vendorinfo", fields);

            List<Dealer> dealer = new List<Dealer>();

            foreach (RedisValue redisValue in redisValues)
            {
                if (redisValue != RedisValue.Null)
                {
                    using (MemoryStream ms = new MemoryStream((byte[])redisValue))
                    {
                        dealer.Add(ProtoBuf.Serializer.Deserialize<Dealer>(ms));
                    }
                }
            }
            return dealer;

        }


        public static HashEntry[] ReadDataOnly_Field()
        {
            IDatabase db = redis.GetDatabase(2);

            return db.HashGetAll("vendorinfo:100035099");

        }

        public static List<HashEntry[]> ReadDataOnly_Field_List()
        {
            IDatabase db = redis.GetDatabase(2);

            RedisKey[] keyList = new RedisKey[] { 
                        "vendorinfo:100035099",
            "vendorinfo:100035098",
            "vendorinfo:100035097",
            "vendorinfo:100035096",
            "vendorinfo:100035095",
            "vendorinfo:100035094",
            "vendorinfo:100035093",
            "vendorinfo:100035092",
            "vendorinfo:100035091",
            "vendorinfo:100035090",
            "vendorinfo:100035089",
            "vendorinfo:100035088",
            "vendorinfo:100035087",
            "vendorinfo:100035086",
            "vendorinfo:100035085",
            "vendorinfo:100035084",
            "vendorinfo:100035083",
            "vendorinfo:100035082",
            "vendorinfo:100035081",
            "vendorinfo:100035080",
            "vendorinfo:100035079",
            "vendorinfo:100035078",
            "vendorinfo:100035077",
            "vendorinfo:100035076",
            "vendorinfo:100035075",
            "vendorinfo:100035074",
            "vendorinfo:100035073",
            "vendorinfo:100035072",
            "vendorinfo:100035071",
            "vendorinfo:100035070"
            };

            List<HashEntry[]> listEntry = new List<HashEntry[]>();

            foreach (RedisKey key in keyList)
            {
                listEntry.Add(db.HashGetAll(key));
            }

            return listEntry;

        }

        public static Dealer ReadDataOnly_Field_ToModel()
        {
            IDatabase db = redis.GetDatabase(2);

            HashEntry[] entrs = db.HashGetAll("vendorinfo:100035099");
            Dealer dealer = new Dealer();
            if (entrs != null && entrs.Length > 0)
            {
                dealer.VendorID = (Int32)GetHashKey(entrs, "VendorID");

                dealer.VendorBizMode = (Int32)GetHashKey(entrs, "VendorBizMode");
                dealer.CityID = (Int32)GetHashKey(entrs, "CityID");
                dealer.ProvinceID = (Int32)GetHashKey(entrs, "ProvinceID");
                dealer.LocationID = (Int32)GetHashKey(entrs, "LocationID");

                dealer.VendorStatus = (Int32)GetHashKey(entrs, "VendorStatus");
                dealer.SaleRegionType = (Int32)GetHashKey(entrs, "SaleRegionType");


                dealer.VendorName = GetHashKey(entrs, "VendorName");
                dealer.CityName = GetHashKey(entrs, "CityName");

                dealer.ProvinceName = GetHashKey(entrs, "ProvinceName");
                dealer.LocationName = GetHashKey(entrs, "LocationName");
                dealer.VendorTel = GetHashKey(entrs, "VendorTel");

                dealer.VendorFullName = GetHashKey(entrs, "VendorFullName");
                dealer.VendorSaleAddr = GetHashKey(entrs, "VendorSaleAddr");
                dealer.MainBrand = GetHashKey(entrs, "MainBrand");
                dealer.GoogleMapLat = GetHashKey(entrs, "GoogleMapLat");
                dealer.GoogleMapLng = GetHashKey(entrs, "GoogleMapLng");

            }
            return dealer;
        }

        private static RedisValue GetHashKey(HashEntry[] entrys, String key)
        {
            foreach (HashEntry entry in entrys)
            {
                if (entry.Name == key)
                {
                    return entry.Value;
                }
            }
            return RedisValue.EmptyString;
        }

    }
}
