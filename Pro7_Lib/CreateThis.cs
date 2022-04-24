namespace Pro7_Lib;

public class CreateThis
{
    public string name { get; }
    public string type { get; }

    public CreateThis(string n, PlaylistType t)
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