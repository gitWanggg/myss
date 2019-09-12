using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Service
{
    public class ResponseInfo:IDisposable
    {
        public ResponseInfo()
        {
            OutputStream = new System.IO.MemoryStream();
        }

        public ResponseInfo(byte[] bodyBuffer)
        {
            this.BodyBuffer = bodyBuffer;
            OutputStream = new System.IO.MemoryStream();
        }
        public byte[] BodyBuffer { get; set; }
        public System.IO.Stream OutputStream { get; set; }

        public byte[] ToBytes()
        {
            OutputStream.Seek(0, System.IO.SeekOrigin.Begin);
            int nLen = (int)OutputStream.Length;
            byte[] buffer = new byte[nLen];
            OutputStream.Read(buffer, 0, nLen);
            return buffer;
        }
        public void Dispose()
        {
            if (OutputStream != null)
                OutputStream.Dispose();
        }
    }
}
