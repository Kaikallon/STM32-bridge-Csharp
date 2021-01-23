using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using STLinkCLRWrapper;
using System.Linq;
using System.Diagnostics;

namespace STLinkBridgeUnitTests
{
    [TestClass]
    public class CanDbUnitTests
    {
        [TestMethod]
        public void OpenLibraryTest()
        {
            CanDB.CanDB.OpenCanDB(@"C:\Users\Alexander\Downloads\Car_CFS19.dbc");

            // TODO: Make comparison
        }
    }
}
