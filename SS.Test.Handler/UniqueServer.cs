using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Service;
using SuperSocket.SocketBase.Config;
using SS.Test.Handler.Strategy;
using SuperSocket.SocketBase;
namespace SS.Test.Handler
{
    public class UniqueServer:WrapAppServer
    {
        public UniqueStrategy UniqueGy { get; set; }

        public UniqueServer()
        {
            UniqueGy = new UniqueStrategy();
        }
        //protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        //{
        //    UniqueGy = new UniqueStrategy();
        //    string isUnique = config.Options[RConstant.UserUniqueKey];
        //    if (!string.IsNullOrEmpty(isUnique) && isUnique == "1") {
        //        UniqueGy.UserUnique = 1;
        //    }            
        //    return base.Setup(rootConfig, config);
        //}
        protected override void OnSessionClosed(WrapAppSession session, CloseReason reason)
        {
            UniqueGy.Remove(session.UserID,session.SessionID);
            base.OnSessionClosed(session, reason);
        }
    }
}
