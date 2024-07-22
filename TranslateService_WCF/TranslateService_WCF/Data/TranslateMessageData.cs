using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TranslateService_WCF
{
    [DataContract]
    public class TranslateMessageData
    {
        [DataMember(Order = 1, IsRequired = true, Name = "Source")]
        public string SourceMessage { get; set; }

        [DataMember(Order = 2, IsRequired = true, Name ="L_Code")]
        public string Code { get; set; }

        [DataMember(Order = 3, IsRequired = true, Name = "Result")]
        public string TranslatedMessage { get; set; }


        public TranslateMessageData(string source, string code, string Translated)
        {
            SourceMessage = source;
            Code = code;
            TranslatedMessage = Translated;
        }
        public TranslateMessageData()
        {
        }

    }
}
