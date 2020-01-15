using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Service
{
    public class WrapAppSession:AppSession<WrapAppSession,InstanceRequestInfo>
    {
        public static int MAXFLOWNO = 65535;

        int mFlowNO = 0;
        /// <summary>
        /// 连接的系统分配的用户ID
        /// </summary>
        public string UserID { get; set; }       
        //public  virtual object this[int index] { get; set; }        
        //public  virtual object this[string name] { get; set; }

        //object ReadKey(int index)
        //{

        //}
        //object ReadKey(string name)
        //{

        //}
        public override void Send(ArraySegment<byte> segment)
        {
            base.Send(segment);
        }
        public override void Send(byte[] data, int offset, int length)
        {
            string outString = "";
            for (int i = 0; i < length;i++ )                
                    outString += data[offset+i].ToString("X2");
            this.Logger.Debug("回复:" + outString);
            base.Send(data, offset, length);
        }
        public int LoggerLevel { get; set; }
        /// <summary>
        /// 消息流水号
        /// </summary>
        public int MsgNO { get { return mFlowNO; } }

        public int AddFlow()
        {
            if (MsgNO < MAXFLOWNO)
                mFlowNO += 1;
            else
                mFlowNO = 0;
            return mFlowNO;
        }
    }
}
