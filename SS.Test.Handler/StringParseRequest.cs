using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Service;
namespace SS.Test.Handler
{
    class StringParseRequest:IParseRequestable
    {
        
           //[4比特]
        //##序号,实例ID,Route,body%%
        public InstanceRequestInfo Parse(byte[] readBuffer, int offset, int length)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < length; i++) {
                if (readBuffer[offset + i] == RConstant.Semicolon) {
                    list.Add(i);
                    if (list.Count == 3)
                        break;
                }
            }
            if (list.Count < 3)
                throw new FormatException("输入信息格式不正确");
            string key = System.Text.Encoding.UTF8.GetString(readBuffer,list[1]+1,list[2]-list[1]-1);
            int nIndexBody=list[2]+1;
            byte[] inputString = readBuffer.Skip(nIndexBody).Take(length - nIndexBody).ToArray();
            InstanceRequestInfo iR = new InstanceRequestInfo(key, inputString);
            iR.ID = System.Text.Encoding.UTF8.GetString(readBuffer, list[0] + 1, list[1] - list[0] - 1);
            iR.SeqNO = list[0] == 0 ? 0 : BitConverter.ToInt32(readBuffer, 0);
            return iR;
        }
    }
}
