using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro7_Lib
{
    public class CreateThisImpl
    {
        public CreateThis createdItem { get; }
        public CreateThisImpl(string name, string type, string webRoot)
        {
            createdItem = new CreateThis(name, type);
            string ToSend = JsonConvert.SerializeObject(createdItem, Formatting.Indented);
            StringContent Sending = new(ToSend, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            Task<HttpResponseMessage> PostTask = client.PostAsync($"{webRoot}/v1/playlists", Sending);
            PostTask.Wait();
            HttpResponseMessage result = PostTask.Result;
            string res = result.Content.ReadAsStringAsync().Result;
            Console.WriteLine(res);

        }
    }
}
