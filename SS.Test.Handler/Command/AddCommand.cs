using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Service;
namespace SS.Test.Handler.Command
{
    [assist.AutoLogin]
    public class AddCommand:WrapActionCommand
    {
        public override string Name
        {
            get
            {
                return CommandRoutes.Add;
            }
        }


        protected override byte[] HandAction(HanderContext context)
        {
            //context.WrapSession.Logger.Debug("这是一个消息");

           
            string InputString = System.Text.Encoding.UTF8.GetString(context.RequestInfo.Body);
            AddArgs Args = Newtonsoft.Json.JsonConvert.DeserializeObject<AddArgs>(InputString);
            int j = Args.Arg1 + Args.Arg2;
            AddArgsResult addR = new AddArgsResult();
            addR.R = j;
            addR.Name = "张三##lll%%";
            addR.Url = System.Web.HttpUtility.UrlEncode("http://www.baidu.com/jj?c=203&jj=王&&ww=%001&jj=#####");
            string jsonR =Newtonsoft.Json.JsonConvert.SerializeObject(addR);
            byte[] bR = System.Text.Encoding.UTF8.GetBytes(jsonR);
            return bR;
        }
    }
}
