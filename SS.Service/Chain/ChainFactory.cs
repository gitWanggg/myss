using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Service
{
    class ChainFactory
    {
        static Dictionary<string, StreamChainHandler> DicHandler;
        static object objLock;
        public static StreamChainHandler Create(string RouteKey)
        {
            if (DicHandler.ContainsKey(RouteKey))
                return DicHandler[RouteKey];
            lock (objLock) {
                if (DicHandler.ContainsKey(RouteKey))
                    return DicHandler[RouteKey];
                ChainBuilder builder = RouteConfig.FindBuilder(RouteKey);
                if (builder == null)
                    throw new KeyNotFoundException("无法识别的路由信息");
                StreamChainHandler sChain = builder.Builder();
                DicHandler.Add(RouteKey, sChain);
                return sChain;
            }
        }
        static ChainFactory()
        {
            objLock = new object();
            DicHandler = new Dictionary<string, StreamChainHandler>();
        }
    }
}
