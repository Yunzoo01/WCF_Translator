using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateService_WCF
{
    internal class DBControl
    {
        private WbDB db = new WbDB();

        #region Open(Configuration활용) & Close
        public bool Open()
        {
            string server = ConfigurationManager.AppSettings["server"];
            string database = ConfigurationManager.AppSettings["database"];
            string id = ConfigurationManager.AppSettings["id"];
            string pw = ConfigurationManager.AppSettings["pw"];

            return db.Open(server, database, id, pw);
        }

        public void Close()
        {
            db.Close();
        }

        #endregion 
        public void InsertDataToDB(string message, string code, string result)
        {
            try
            {
                Open();
                string sql1 = WbQuery.InsertDataToDB(message, code, result);
                db.CommandNonQuery(sql1);
            }
            catch (Exception)
            {
                return;
            }
            finally
            {
                db.Close();
            }


        }
        public  List<TranslateMessageData> GetAllTranslateDataFromDB()
        {
            try
            {
                Open();
                string sql1 = WbQuery.GetAllTranslateDataFromDB();
                return db.CommandQueryForSelectAll(sql1);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db.Close();
            }
        }

        public TranslateMessageData GetTranslateDataFromDB(string message, string code)
        {
            try
            {
                Open();
                string sql1 = WbQuery.GetTranslateDataFromDB(message, code);
                TranslateMessageData m = db.CommandQueryForTranslate(sql1);
                return m;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                db.Close();
            }

        }

    }
}
