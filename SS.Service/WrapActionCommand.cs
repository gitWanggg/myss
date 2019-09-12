using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase.Command;
namespace SS.Service
{
    public abstract class WrapActionCommand : CommandBase<WrapAppSession, InstanceRequestInfo>
    {


        public override void ExecuteCommand(WrapAppSession session, InstanceRequestInfo requestInfo)
        {
            HanderContext context = new HanderContext();
            context.RequestInfo = requestInfo;
            context.Respose = new ResponseInfo();
            context.WrapSession = session;
            context.ActionHandler = HandAction;
            StreamChainHandler chainH = ChainFactory.Create(this.Name);
            chainH.HandStream(context);
        }

        protected abstract byte[] HandAction(HanderContext context);
    }
}
