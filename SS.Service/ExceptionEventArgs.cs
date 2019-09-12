using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Service
{
    public class ExceptionEventArgs:ServiceRunEventArgs
    {
        public Exception Ex { get; set; }
    }
}
