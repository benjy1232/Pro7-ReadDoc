using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Pro7_Lib;
using Pro7_Lib.Library;

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
        LibraryItems lib = new LibraryItems("http://192.168.0.34:50001");
        if (lib.Presentations == null)
        {
            Assert.Fail();
        }
        Assert.Pass();
    }
}
