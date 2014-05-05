using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubChem.NET.Compounds
{
    public class Property
    {
        public int CID { get; set; }
        public string MolecularFormula { get; set; }
        public double MolecularWeight { get; set; }
        public string CanonicalSMILES { get; set; }
        public string IsomericSMILES { get; set; }
        public string InChI { get; set; }
        public string InChIKey { get; set; }
        public string IUPACName { get; set; }

        // Extra properties
        public double XLogP { get; set; }
        public double ExactMass { get; set; }
        public double MonoisotopicMass { get; set; }
        public int TPSA { get; set; }
        public int Complexity { get; set; }
        public int Charge { get; set; }
        public int HBondDonorCount { get; set; }
        public int HBondAcceptorCount { get; set; }
        public int RotatableBondCount { get; set; }
        public int HeavyAtomCount { get; set; }
        public int IsotopeAtomCount { get; set; }
        public int AtomStereoCount { get; set; }
        public int DefinedAtomStereoCount { get; set; }
        public int UndefinedAtomStereoCount { get; set; }
        public int BondStereoCount { get; set; }
        public int DefinedBondStereoCount { get; set; }
        public int UndefinedBondStereoCount { get; set; }
        public int CovalentUnitCount { get; set; }
        public double Volume3D { get; set; }
        public double XStericQuadrupole3D { get; set; }
        public double YStericQuadrupole3D { get; set; }
        public double ZStericQuadrupole3D { get; set; }
        public int FeatureCount3D { get; set; }
        public int FeatureAcceptorCount3D { get; set; }
        public int FeatureDonorCount3D { get; set; }
        public int FeatureAnionCount3D { get; set; }
        public int FeatureCationCount3D { get; set; }
        public int FeatureRingCount3D { get; set; }
        public int FeatureHydrophobeCount3D { get; set; }
        public double ConformerModelRMSD3D { get; set; }
        public int EffectiveRotorCount3D { get; set; }
        public int ConformerCount3D { get; set; }
    }

    public class PropertyTable
    {
        public List<Property> Properties { get; set; }
    }

    public class CompoundProperty
    {
        public PropertyTable PropertyTable { get; set; }
    }
}
