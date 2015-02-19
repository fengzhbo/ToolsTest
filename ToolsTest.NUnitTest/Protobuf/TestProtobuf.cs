using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ToolsTest.FrontEnd.ProtobufTest;

namespace ToolsTest.NUnitTest.Protobuf
{
    [TestFixture]
    public class TestProtobuf
    {
        /// <summary>
        /// 测试序列化嵌套1层的Model和list
        /// </summary>
        [TestCase]
        public void TestModleAndList()
        {
            //Arrange
            ResponseResult<DealerInfo> userInfo = new ResponseResult<DealerInfo>()
            {
                ResponseStatus = ResultCode.OK,
                Data = new DealerInfo()
                {
                    UserId = 50002218,
                    UserName = "这是一个经销商"
                }
            };


            ResponseResult<List<DealerInfo>> userInfoList = new ResponseResult<List<DealerInfo>>()
            {
                ResponseStatus = ResultCode.OK,
                Data = new List<DealerInfo>()
                {
                    new DealerInfo() {UserId = 50002218, UserName = "这是一个经销商"},
                    new DealerInfo() {UserId = 100008700, UserName = "这是另一个经销商"}
                }
            };

            using (FileStream fs = File.OpenWrite(@"C:\Users\fengzhbo\Documents\visual studio 2013\Projects\ToolsTest\ToolsTest.NUnitTest\AutoFac\userinfo.txt"))
            {
                ProtoBuf.Serializer.Serialize(fs, userInfo);
            }

            using (FileStream fs = File.OpenWrite(@"C:\Users\fengzhbo\Documents\visual studio 2013\Projects\ToolsTest\ToolsTest.NUnitTest\AutoFac\userinfolist.txt"))
            {
                ProtoBuf.Serializer.Serialize(fs, userInfoList);
            }



            ResponseResult<DealerInfo> deUserInfo = null;
            using (FileStream fs = File.OpenRead(@"C:\Users\fengzhbo\Documents\visual studio 2013\Projects\ToolsTest\ToolsTest.NUnitTest\AutoFac\userinfo.txt"))
            {
                deUserInfo = ProtoBuf.Serializer.Deserialize<ResponseResult<DealerInfo>>(fs);
            }

            ResponseResult<List<DealerInfo>> deUserInfoList = null;
            using (FileStream fs = File.OpenRead(@"C:\Users\fengzhbo\Documents\visual studio 2013\Projects\ToolsTest\ToolsTest.NUnitTest\AutoFac\userinfolist.txt"))
            {
                deUserInfoList = ProtoBuf.Serializer.Deserialize<ResponseResult<List<DealerInfo>>>(fs);
            }


            Assert.IsNotNull(deUserInfo);
            Assert.AreEqual(deUserInfo.ResponseStatus, ResultCode.OK);
            Assert.IsNotNull(deUserInfo.Data);
            Assert.AreEqual(deUserInfo.Data.UserId, 50002218);


            Assert.IsNotNull(deUserInfoList);
            Assert.AreEqual(deUserInfoList.ResponseStatus, ResultCode.OK);
            Assert.IsNotNull(deUserInfoList.Data);
            Assert.AreEqual(deUserInfoList.Data.Count, 2);
            Assert.AreEqual(deUserInfoList.Data[0].UserId, 50002218);
            Assert.AreEqual(deUserInfoList.Data[1].UserId, 100008700);

        }

        [TestCase]
        public void TestSecondModel()
        {
            //Arrange
            ResponseResult<Admin> adminInfo = new ResponseResult<Admin>()
            {
                ResponseStatus = ResultCode.OK,

                Data = new Admin()
                {
                    AdminId = 1,
                    DealerInfo = new DealerInfo()
                    {
                        UserId = 50002218,
                        UserName = "这是一个经销商"
                    }
                }
            };

            using (FileStream fs = File.OpenWrite(@"C:\Users\fengzhbo\Documents\visual studio 2013\Projects\ToolsTest\ToolsTest.NUnitTest\AutoFac\admininfo.txt"))
            {
                ProtoBuf.Serializer.Serialize(fs, adminInfo);
            }

            ResponseResult<Admin> deAdminInfo = null;
            using (FileStream fs = File.OpenRead(@"C:\Users\fengzhbo\Documents\visual studio 2013\Projects\ToolsTest\ToolsTest.NUnitTest\AutoFac\admininfo.txt"))
            {
                deAdminInfo = ProtoBuf.Serializer.Deserialize<ResponseResult<Admin>>(fs);
            }


            Assert.IsNotNull(deAdminInfo);
            Assert.AreEqual(deAdminInfo.ResponseStatus, ResultCode.OK);
            Assert.IsNotNull(deAdminInfo.Data);
            Assert.AreEqual(deAdminInfo.Data.AdminId, 1);
            Assert.AreEqual(deAdminInfo.Data.DealerInfo.UserId, 50002218);
        }

