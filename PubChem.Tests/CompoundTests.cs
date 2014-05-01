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
            var data = mc.GetCompound(2244);

            // Assert
            Debug.WriteLine(data.cid);
            Debug.WriteLine(data.atoms);
            Debug.WriteLine(data.count.heavy_atom);
            Assert.IsFalse(string.IsNullOrEmpty(data.cid.ToString()));
        }

        [TestMethod]
        public void GetCompoundByName_Successful()
        {
            // Arrange
            PubChemManager mc = new PubChemManager();

            // Act
            var data = mc.GetCompoundByName("Aspirin");

            // Assert
            Debug.WriteLine(data.cid);
            Debug.WriteLine(data.atoms);
            Debug.WriteLine(data.count.heavy_atom);
            Assert.IsFalse(string.IsNullOrEmpty(data.cid.ToString()));
        }

        [TestMethod]
        public void GetCompoundByInchikey_Successful()
        {
            // Arrange
            PubChemManager mc = new PubChemManager();

            // Act
            var data = mc.GetCompoundByInchikey("BPGDAMSIGCZZLK-UHFFFAOYSA-N");

            // Assert
            Debug.WriteLine(data.cid);
            Debug.WriteLine(data.atoms);
            Debug.WriteLine(data.count.heavy_atom);
            Assert.IsFalse(string.IsNullOrEmpty(data.cid.ToString()));
        }

        [TestMethod]
        public void GetCompoundDescription_Successful()
        {
            // Arrange
            PubChemManager mc = new PubChemManager();

            // Act
            var data = mc.GetCompoundDescription(1983);

            // Assert
            Debug.WriteLine(data.CID);
            Debug.WriteLine(data.Title);
            Debug.WriteLine(data.DescriptionURL);
            Assert.IsFalse(string.IsNullOrEmpty(data.Title.ToString()));
        }
    }
}
