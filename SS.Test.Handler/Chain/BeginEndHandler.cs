using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Service;
namespace SS.Test.Handler.Chain
{
    class BeginEndHandler:StreamChainHandler
    {


        protected override bool HandBegin(HanderContext HContext)
        {
            HContext.Respose.OutputStream.Write(RConstant.BeginMarkByte, 0, 2);
            return false;
        }

        protected override void HandEnd(HanderContext HContext)
        {
            HContext.Respose.OutputStream.Write(RConstant.EndMarkByte, 0, 2);
        }
    }
}
