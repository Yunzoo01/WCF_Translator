using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateService_WCF
{
    internal class TranslateService :ITranslateService
    {
        public TranslateMessageData TranslateMessage(string message, string code)
        {
            DBControl db = new DBControl();
            TranslateMessageData dbtranslate = db.GetTranslateDataFromDB(message, code);
            if (dbtranslate == null)
            {
                string result = WbTranslate_PapagoAPI.TranslateMessage(message, code);
                dbtranslate = new TranslateMessageData(message, code, result);
                db.InsertDataToDB(message, code, result);
            }
            return dbtranslate;
        }

        public List<TranslateMessageData> SelectAllTranslateMessage()
        {
            DBControl db = new DBControl();
            return db.GetAllTranslateDataFromDB();
        }

    }
}
