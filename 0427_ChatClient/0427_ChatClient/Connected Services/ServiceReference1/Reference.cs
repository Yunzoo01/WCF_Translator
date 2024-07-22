﻿//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _0427_ChatClient.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IChat", CallbackContract=typeof(_0427_ChatClient.ServiceReference1.IChatCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IChat {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/Join", ReplyAction="http://tempuri.org/IChat/JoinResponse")]
        string Join(string nickname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChat/Join", ReplyAction="http://tempuri.org/IChat/JoinResponse")]
        System.Threading.Tasks.Task<string> JoinAsync(string nickname);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://tempuri.org/IChat/Say")]
        void Say(string nickname, string msg, string recivename);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://tempuri.org/IChat/Say")]
        System.Threading.Tasks.Task SayAsync(string nickname, string msg, string recivename);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://tempuri.org/IChat/Leave")]
        void Leave(string nickname);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://tempuri.org/IChat/Leave")]
        System.Threading.Tasks.Task LeaveAsync(string nickname);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://tempuri.org/IChat/FileClientToService")]
        void FileClientToService(string nickname, string filename, byte[] data, string recivename);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, IsInitiating=false, Action="http://tempuri.org/IChat/FileClientToService")]
        System.Threading.Tasks.Task FileClientToServiceAsync(string nickname, string filename, byte[] data, string recivename);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/Receive")]
        void Receive(string nickname, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/UserMessage")]
        void UserMessage(string msg);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IChat/FileServiceToClient")]
        void FileServiceToClient(string nickname, string filename, byte[] data, string recivename);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatChannel : _0427_ChatClient.ServiceReference1.IChat, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChatClient : System.ServiceModel.DuplexClientBase<_0427_ChatClient.ServiceReference1.IChat>, _0427_ChatClient.ServiceReference1.IChat {
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ChatClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public string Join(string nickname) {
            return base.Channel.Join(nickname);
        }
        
        public System.Threading.Tasks.Task<string> JoinAsync(string nickname) {
            return base.Channel.JoinAsync(nickname);
        }
        
        public void Say(string nickname, string msg, string recivename) {
            base.Channel.Say(nickname, msg, recivename);
        }
        
        public System.Threading.Tasks.Task SayAsync(string nickname, string msg, string recivename) {
            return base.Channel.SayAsync(nickname, msg, recivename);
        }
        
        public void Leave(string nickname) {
            base.Channel.Leave(nickname);
        }
        
        public System.Threading.Tasks.Task LeaveAsync(string nickname) {
            return base.Channel.LeaveAsync(nickname);
        }
        
        public void FileClientToService(string nickname, string filename, byte[] data, string recivename) {
            base.Channel.FileClientToService(nickname, filename, data, recivename);
        }
        
        public System.Threading.Tasks.Task FileClientToServiceAsync(string nickname, string filename, byte[] data, string recivename) {
            return base.Channel.FileClientToServiceAsync(nickname, filename, data, recivename);
        }
    }
}
