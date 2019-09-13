using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Service
{
    public class HanderContext
    {
        public InstanceRequestInfo RequestInfo { get; set; }

        public ResponseInfo Respose { get; set; }

        public WrapAppSession WrapSession { get; set; }

        public Func<HanderContext,byte[]> ActionHandler { get; set; }
    }
}
