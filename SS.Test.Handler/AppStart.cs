﻿using SS.Service;
using SS.Test.Handler.Chain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Test.Handler
{
    public class AppStart
    {

        public static void Start()
        {
            //创建路由
            Encoding Encoder = System.Text.Encoding.UTF8;
            IEscapeable IEsc = new Escape.UrlEscape();
            ChainBuilder builder = new ChainBuilder();
            builder.Append(new BeginEndHandler()).Append(new SortEndHandler());
            builder.Append(new InstanceHandler(Encoder));
            builder.Append(new RouteHandler(Encoder));
            builder.Append(new BodyChainHandler(IEsc));
            
            //注册路由
            Startup.RegBuilder(Command.CommandRoutes.Add, builder);

            //启动服务
            Startup.Start(OnFail, OnSuccess);
        }

        private static void OnFail(object sender, ExceptionEventArgs e)
        {
            Console.WriteLine("启动失败:" + e.Ex.Message);
        }

        private static void OnSuccess(object sender, ServiceRunEventArgs e)
        {
            //foreach (WrapAppServer server in e.AppServers) {
            //    server.AddRunLog("MEI201909120001");
            //}
            Console.WriteLine("启动成功");
        }
    }
}