        [TestCase]
        public void TestSecondList()
        {
            //Arrange
            ResponseResult<List<Admin>> adminList = new ResponseResult<List<Admin>>()
            {
                ResponseStatus = ResultCode.OK,

                Data = new List<Admin>(){
                
                new Admin()
                {
                    AdminId = 1,
                    DealerInfo = new DealerInfo()
                    {
                        UserId = 50002218,
                        UserName = "这是一个经销商"
                    }
                },
                 new Admin()
                {
                    AdminId = 2,
                    DealerInfo = new DealerInfo()
                    {
                        UserId = 100008700,
                        UserName = "这是另一个经销商"
                    }
                },
                }
            };

            using (FileStream fs = File.OpenWrite(@"C:\Users\fengzhbo\Documents\visual studio 2013\Projects\ToolsTest\ToolsTest.NUnitTest\AutoFac\adminlist.txt"))
            {
                ProtoBuf.Serializer.Serialize(fs, adminList);
            }

            ResponseResult<List<Admin>> deAdminlist = null;
            using (FileStream fs = File.OpenRead(@"C:\Users\fengzhbo\Documents\visual studio 2013\Projects\ToolsTest\ToolsTest.NUnitTest\AutoFac\adminlist.txt"))
            {
                deAdminlist = ProtoBuf.Serializer.Deserialize<ResponseResult<List<Admin>>>(fs);
            }


            Assert.IsNotNull(deAdminlist);
            Assert.AreEqual(deAdminlist.ResponseStatus, ResultCode.OK);
            Assert.IsNotNull(deAdminlist.Data);
            Assert.AreEqual(deAdminlist.Data.Count, 2);
            Assert.AreEqual(deAdminlist.Data[0].AdminId, 1);
            Assert.AreEqual(deAdminlist.Data[0].DealerInfo.UserId, 50002218);
            Assert.AreEqual(deAdminlist.Data[1].AdminId, 2);
            Assert.AreEqual(deAdminlist.Data[1].DealerInfo.UserId, 100008700);
        }

        [TestCase]
        public void TestThirdModel()
        {
            //Arrange
            ResponseResult<User> adminInfo = new ResponseResult<User>()
            {
                ResponseStatus = ResultCode.OK,

                Data = new User()
                {
                    UserId = 1,
                    AdminInfo = new Admin()
                    {
                        AdminId = 1,
                        DealerInfo = new DealerInfo()
                        {
                            UserId = 50002218,
                            UserName = "这是一个经销商"
                        }
                    }
                }
            };

            using (FileStream fs = File.OpenWrite(@"C:\Users\fengzhbo\Documents\visual studio 2013\Projects\ToolsTest\ToolsTest.NUnitTest\AutoFac\thirduserinfo.txt"))
            {
                ProtoBuf.Serializer.Serialize(fs, adminInfo);
            }

            ResponseResult<User> deAdminInfo = null;
            using (FileStream fs = File.OpenRead(@"C:\Users\fengzhbo\Documents\visual studio 2013\Projects\ToolsTest\ToolsTest.NUnitTest\AutoFac\thirduserinfo.txt"))
            {
                deAdminInfo = ProtoBuf.Serializer.Deserialize<ResponseResult<User>>(fs);
            }


            Assert.IsNotNull(deAdminInfo);
            Assert.AreEqual(deAdminInfo.ResponseStatus, ResultCode.OK);
            Assert.IsNotNull(deAdminInfo.Data);
            Assert.AreEqual(deAdminInfo.Data.UserId, 1);
            Assert.AreEqual(deAdminInfo.Data.AdminInfo.AdminId, 1);
            Assert.AreEqual(deAdminInfo.Data.AdminInfo.DealerInfo.UserId, 50002218);
        }

        [TestCase]
        public void TestThirdList()
        {
            //Arrange
            ResponseResult<List<User>> adminList = new ResponseResult<List<User>>()
            {
                ResponseStatus = ResultCode.OK,

                Data = new List<User>(){
                    new User(){
                        UserId = 1
                        ,AdminInfo = 
                   new Admin()
                {
                    AdminId = 1,
                    DealerInfo = new DealerInfo()
                    {
                        UserId = 50002218,
                        UserName = "这是一个经销商"
                    }
                }
                },
                 new User(){
                     UserId = 2,
                     AdminInfo = new Admin()
                {
                    AdminId = 2,
                    DealerInfo = new DealerInfo()
                    {
                        UserId = 100008700,
                        UserName = "这是另一个经销商"
                    }
}
                }
                }
            };

            using (FileStream fs = File.OpenWrite(@"C:\Users\fengzhbo\Documents\visual studio 2013\Projects\ToolsTest\ToolsTest.NUnitTest\AutoFac\thirduserlist.txt"))
            {
                ProtoBuf.Serializer.Serialize(fs, adminList);
            }

            ResponseResult<List<User>> deAdminlist = null;
            using (FileStream fs = File.OpenRead(@"C:\Users\fengzhbo\Documents\visual studio 2013\Projects\ToolsTest\ToolsTest.NUnitTest\AutoFac\thirduserlist.txt"))
            {
                deAdminlist = ProtoBuf.Serializer.Deserialize<ResponseResult<List<User>>>(fs);
            }


            Assert.IsNotNull(deAdminlist);
            Assert.AreEqual(deAdminlist.ResponseStatus, ResultCode.OK);
            Assert.IsNotNull(deAdminlist.Data);
            Assert.AreEqual(deAdminlist.Data.Count, 2);

            Assert.AreEqual(deAdminlist.Data[0].UserId, 1);
            Assert.AreEqual(deAdminlist.Data[0].AdminInfo.AdminId, 1);
            Assert.AreEqual(deAdminlist.Data[0].AdminInfo.DealerInfo.UserId, 50002218);

            Assert.AreEqual(deAdminlist.Data[1].UserId, 2);
            Assert.AreEqual(deAdminlist.Data[1].AdminInfo.AdminId, 2);
            Assert.AreEqual(deAdminlist.Data[1].AdminInfo.DealerInfo.UserId, 100008700);
        }

    }
}
