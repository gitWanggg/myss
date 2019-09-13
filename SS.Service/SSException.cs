using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Service
{
    public class SSException:Exception
    {
         // 摘要: 
        //     初始化 System.Exception 类的新实例。
        public SSException()
        {

        }
        //
        // 摘要: 
        //     使用指定的错误信息初始化 System.Exception 类的新实例。
        //
        // 参数: 
        //   message:
        //     描述错误的消息。
        public SSException(string message)
            :base(message)
        {

        }
        
    }
}
