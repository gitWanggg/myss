using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Service
{
    public interface ISettingLogger
    {
        void SettingLogger(ILoggerReceiveable IRLogger);
    }
}
