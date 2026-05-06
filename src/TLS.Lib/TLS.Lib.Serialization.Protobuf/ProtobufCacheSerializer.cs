using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.Core.Caching;

namespace AEC.Lib.Serialization.Protobuf
{
    public class ProtobufCacheSerializer : ProtobufSerializer, ICacheSerializer
    {
        public ProtobufCacheSerializer() : base ()
        {

        }
    }
}
