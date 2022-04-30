namespace Pro7_Lib.Playlist;

public class PlaylistHeader : IPlaylistItem
{
    public ProID id { get; set; }
    public string type { get; }
    public bool is_hidden { get; set; }
    public bool is_pco { get; set; }
    public HeaderColor header_color { get; set; }

    public PlaylistHeader(string headerName)
    {
        header_color = new();
        id = new();
        type = "header";
        is_hidden = false;
        is_pco = false;

        id.name = headerName;
    }
}

public class HeaderColor
{
    public float red { get; set; }
    public float green { get; set; }
    public float blue { get; set; }
    public float alpha { get; set; }
    public HeaderColor()
    {
        red = 0;
        green = 0;
        blue = 0;
        alpha = 1;
    }
}
