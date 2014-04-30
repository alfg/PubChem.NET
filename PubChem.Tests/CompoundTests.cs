using System.Collections.Generic;
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
            CompoundData data = mc.GetCompounds(2244);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(data.PC_Compounds));
        }
    }
}
