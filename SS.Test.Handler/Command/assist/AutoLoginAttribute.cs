using SuperSocket.SocketBase.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Test.Handler.Command.assist
{
    class AutoLoginAttribute : CommandFilterAttribute
    {
        assist.Login login;

        public AutoLoginAttribute(){
            login = new Login();
        }
        public override void OnCommandExecuted(SuperSocket.SocketBase.CommandExecutingContext commandContext)
        {
            
        }

        public override void OnCommandExecuting(SuperSocket.SocketBase.CommandExecutingContext commandContext)
        {
            if (commandContext.Session != null && commandContext.Session is SS.Service.WrapAppSession) {
                SS.Service.WrapAppSession wrapSession = commandContext.Session as SS.Service.WrapAppSession;
                if (string.IsNullOrEmpty(wrapSession.UserID)) {
                    SS.Service.InstanceRequestInfo reqInfo = commandContext.RequestInfo as SS.Service.InstanceRequestInfo;
                    string uid = login.FindUserID(reqInfo.ID);
                    if (string.IsNullOrEmpty(uid))
                        uid = login.Reg(reqInfo.ID);
                    UniqueServer uServer = commandContext.Session.AppServer as UniqueServer;
                    ////uServer.UniqueGy.Remove(uid);
                    //string sessidSource = uServer.UniqueGy.FindSession(uid);
                    //if (!string.IsNullOrEmpty(sessidSource)&&sessidSource!=wrapSession.SessionID) {
                    //    uServer.GetSessionByID(sessidSource);
                    //}
                    wrapSession.UserID = uid;
                    uServer.UniqueGy.Add(uid, wrapSession);
                }
            }
            else
                commandContext.Cancel = true;
        }
    }
}
