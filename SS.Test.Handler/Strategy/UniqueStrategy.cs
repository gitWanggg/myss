using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Service;
namespace SS.Test.Handler.Strategy
{
    public class UniqueStrategy:IServiceStrategy
    {
       

        Dictionary<string,string> dicKeys;

        object objLock;

        public UniqueStrategy()
        {
            objLock=new object();
            dicKeys=new Dictionary<string,string>();
        }

        public string FindSession(string UserID)
        {
            return dicKeys[UserID];
        }
        public void Remove(string UserID)
        {

            if (string.IsNullOrEmpty(UserID))
                return;

            if (dicKeys.ContainsKey(UserID)) {
                dicKeys.Remove(UserID);
            }
        }

        public void Add(string UserID, WrapAppSession appSession)
        {
            if (string.IsNullOrEmpty(UserID))
                return;
            lock (objLock) {
                if (dicKeys.ContainsKey(UserID)) {
                    string sessionid = FindSession(UserID);
                    if (!string.IsNullOrEmpty(sessionid)) {
                        WrapAppSession sessSource = appSession.AppServer.GetSessionByID(sessionid);
                        if(sessSource!=null)
                            sessSource.Close();                        
                    }
                }
                dicKeys.Add(UserID, appSession.SessionID);
            }
            
        }
    }
}
