using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Service
{
    public interface IParseRequestable
    {
        InstanceRequestInfo Parse(byte[] readBuffer, int offset, int length);


    }
}
