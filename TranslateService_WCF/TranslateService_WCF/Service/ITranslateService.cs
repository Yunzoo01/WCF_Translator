using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TranslateService_WCF
{
    [ServiceContract]
    internal interface ITranslateService
    {
        [OperationContract]
        TranslateMessageData TranslateMessage(string message, string code);

        [OperationContract]
        List<TranslateMessageData> SelectAllTranslateMessage();


    }
}
