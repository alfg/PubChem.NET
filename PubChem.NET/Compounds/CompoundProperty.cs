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
        public string InChIKey { get; set; }
    }

    public class PropertyTable
    {
        public List<Property> Properties { get; set; }
    }

    public class CompoundProperty
    {
        public PropertyTable PropertyTable { get; set; }
    }

    public class PropertiesList
    {
        string[] _properties = new string[]
        {
            "MolecularFormula",
            "MolecularWeight",
            "CanonicalSMILES",
            "IsomericSMILES",
            "InChi"
        };
    }
    

    
}
