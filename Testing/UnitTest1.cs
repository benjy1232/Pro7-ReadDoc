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

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GetLibrary()
    {
        LibraryItems lib = new LibraryItems("http://192.168.0.127:1025");
        if (lib.Presentations == null)
        {
            Assert.Fail();
        }
        Assert.Pass();
    }

    [Test]
    public void AddPlaylist()
    {
        CreateThisImpl create = new("Easter", "playlist", "http://192.168.0.127:1025");
        Assert.Pass();
    }
}
