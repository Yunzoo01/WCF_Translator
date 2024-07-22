using System;
using System.Collections;
using System.Collections.Generic;

namespace _0427_WCFChat
{
    //델리게이트 선언
    public delegate void Chat(string nickname, string msg, string type,string recivename);
    public delegate void FileSend(string nickname, string filename, byte[] data, string recivename);

    internal class WbChat
    {
        private static Dictionary<string, IChatCallback> callbacks = new Dictionary<string, IChatCallback>();

        public string Join(IChatCallback call, string nickname)
        {
            if (callbacks.ContainsKey(nickname) == true)
            {              
                return "이미있는 ID";
            }
            callbacks.Add(nickname, call);
            return "OK";
        }

        public void Leave(string nickname)
        {
            callbacks.Remove(nickname);
        }
  
        public void BroadcastMessage(string nickname, string msg, string msgType,string recivename)
        {
            new Chat(UserHandler).BeginInvoke(nickname, msg, msgType, recivename, new AsyncCallback(EndAsync), null);
        }

        //BroadcastMessage()에서 호출 : Client 메서드 호출
        private void UserHandler(string nickname, string msg, string msgType,string recivename)
        {
            try
            {
                switch (msgType)
                {
                    case "Receive":

                        if (callbacks.ContainsKey(recivename) == false)
                            throw new Exception("해당 ID 로그인 안되어있음");
                        callbacks[nickname].Receive(nickname, msg);
                        callbacks[recivename].Receive(nickname, msg);                        
                        break; 
                }
            }
            catch (Exception e)
            {
                if(callbacks.ContainsKey(nickname)!=false)                   
                    callbacks[nickname].Receive("ERROR", e.Message);
            }
            
        }

        private void EndAsync(IAsyncResult ar)
        {
            Chat d = null;
            try
            {
                System.Runtime.Remoting.Messaging.AsyncResult asres = (System.Runtime.Remoting.Messaging.AsyncResult)ar;
                d = ((Chat)asres.AsyncDelegate);
                d.EndInvoke(ar);
            }
            catch
            {
            }
        }




        public void BroadcastFile(string nickname, string filename, byte[] data, string recivename)
        {
            new FileSend(UserHandler_File).BeginInvoke(nickname, filename, data, recivename, new AsyncCallback(EndAsync_File), null);
        }
        private void UserHandler_File(string nickname, string filename, byte[] data, string recivename)
        {
            if (callbacks.ContainsKey(recivename) == false)
                throw new Exception("해당 ID 로그인 안되어있음");
            callbacks[recivename].FileServiceToClient(nickname, filename, data, recivename);      
        }
        private void EndAsync_File(IAsyncResult ar)
        {
            FileSend d = null;
            try
            {
                System.Runtime.Remoting.Messaging.AsyncResult asres = (System.Runtime.Remoting.Messaging.AsyncResult)ar;
                d = ((FileSend)asres.AsyncDelegate);
                d.EndInvoke(ar);
            }
            catch
            {
            }
        }


    }
}
