using Newtonsoft.Json;

namespace Pro7_Lib.Library;

public class LibraryItems
{
    public Dictionary<string, ProID> Presentations { get; set; }
    public List<ProID>? Libraries { get; set; }

    public LibraryItems(string root)
    {
        HttpClient client = new HttpClient();
        Task<string> response = client.GetStringAsync($"{root}/v1/libraries");
        while (!response.IsCompleted)
        {
            Thread.Sleep(20);
        }
        
        Libraries = JsonConvert.DeserializeObject<List<ProID>>(response.Result);
        Presentations = new();
        
        foreach (ProID library in Libraries)
        {
            string? uuid = library.uuid;
            response = client.GetStringAsync($"{root}/v1/library/{uuid}");
            while (!response.IsCompleted)
            {
                Thread.Sleep(20);
            }
            ProLibrary? proLibrary = JsonConvert.DeserializeObject<ProLibrary>(response.Result);
            if (proLibrary?.items != null)
                foreach (ProID id in proLibrary.items)
                {
                    Presentations.TryAdd(id.name, id);
                }
        }
    }
}