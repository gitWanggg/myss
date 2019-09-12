using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogNet
{
    class Program
    {
       
        static void Main(string[] args)
        {
            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "configs/log4net.config");
            var fi = new System.IO.FileInfo(path);

            log4net.Config.XmlConfigurator.Configure(fi);
            log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            LogHelper.WriteLog("holle world");

            Console.WriteLine("打印成功");
            Console.ReadLine();
        }
    }
}
