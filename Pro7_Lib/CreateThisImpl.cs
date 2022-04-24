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
        public string WebRoot { get; }
        public CreateThisImpl(string webRoot)
        {
            WebRoot = webRoot;
        }

        public string SendCreatedItem(string name, PlaylistType type)
        {
            CreateThis createdItem = new(name, type);
            string ToSend = JsonConvert.SerializeObject(createdItem, Formatting.Indented);
            StringContent Sending = new(ToSend, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            Task<HttpResponseMessage> PostTask = client.PostAsync($"{WebRoot}/v1/playlists", Sending);
            PostTask.Wait();
            HttpResponseMessage result = PostTask.Result;
            string res = result.Content.ReadAsStringAsync().Result;
            return res;
        }
    }
}
