using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Service;
namespace SS.Test.Handler.Chain
{
    class SortEndHandler:StreamChainHandler
    {
        public int SortNO { get; set; }


        protected override bool HandBegin(HanderContext HContext)
        {
            HContext.Respose.OutputStream.Write(BitConverter.GetBytes(SortNO), 0, 4);
            HContext.Respose.OutputStream.WriteByte(RConstant.Semicolon);
            SortNO += 1;
            return true;
        }

        protected override void HandEnd(HanderContext HContext)
        {
           
        }
    }
}
