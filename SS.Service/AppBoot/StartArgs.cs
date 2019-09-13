using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Service
{
    class StartArgs
    {
        public EventHandler<ExceptionEventArgs> OnFail { get; set; }

        public EventHandler<ServiceRunEventArgs> OnSuccess { get; set; }



    }
}
