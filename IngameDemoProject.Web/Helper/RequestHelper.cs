using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IngameDemoProject.Web.Helper
{
    public class RequestHelper
    {
        private static readonly HttpClient client = new HttpClient();

        public static T GetRequest<T>(string url)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            var stringTask = client.GetStringAsync(url);
            var message = stringTask.Result;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(message);
        }

        public static T PostRequest<T>(string url,object data)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            var stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var stringTask = client.PostAsync(url, stringContent).Result;
            var message = stringTask.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(message);
        }
    }
}
