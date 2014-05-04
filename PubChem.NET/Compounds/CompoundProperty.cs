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
//        public int CID { get { return Properties[0].PropertyTable.CID; } }
//        public string MolecularFormula { get { return Properties[0].PropertyTable.MolecularFormula; } }
//        public float MolecularWeight { get { return Properties[0].PropertyTable.MolecularWeight; } }
//        public string InChiKey { get { return Properties[0].PropertyTable.InChiKey; } }
    }

    public class CompoundProperty
    {
        public PropertyTable PropertyTable { get; set; }
    }
}
