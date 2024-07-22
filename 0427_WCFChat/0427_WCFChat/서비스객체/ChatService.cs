using System;
using System.ServiceModel;

namespace _0427_WCFChat
{
    internal class ChatService : IChat
    {
         private IChatCallback callback = null;
         private WbChat wbchat = new WbChat();

        #region IChat

        public string Join(string nickname) 
        {            
            callback = OperationContext.Current.GetCallbackChannel<IChatCallback>();
            return wbchat.Join(callback, nickname);           
        }

        public void Leave(string nickname)
        {
            wbchat.Leave(nickname);
        }

        public void Say(string nickname, string msg,string revivename)
        {
            wbchat.BroadcastMessage(nickname, msg, "Receive", revivename);
        }

        public void FileClientToService(string nickname, string filename, byte[] data, string recivename)
        {
            wbchat.BroadcastFile(nickname, filename, data, recivename);
        }

        #endregion 
    }
}
