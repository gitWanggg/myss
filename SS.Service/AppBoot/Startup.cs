using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Service
{
    public class Startup
    {
        static IBootstrap bootstrap;

        /// <summary>
        /// 注册路由
        /// </summary>
        /// <param name="RouteKey"></param>
        /// <param name="Builder"></param>
        public static void RegBuilder(string RouteKey,ChainBuilder Builder)
        {
            RouteConfig.Reg(RouteKey, Builder);
        }
        public static void RegBuilder(Dictionary<string, ChainBuilder> BuilderMapping)
        {
            foreach (string key in BuilderMapping.Keys)
                RouteConfig.Reg(key, BuilderMapping[key]);
        }
        public static void Start(EventHandler<ExceptionEventArgs> OnFail,EventHandler<ServiceRunEventArgs> OnSuccess)
        {
            StartArgs sArgs = new StartArgs();
            sArgs.OnFail = OnFail;
            sArgs.OnSuccess = OnSuccess;
            System.Threading.Thread thStart = new System.Threading.Thread(Init);
            thStart.IsBackground = true;
            thStart.Start(sArgs);
        }

        private static void Init(object obj)
        {
            StartArgs sArgs = null;
            if (obj != null)
                sArgs = obj as StartArgs;
            DateTime dtNow=DateTime.Now;
            try {                
                InitCore();
                if (sArgs != null && sArgs.OnSuccess != null) {
                    List<WrapAppServer> listServer = new List<WrapAppServer>();
                    foreach (IWorkItem workItem in bootstrap.AppServers) {
                        WrapAppServer appserver = workItem as WrapAppServer;
                        if (appserver.ReceiveFilterFactory is ISettingLogger) {
                            ISettingLogger beR = appserver.ReceiveFilterFactory as ISettingLogger;
                            beR.SettingLogger(appserver);
                        }
                        listServer.Add(appserver);
                    }
                    sArgs.OnSuccess(bootstrap, new ServiceRunEventArgs() { StartTime = dtNow, AppServers = listServer });
                }
            }
            catch (Exception ex) {
                if (sArgs != null && sArgs.OnFail != null) {
                    sArgs.OnFail(bootstrap, new ExceptionEventArgs() { Ex = ex, StartTime = dtNow });
                }
            }
        }
        static void InitCore()
        {
            bootstrap = BootstrapFactory.CreateBootstrap();

            if (!bootstrap.Initialize()) {
                throw new SSException("Failed to initialize!");               
            }
            var result = bootstrap.Start();         
            if (result == StartResult.Failed) {
                throw new SSException("Failed to start!");              
            }           
        }

        public static void Stop()
        {
            if (bootstrap != null) {
                bootstrap.Stop();
                
            }
        }
    }
}
