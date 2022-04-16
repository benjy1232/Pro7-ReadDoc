using Newtonsoft.Json;

namespace Pro7_Lib;

public class ProLibrary
{
    public List<ProID>? items { get; }

    public ProLibrary(string library)
    {
        items = JsonConvert.DeserializeObject<List<ProID>>(library);
    }
}