using Newtonsoft.Json;
using Pro7_Lib.Library;
using Pro7_Lib.Playlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro7_Lib
{
    public class SendCreated
    {
        private LibraryItems library;
        public string WebRoot { get; }

        public SendCreated(string webRoot, LibraryItems library)
        {
            WebRoot = webRoot;
            this.library = library;

        }

        public string SendCreatedPlaylist(string name, PlaylistType type)
        {
            CreatePlaylist createdItem = new(name, type);
            string ToSend = JsonConvert.SerializeObject(createdItem, Formatting.Indented);
            StringContent Sending = new(ToSend, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            Task<HttpResponseMessage> PostTask = client.PostAsync($"{WebRoot}/v1/playlists", Sending);
            PostTask.Wait();
            HttpResponseMessage result = PostTask.Result;
            string res = result.Content.ReadAsStringAsync().Result;
            return res;
        }

        public bool AddPresentationToPlaylist(string songName, List<IPlaylistItem> playlist)
        {
            if(library.Presentations.TryGetValue(songName, out ProID id))
            {
                PresentationPlaylistItem item = new();
                item.id = id;
                playlist.Add(item);
                return true;
            }
            return false;
        }

        public void AddHeaderToPlaylist(string headerName, List<IPlaylistItem> playlist)
        {
            PlaylistHeader header = new(headerName);
            playlist.Add(header);
        }

        public bool SendPlaylist(string uuid, List<IPlaylistItem> playlist)
        {
            IndexPlaylist(playlist);
            string playlistJson = JsonConvert.SerializeObject(playlist, Formatting.Indented);
            StringContent ToSend = new(playlistJson, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            Task<HttpResponseMessage> putTask = client.PutAsync($"{WebRoot}/v1/playlist/{uuid}", ToSend);
            putTask.Wait();

            HttpResponseMessage response = putTask.Result;
            if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
            {
                return false;
            }
            return true;
        }

        private void IndexPlaylist(List<IPlaylistItem> playlist)
        {
            for (int i = 0; i < playlist.Count; i++)
            {
                playlist[i].id.index = i;
            }
        }
    }
}
