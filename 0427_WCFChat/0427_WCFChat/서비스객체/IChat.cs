using System;
using System.ServiceModel;

namespace _0427_WCFChat
{
    #region 1. 메세지 관련 Contract InterFace (클라이언트->서버)
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IChatCallback))]
    public interface IChat
    {
        [OperationContract(IsOneWay = false, IsInitiating = true)]
        string Join(string nickname);

        [OperationContract(IsOneWay = true, IsInitiating = false)]
        void Say(string nickname, string msg,string recivename);

        [OperationContract(IsOneWay = true, IsInitiating = false)]
        void Leave(string nickname);

        [OperationContract(IsOneWay = true, IsInitiating = false)]
        void FileClientToService(string nickname, string filename, byte[] data, string recivename);

    }
    #endregion

    #region 2. 클라이언트에 콜백할 CallBackContract  (서버->클라이언트)
    public interface IChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void Receive(string nickname, string message);

        [OperationContract(IsOneWay = true)]
        void UserMessage(string msg);

        [OperationContract(IsOneWay = true)]
        void FileServiceToClient(string nickname, string filename, byte[] data, string recivename);
    }
    #endregion
}
