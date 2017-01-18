using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KozaDisk.Class
{
    class Request
    {
        /// <summary>
        /// Отправить POST запрос
        /// </summary>
        /// <param name="Url">URL сервера</param>
        /// <param name="Data">Параметры запроса, например, fname=Andrey&lname=Mamatov</param>
        /// <returns></returns>
        public static string POST(string Url, string Data)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(Url);
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";

            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(Data);
            req.ContentLength = bytes.Length;
            System.IO.Stream os = req.GetRequestStream(); // создаем поток 
            os.Write(bytes, 0, bytes.Length); // отправляем в сокет 
            os.Close();

            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null)
            {
                return null;
            }
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }
    }
}
