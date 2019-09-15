using SuperSocket.Facility.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Service
{
    public class BeginEndReceiveFilter : BeginEndMarkReceiveFilter<InstanceRequestInfo>
    {
        public IParseRequestable IParse { get; set; }
        public Encoding EncodeType { get; set; }

        public ILoggerReceiveable ILoggerR { get; set; }
        public BeginEndReceiveFilter(string BeginMark,string EndMark)
            :this(BeginMark,EndMark,Encoding.UTF8)
        {

        }
        public BeginEndReceiveFilter(byte[] beginMark, byte[] endMark)
            : base(beginMark, endMark)
        {
            EncodeType = System.Text.Encoding.UTF8;
        }
        public BeginEndReceiveFilter(string BeginMark, string EndMark,Encoding EncodeType)
            : this(EncodeType.GetBytes(BeginMark),EncodeType.GetBytes(EndMark))
        {
            this.EncodeType = EncodeType;
        }
        protected override InstanceRequestInfo ProcessMatchedRequest(byte[] readBuffer, int offset, int length)
        {
            InstanceRequestInfo IR = IParse.Parse(readBuffer, offset, length);
            if (ILoggerR != null && ILoggerR.IsDebugger(IR.ID)) {
                string outString = "";
                for (int i = offset; i < length; i++) {
                    outString += readBuffer[i].ToString("X2");
                }
                ILoggerR.Logger.Debug(outString);
            }
            return IR;
        }
        
    }
}
