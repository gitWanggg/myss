using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using SS.Service;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.SocketBase;
namespace SS.Test.Handler
{
    public class InstanceStringFilterFactory:WrapReceiveFilterFactory
    {

        BeginEndReceiveFilter IRFilter;

        IParseRequestable IParse;
        public InstanceStringFilterFactory()
        {
            init();
        }

        void init()
        {            
            IParse = new StringParseRequest();
            BeginEndReceiveFilter begFilter = new BeginEndReceiveFilter(RConstant.BeginMarkByte, RConstant.EndMarkByte);
            begFilter.IParse = IParse;
            IRFilter = begFilter;
            //Console.WriteLine("FilterFactory Init");
        }
        public override IReceiveFilter<InstanceRequestInfo> CreateFilter(IAppServer appServer, IAppSession appSession, IPEndPoint remoteEndPoint)
        {
            return IRFilter;
        }

        public override void SettingLogger(ILoggerReceiveable IRLogger)
        {
            if (IRFilter != null)
                IRFilter.ILoggerR = IRLogger;
        }
    }
}
