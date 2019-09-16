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

        protected virtual bool IsVoid { get { return false; } }
        public override void ExecuteCommand(WrapAppSession session, InstanceRequestInfo requestInfo)
        {
            HanderContext context = new HanderContext();
            context.RequestInfo = requestInfo;
            context.Respose = new ResponseInfo();
            context.WrapSession = session;
            if (IsVoid) {
                HandAction(context);
            }
            else {
                context.ActionHandler = HandAction;
                StreamChainHandler chainH = ChainFactory.Create(this.Name);
                chainH.HandStream(context);
                byte[] hR = context.Respose.ToBytes();
                session.Send(hR, 0, hR.Length);
            }
        }

        protected abstract byte[] HandAction(HanderContext context);
    }
}
