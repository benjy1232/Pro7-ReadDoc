using Newtonsoft.Json;
using NUnit.Framework;
using Pro7_Lib;
using Pro7_Lib.Library;
using Pro7_Lib.Playlist;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Testing;

public class Tests
{
    const string ROOT = "http://192.168.0.21:50001";
    [SetUp]
    public void Setup()
    {
    }

    // Tests the creation of a playlist and the addition of songs and headers to the playlist
    // If the creation works then it passes the test and it doesn't then it is failed
    // It is double checked with ProPresenter 7.9 on a Windows Laptop and making sure that the 
    // Playlist is correctly made
    [Test]
    public void SendPlaylist()
    {
        bool PlaylistSent;
        List<IPlaylistItem> playlist = new();
        LibraryItems libraryItems = new(ROOT);
        
        SendCreated create = new(ROOT, libraryItems);
        string response = create.CreateNewPlaylist("test", PlaylistType.playlist);
        ProPlaylist? createdPlaylist = JsonConvert.DeserializeObject<ProPlaylist>(response);
        
        create.AddHeaderToPlaylist("Worship", playlist);
        create.AddPresentationToPlaylist("Agnus Dei", playlist);
        create.AddPresentationToPlaylist("Amazing Grace", playlist);
        create.AddHeaderToPlaylist("Sermon", playlist);
        
        PlaylistSent = create.SendPlaylist(createdPlaylist.id.uuid, playlist);
        if (PlaylistSent)
        {
            Assert.Pass();
        }

        Assert.Fail();
    }
}
