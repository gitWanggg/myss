using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Service;
namespace SS.Test.Handler.Escape
{
    class UrlEscape:IEscapeable
    {
        public string ParseString(string InputString)
        {
           return  System.Web.HttpUtility.UrlEncode(InputString);
        }

        public byte[] ParseByte(byte[] InputByte)
        {
            return System.Web.HttpUtility.UrlEncodeToBytes(InputByte);
        }
    }
}
