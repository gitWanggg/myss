using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Service
{
    public class ChainBuilder
    {
        List<StreamChainHandler> listChain;

        public ChainBuilder()
        {
            listChain = new List<StreamChainHandler>();
        }
        public ChainBuilder Append(StreamChainHandler ChHandler)
        {
            listChain.Add(ChHandler);
            return this;
        }

        public StreamChainHandler Builder()
        {
            if (listChain.Count < 1)
                return null;
            if (listChain.Count == 1)
                return listChain[0];            
            int nLen = listChain.Count;
            for (int i = 0; i < nLen-1; i++) {
                listChain[i].NextChain = listChain[i + 1];
            }
            return listChain[0];
        }
    }
}
