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
            return IParse.Parse(readBuffer, offset, length);
        }
    }
}
