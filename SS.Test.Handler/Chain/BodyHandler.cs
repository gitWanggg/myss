using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Service;
namespace SS.Test.Handler.Chain
{
    class BodyHandler:StreamChainHandler
    {
       
        public IEscapeable Escaper{get;set;}
       
        public BodyHandler(IEscapeable Escaper)
        {            
            this.Escaper = Escaper;
        }

        protected override bool HandBegin(HanderContext HContext)
        {
            byte[] bufferSource = Escaper == null ? HContext.Respose.BodyBuffer : Escaper.ParseByte(HContext.Respose.BodyBuffer);


            HContext.Respose.OutputStream.Write(bufferSource, 0, bufferSource.Length);

            return true;

        }

        protected override void HandEnd(HanderContext HContext)
        {
          
        }
    }
}
