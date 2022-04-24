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
    const string ROOT = "http://192.168.0.125:1025";
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GetLibrary()
    {
        LibraryItems lib = new(ROOT);
        if (lib.Presentations == null)
        {
            Assert.Fail();
        }
        Assert.Pass();
    }

    [Test]
    public void AddPlaylist()
    {
        CreateThisImpl create = new(ROOT);
        string response = create.SendCreatedItem("playlist", PlaylistType.playlist);

        if(!response.Contains("type"))
        {
            Assert.Fail();
        }

        response = create.SendCreatedItem("folder", PlaylistType.group);

        if(!response.Contains("type"))
        {
            Assert.Fail();
        }
        Assert.Pass();
    }
}
