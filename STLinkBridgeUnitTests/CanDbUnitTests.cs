﻿using System;
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
            var result = CanDbCodeGenerator.CanDbcParser.OpenCanDB(@"..\..\..\CanDbCodeGenerator\candbc_Cfs20v1.dbc");

            // TODO: Make comparison for validation
        }

        [TestMethod]
        public void VerifyDlcTest()
        {
            throw new NotImplementedException(); // TODO: Make test 
        }

    }
}
