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
            if (dicKeys.ContainsKey(UserID))
                return dicKeys[UserID];
            else
                return null;
        }
        public void Remove(string UserID,string sessionid)
        {

            if (string.IsNullOrEmpty(UserID))
                return;
            if (dicKeys.ContainsKey(UserID)&&dicKeys[UserID]==sessionid) {
                dicKeys.Remove(UserID);
            }
        }

        public void Add(string UserID, WrapAppSession appSession)
        {
            if (string.IsNullOrEmpty(UserID))
                return;
            lock (objLock) {
                string sessionid = FindSession(UserID);
                if (!string.IsNullOrEmpty(sessionid)) {
                    WrapAppSession sessSource = appSession.AppServer.GetSessionByID(sessionid);
                    if (sessSource != null)
                        sessSource.Close();
                }
                if(dicKeys.ContainsKey(UserID))
                    dicKeys[UserID] =appSession.SessionID;
                else
                    dicKeys.Add(UserID, appSession.SessionID);
            }
            
        }
    }
}
