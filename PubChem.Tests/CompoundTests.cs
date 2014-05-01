using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PubChem.NET;
using PubChem.NET.Compounds;

namespace PubChem.Tests
{
    [TestClass]
    public class CompoundTests
    {
        [TestMethod]
        public void GetCompound_Successful()
        {
            // Arrange
            PubChemManager mc = new PubChemManager();

            // Act
            var data = mc.GetCompoundsByCID(2244);

            // Assert
//            Debug.WriteLine(data.id.id.cid);
            Debug.WriteLine(data.cid);
            Assert.IsFalse(string.IsNullOrEmpty(data.ToString()));
        }
    }
}
