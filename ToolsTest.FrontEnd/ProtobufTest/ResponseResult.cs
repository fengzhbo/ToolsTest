using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace ToolsTest.FrontEnd.ProtobufTest
{
    [ProtoContract]
    public class ResponseResult<T>
    {
        [ProtoMember(1)]
        public ResultCode ResponseStatus { get; set; }

        [ProtoMember(2)]
        public T Data { get; set; }


    }

    [ProtoContract]
    public enum ResultCode
    {
        OK = 200,
        NotFound = 404,
        ServiceError = 500
    }

    [ProtoContract]
    public class User
    {
        [ProtoMember(1)]
        public Int32 UserId { get; set; }
        [ProtoMember(2)]
        public Admin AdminInfo { get; set; }

    }

    [ProtoContract]
    public class Admin
    {
        [ProtoMember(1)]
        public Int32 AdminId { get; set; }

        [ProtoMember(2)]
        public DealerInfo DealerInfo { get; set; }
    }

    [ProtoContract]
    public class DealerInfo
    {
        [ProtoMember(1)]
        public Int32 UserId { get; set; }

        [ProtoMember(2)]
        public String UserName { get; set; }
    }
}
