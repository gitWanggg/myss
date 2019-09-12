using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Service
{
    public class BodyChainHandler : StreamChainHandler
    {


        public IEscapeable Escaper { get; set; }

        public BodyChainHandler(IEscapeable Escaper)
        {
            this.Escaper = Escaper;
        }
        protected override bool HandBegin(HanderContext HContext)
        {
           // byte[] bufferSource = Escaper == null ? HContext.Respose.BodyBuffer : Escaper.ParseByte(HContext.Respose.BodyBuffer);
            byte[] buffSource = HContext.ActionHandler == null ? null : HContext.ActionHandler(HContext);

            if (buffSource != null && buffSource.Length > 0) {
                if (Escaper != null)
                    buffSource = Escaper.ParseByte(buffSource);
                HContext.Respose.OutputStream.Write(buffSource, 0, buffSource.Length);
            }
            return true;
        }

        protected override void HandEnd(HanderContext HContext)
        {
            throw new NotImplementedException();
        }
    }
}
