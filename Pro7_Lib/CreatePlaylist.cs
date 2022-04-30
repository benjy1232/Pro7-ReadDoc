namespace Pro7_Lib;

public class CreatePlaylist
{
    public string name { get; }
    public string type { get; }

    public CreatePlaylist(string n, PlaylistType t)
    {
        name = n;
        type = t.ToString();
    }
}

public enum PlaylistType
{
    playlist=0,
    group
}