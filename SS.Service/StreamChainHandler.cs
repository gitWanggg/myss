using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Service
{
    public abstract class StreamChainHandler
    {
        protected int ChainStatus;
        public StreamChainHandler NextChain { get; set; }
        public void HandStream(HanderContext HContext)
        {
            bool isFinish = HandBegin(HContext);
            if (ChainStatus == (int)EnumChainStatus.Broadcast && NextChain != null)
                NextChain.HandStream(HContext);
            if(!isFinish && ChainStatus!=(int)EnumChainStatus.Broken) //未处理完毕且链不终端
                HandEnd(HContext);
        }

        protected abstract bool HandBegin(HanderContext HContext);

        protected abstract void HandEnd(HanderContext HContext);
    }
}
