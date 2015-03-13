using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace ToolsTest.FrontEnd.StackExchange
{
    [ProtoContract]
    public class Dealer
    {
        [ProtoMember(1)]
        public Int32 VendorID { get; set; }

        [ProtoMember(2)]
        public String VendorName { get; set; }

        [ProtoMember(3)]
        public String VendorFullName { get; set; }

        [ProtoMember(4)]
        public Int32 VendorBizMode { get; set; }

        [ProtoMember(5)]
        public Int32 VendorStatus { get; set; }

        [ProtoMember(6)]
        public Int32 LocationID { get; set; }

        [ProtoMember(7)]
        public String LocationName { get; set; }

        [ProtoMember(8)]
        public Int32 CityID { get; set; }

        [ProtoMember(9)]
        public String CityName { get; set; }

        [ProtoMember(10)]
        public Int32 ProvinceID { get; set; }

        [ProtoMember(11)]
        public String ProvinceName { get; set; }

        [ProtoMember(12)]
        public String VendorSaleAddr { get; set; }

        [ProtoMember(13)]
        public Int32 SaleRegionType { get; set; }

        [ProtoMember(14)]
        public String VendorTel { get; set; }

        [ProtoMember(15)]
        public String MainBrand { get; set; }

        [ProtoMember(16)]
        public String GoogleMapLat { get; set; }

        [ProtoMember(17)]
        public String GoogleMapLng { get; set; }

    }

    [ProtoContract]
    public class VendorPrice
    {
        [ProtoMember(1)]
        public Int32 PriceId { get; set; }

        [ProtoMember(2)]
        public Int32 DealerId { get; set; }

        [ProtoMember(3)]
        public Int32 CarId { get; set; }

        [ProtoMember(4)]
        public Decimal SalePrice { get; set; }

        [ProtoMember(5)]
        public Decimal SubscribePrice { get; set; }

        [ProtoMember(6)]
        public Int32 DeliveryWaitdays { get; set; }

        [ProtoMember(7)]
        public Int32 Ready { get; set; }

        [ProtoMember(9)]
        public String Favourable { get; set; }

        [ProtoMember(10)]
        public Decimal SmsPrice { get; set; }

        [ProtoMember(11)]
        public Int32 NewsId { get; set; }

        [ProtoMember(12)]
        public Decimal FavorablePrice { get; set; }

        [ProtoMember(13)]
        public Decimal CarReferPrice { get; set; }

        [ProtoMember(14)]
        public Decimal PresentPrice { get; set; }

        [ProtoMember(15)]
        public DateTime NewsPubTime { get; set; }

        [ProtoMember(16)]
        public DateTime EndDateTime { get; set; }

        [ProtoMember(17)]
        public Int32 StoreState { get; set; }

    }
}
