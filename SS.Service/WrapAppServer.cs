using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Service
{
    public class WrapAppServer : AppServer<WrapAppSession, InstanceRequestInfo>, ILoggerReceiveable
    {
       

        Dictionary<string, bool> dicLogger;

        public WrapAppServer()
        {
            dicLogger = new Dictionary<string, bool>();
        }
        public void AddRunLog(string InstanceID)
        {
            dicLogger[InstanceID] = true;
        }
        public void RemoveRunLog(string InstanceID)
        {
            dicLogger.Remove(InstanceID);
        }
        public bool IsDebugger(string InstancID)
        {
            
            if (dicLogger.ContainsKey(InstancID))
                return true;
            else
                return false;
        }
    }
}
