using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Service;
using SS.Test.Handler.Chain;

namespace SS.Test.Handler.ResponseWriter
{
    class SessionStringWriter:IResposeWriter
    {

        public WrapAppSession WrapSession { get; set; }

        StreamChainHandler ChainHandler;

        System.Text.Encoding Encoder;

        IEscapeable IEsc;
        public string RouteKey { get; set; }
        public SessionStringWriter(WrapAppSession wrapSession,string RouteKey)
        {
            this.WrapSession = wrapSession;
            Encoder = System.Text.Encoding.UTF8;
            IEsc = new Escape.UrlEscape();
            InitHandler();
        }
        private void InitHandler()
        {
            ChainBuilder builder = new ChainBuilder();
            builder.Append(new BeginEndHandler()).Append(new SortEndHandler());
            builder.Append(new InstanceHandler(Encoder));
            builder.Append(new RouteHandler(Encoder));
            builder.Append(new BodyHandler(IEsc));
            ChainHandler = builder.Builder();
        }

        public void Write(string InputText)
        {
            byte[] buffer = Encoder.GetBytes(InputText);
            Write(buffer);
        }

        public void Write(byte[] Buffer)
        {
            //using (ResponseInfo r = new ResponseInfo(Buffer)) {
            //    ChainHandler.HandStream(r);
            //    byte[] buffer = r.ToBytes();
            //    Write(buffer, 0, buffer.Length);
            //}            
        }

        public void Write(byte[] Buffer, int Offset, int Length)
        {
            WrapSession.Send(Buffer, Offset, Length);
        }
    }
}
