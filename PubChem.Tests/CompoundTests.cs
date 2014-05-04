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
            PubChemManager pc = new PubChemManager();

            // Act
            var data = pc.GetCompound(2244);

            // Debug output
            Debug.WriteLine(data.cid);
            Debug.WriteLine(data.atoms);
            Debug.WriteLine(data.count.heavy_atom);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(data.cid.ToString()));
        }

        [TestMethod]
        public void GetCompoundByName_Successful()
        {
            // Arrange
            PubChemManager pc = new PubChemManager();

            // Act
            var data = pc.GetCompoundByName("Aspirin");

            // Debug output
            Debug.WriteLine(data.cid);
            Debug.WriteLine(data.atoms);
            Debug.WriteLine(data.count.heavy_atom);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(data.cid.ToString()));
        }

        [TestMethod]
        public void GetCompoundByInchikey_Successful()
        {
            // Arrange
            PubChemManager pc = new PubChemManager();

            // Act
            var data = pc.GetCompoundByInchikey("BPGDAMSIGCZZLK-UHFFFAOYSA-N");

            // Debug output
            Debug.WriteLine(data.cid);
            Debug.WriteLine(data.atoms);
            Debug.WriteLine(data.count.heavy_atom);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(data.cid.ToString()));
        }

        [TestMethod]
        public void GetCompoundDescription_Successful()
        {
            // Arrange
            PubChemManager pc = new PubChemManager();

            // Act
            var data = pc.GetCompoundDescription(1983);

            // Debug output
            Debug.WriteLine(data.CID);
            Debug.WriteLine(data.Title);
            Debug.WriteLine(data.DescriptionURL);
            Debug.WriteLine(data.Description);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(data.Title.ToString()));
        }

        [TestMethod]
        public void GetCompoundProperty_Successful()
        {
            // Arrange
            PubChemManager pc = new PubChemManager();
            
            // Act
            var data = pc.GetCompoundProperties(3434);

            // Debug output
            Debug.WriteLine(data.CID);
            Debug.WriteLine(data.MolecularFormula);
            Debug.WriteLine(data.MolecularWeight);
            Debug.WriteLine(data.InChIKey);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(data.CID.ToString()));
        }
    }
}
