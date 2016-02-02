using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace HW6
{
    public class YandexAPI
    {
        const string AppId = "10aa8c6b-c1b8-4cdb-9a77-778476db8339";

        public YandexAPI()
        {
            if (!CheckConnection()) { if (!CheckConnection()) { if (!CheckConnection()) { throw new AccessViolationException("No Internet Connection!"); } } }
            if (AppId == "") { throw new AccessViolationException("No Access token detected!"); }
        }

        public DTO.MainData Query(string text, string apikey = AppId, string lang = "ru_RU", string type = "biz", int results = 10)
        {
            DTO.MainData myData = null;
            var client = new System.Net.Http.HttpClient();
            var queryString = string.Format("https://search-maps.yandex.ru/v1/?text={0}&type={1}&lang={2}&apikey={3}&results={4}", text, type, lang, apikey, results);

            var result = client.GetStringAsync(queryString).Result;
            myData = JsonConvert.DeserializeObject<DTO.MainData>(result);

            return myData;
        }

        public bool CheckConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }

}
