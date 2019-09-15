using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using SuperSocket.SocketBase;
namespace SS.Service
{
    public abstract class WrapReceiveFilterFactory : IReceiveFilterFactory<InstanceRequestInfo>,ISettingLogger
    {
       
        public WrapReceiveFilterFactory()
        {

        }
        public abstract IReceiveFilter<InstanceRequestInfo> CreateFilter(IAppServer appServer, IAppSession appSession, IPEndPoint remoteEndPoint);



        public abstract void SettingLogger(ILoggerReceiveable IRLogger);
       
    }
}
