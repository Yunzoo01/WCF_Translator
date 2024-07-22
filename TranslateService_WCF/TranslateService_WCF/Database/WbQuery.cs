using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateService_WCF
{
    internal static class WbQuery
    {
        public static string GetTranslateDataFromDB(string message, string code)
        {
            string sql = string.Format("select * from TranslateData where Source = '{0}' and code='{1}' ", message, code);
            return sql;
        }


        public static string InsertDataToDB(string message, string code, string result)
        {
            string sql = string.Format("insert into TranslateData values('{0}','{1}','{2}')  ", message, code, result);
            return sql;
        }
        public static string GetAllTranslateDataFromDB()
        {
            string sql = string.Format("select * from TranslateData ");
            return sql;
        }
    }
}
