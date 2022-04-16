namespace Pro7_Lib.Playlist;

public class PlaylistHeader : IPlaylistItem
{
    public ProID id { get; set; }
    public string type { get; set; }
    public bool is_hidden { get; set; }
    public bool is_pco { get; set; }
    public HeaderColor header_color { get; set; }
}

public class HeaderColor
{
    public float red { get; set; }
    public float green { get; set; }
    public float blue { get; set; }
    public float alpha { get; set; }
}
