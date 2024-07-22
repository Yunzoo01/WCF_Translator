using System;
using System.Net;
using System.Text;
using System.IO;
//using Newtonsoft.Json.Linq;

namespace TranslateService_WCF
{
    public class WbTranslate_PapagoAPI
    {
        
        static string GetMessageLanguageCode(string message)
        {
            try
            {
                string url = "https://openapi.naver.com/v1/papago/detectLangs";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers.Add("X-Naver-Client-Id", "58MifoOIHHEJfi3Fxnt3");
                request.Headers.Add("X-Naver-Client-Secret", "KXciG_Ir5Z");
                request.Method = "POST";
                //string query = "你好"; //message in

                byte[] byteDataParams = Encoding.UTF8.GetBytes("query=" + message);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteDataParams.Length;
                Stream st = request.GetRequestStream();
                st.Write(byteDataParams, 0, byteDataParams.Length);
                st.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string text = reader.ReadToEnd();
                stream.Close();
                response.Close();
                reader.Close();
                //Console.WriteLine(text);
                string[] f= text.Split('"');
                return f[3];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "ERROR";
            }
        }


        //언어 코드   언어
        //ko  한국어
        //en  영어
        //ja  일본어
        static public string TranslateMessage(string message,string destinationString) //
        {
            string url = "https://openapi.naver.com/v1/papago/n2mt";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", "58MifoOIHHEJfi3Fxnt3");
            request.Headers.Add("X-Naver-Client-Secret", "KXciG_Ir5Z");
            request.Method = "POST";
            //message = "오늘 날씨는 어떻습니까?";
            string code = GetMessageLanguageCode(message);
            string qurey = "source=" + code + "&target=" + destinationString + "&text=";
            if(code == destinationString)
            {
                return null;
            }
            byte[] byteDataParams = Encoding.UTF8.GetBytes(qurey + message);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteDataParams.Length;
            Stream st = request.GetRequestStream();
            st.Write(byteDataParams, 0, byteDataParams.Length);
            st.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string text = reader.ReadToEnd();
            stream.Close();
            response.Close();
            reader.Close();

            
            string[] f = text.Split('"');   




            return f[15];
        }
    }
}