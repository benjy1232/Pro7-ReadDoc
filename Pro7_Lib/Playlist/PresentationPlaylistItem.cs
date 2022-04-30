namespace Pro7_Lib.Playlist;

public class PresentationPlaylistItem : IPlaylistItem
{
    public ProID id { get; set; }
    public string type { get; set; }
    public bool is_hidden { get; set; }
    public bool is_pco { get; set; }

    public PresentationPlaylistItem()
    {
        type = "presentation";
        is_hidden = false;
        is_pco = false;
    }
}
