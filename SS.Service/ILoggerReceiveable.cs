using SuperSocket.SocketBase.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Service
{
    public interface ILoggerReceiveable
    {
        ILog Logger { get; }
        bool IsDebugger(string InstancID);
        
    }
}
