using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Service
{
    public class InstanceRequestInfo : BinaryRequestInfo
    {
        public InstanceRequestInfo(string key, byte[] body)
            :base(key,body)
        {

        }
        /// <summary>
        /// 实例唯一标识
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 消息序列号
        /// </summary>
        public int SeqNO { get; set; }
       
    }
}
