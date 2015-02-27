using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsTest.FrontEnd.StackExchange;

namespace ToolsTest.CodeTimerTest
{
    public class Redis_Init
    {

        public static void InitDealerListTest_Model()
        {

            // 预热
            CodeTimer.Initialize();

            Int32 interation = 1;

            //  比赛
            CodeTimer.Time("初始化数据Model", interation, RedisClient.InsertVendorInfo_Model);

        }

        public static void InitDealerListTest_Field()
        {

            // 预热
            CodeTimer.Initialize();

            Int32 interation = 1;

            //  比赛
            CodeTimer.Time("初始化数据Field", interation, RedisClient.InsertVendorInfo_Field);

        }

        public static void InitDealerListTest()
        {

            // 预热
            CodeTimer.Initialize();

            Int32 interation = 1;

            //  比赛
            CodeTimer.Time("初始化数据Model", interation, RedisClient.InsertVendorInfo_Model);
            CodeTimer.Time("初始化数据Field", interation, RedisClient.InsertVendorInfo_Field);

        }

        public static void GetDealerDataTest()
        {

            // 预热
            CodeTimer.Initialize();

            Int32 interation = 10000;

            //  比赛
            CodeTimer.Time("只读取数据Model", interation, RedisClient.ReadDataOnly_Model);
            CodeTimer.Time("只读取数据Field", interation, () => { RedisClient.ReadDataOnly_Field(); });
            CodeTimer.Time("读取数据Model并序列化", interation, () => { RedisClient.ReadDataOnly_Model_Deserialize(); });
            CodeTimer.Time("读取数据Field并转为Model", interation, () => { RedisClient.ReadDataOnly_Field_ToModel(); });

            CodeTimer.Time("读取列表Model 30 包括序列化", interation, () => { RedisClient.ReadDataOnly_Model_Deserialize_List(); });
            CodeTimer.Time("读取列表Field 30", interation, () => { RedisClient.ReadDataOnly_Field_List(); });

        }


    }
}
