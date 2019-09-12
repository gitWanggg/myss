using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Service
{
    public interface IEscapeable
    {
        string ParseString(string InputString);

        byte[] ParseByte(byte[] InputByte);

        string DecodeString(string InputString);

        byte[] DecodeByte(byte[] InputByte);
    }
}
