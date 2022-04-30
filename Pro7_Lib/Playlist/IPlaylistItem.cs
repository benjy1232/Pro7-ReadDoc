namespace Pro7_Lib.Playlist;

public interface IPlaylistItem
{
    ProID id { get; set; }
    string type { get; }
    bool is_hidden { get; set; }
    bool is_pco { get; set; }
}
