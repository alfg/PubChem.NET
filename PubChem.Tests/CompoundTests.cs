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
            Debug.WriteLine("--- Properties ---");
            Debug.WriteLine(data.CID);
            Debug.WriteLine(data.MolecularFormula);
            Debug.WriteLine(data.MolecularWeight);
            Debug.WriteLine(data.CanonicalSMILES);
            Debug.WriteLine(data.IsomericSMILES);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(data.CID.ToString()));
        }

        [TestMethod]
        public void GetCompoundExtraProperties_Successful()
        {
            // Arrange
            PubChemManager pc = new PubChemManager();

            // Test Extra properties
            var extraProperties = new List<string> { "Complexity", "HeavyAtomCount" } ;
            
            // Act
            var data = pc.GetCompoundProperties(3434, extraProperties);

            // Debug output
            Debug.WriteLine("--- Properties ---");
            Debug.WriteLine(data.CID);
            Debug.WriteLine(data.MolecularFormula);
            Debug.WriteLine(data.MolecularWeight);
            Debug.WriteLine(data.CanonicalSMILES);

            // Extra properties
            Debug.WriteLine("--- Extra Properties ---");
            Debug.WriteLine(data.XLogP);
            Debug.WriteLine(data.Complexity);
            Debug.WriteLine(data.HeavyAtomCount);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(data.CID.ToString()));
        }

        [TestMethod]
        public void ListCompoundProperties_Successful()
        {
            // Arrange
            PubChemManager pc = new PubChemManager();

            List<int> properties = new List<int>() {3434, 1212};
            
            // Act
            var data = pc.ListCompoundProperties(properties);

            // Debug output
            Debug.WriteLine(data.Properties[0].CID);
            Debug.WriteLine(data.Properties[0].IUPACName);

            Debug.WriteLine(data.Properties[1].CID);
            Debug.WriteLine(data.Properties[1].InChI);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(data.Properties[0].CID.ToString()));
        }

        [TestMethod]
        public void GetCompoundSynonyms_Successful()
        {
            // Arrange
            PubChemManager pc = new PubChemManager();

            // Act
            var data = pc.GetCompoundSynonyms(2244); // Aspirin

            // Debug output
            Debug.WriteLine(data.CID);

            foreach (string i in data.Synonym)
            {
                Debug.WriteLine(i);
            }
            Debug.WriteLine(data.Synonym);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(data.CID.ToString()));
        }

        [TestMethod]
        public void GetCompoundSynonymsByName_Successful()
        {
            // Arrange
            PubChemManager pc = new PubChemManager();

            // Act
            var data = pc.GetCompoundSynonymsByName("Aspirin"); // Aspirin

            // Debug output
            Debug.WriteLine(data.CID);

            foreach (string i in data.Synonym)
            {
                Debug.WriteLine(i);
            }
            Debug.WriteLine(data.Synonym);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(data.CID.ToString()));
        }

        [TestMethod]
        public void GetCompoundSynonymsBySmiles_Successful()
        {
            // Arrange
            PubChemManager pc = new PubChemManager();

            // Act
            var data = pc.GetCompoundSynonymsBySmiles("CCCC"); // Aspirin

            // Debug output
            Debug.WriteLine(data.CID);

            foreach (string i in data.Synonym)
            {
                Debug.WriteLine(i);
            }
            Debug.WriteLine(data.Synonym);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(data.CID.ToString()));
        }
    }
}
