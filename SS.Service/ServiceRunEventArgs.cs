using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Service
{
    public class ServiceRunEventArgs:EventArgs
    {
        public DateTime StartTime { get; set; }

        public IEnumerable<WrapAppServer> AppServers { get; set; }
    }
}
