using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Service;
namespace SS.Test.Handler.Chain
{
    class RouteHandler : StreamChainHandler
    {
        
        public Encoding Encoder { get; set; }
        public RouteHandler(Encoding Encoder)
        {
           
            this.Encoder = Encoder;
        }
        protected override bool HandBegin(HanderContext HContext)
        {

            byte[] buffer = Encoder.GetBytes(HContext.RequestInfo.Key);
            HContext.Respose.OutputStream.Write(buffer, 0, buffer.Length);
            HContext.Respose.OutputStream.WriteByte(RConstant.Semicolon);
            return true;
        }

        protected override void HandEnd(HanderContext HContext)
        {
            
        }
       
    }
}
