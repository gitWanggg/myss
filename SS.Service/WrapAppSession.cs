using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Service
{
    public class WrapAppSession:AppSession<WrapAppSession,InstanceRequestInfo>
    {
        /// <summary>
        /// 连接的系统分配的用户ID
        /// </summary>
        public string UserID { get; set; }       
        //public  virtual object this[int index] { get; set; }        
        //public  virtual object this[string name] { get; set; }

        //object ReadKey(int index)
        //{

        //}
        //object ReadKey(string name)
        //{

        //}
        public int LoggerLevel { get; set; }

    }
}
