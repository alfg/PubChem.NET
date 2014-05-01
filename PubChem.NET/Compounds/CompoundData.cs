using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Claims;

namespace PubChem.NET.Compounds
{
    /// <summary>
    /// Compound details
    /// </summary>
    public class Id2 
    {
        public int cid { get; set; }
    }

    public class Id
    {
        public Id2 id { get; set; }
    }

    public class Atoms
    {
        public List<int> aid { get; set; }
        public List<string> element { get; set; }
    }

    public class Bonds
    {
        public List<int> aid1 { get; set; }
        public List<int> aid2 { get; set; }
        public List<string> order { get; set; }
    }

    public class Style
    {
        public List<string> annotation { get; set; }
        public List<int> aid1 { get; set; }
        public List<int> aid2 { get; set; }
    }

    public class Conformer
    {
        public List<double> x { get; set; }
        public List<double> y { get; set; }
        public Style style { get; set; }
    }

    public class Coord
    {
        public List<string> type { get; set; }
        public List<int> aid { get; set; }
        public List<Conformer> conformers { get; set; }
    }

    public class Urn
    {
        public string label { get; set; }
        public string name { get; set; }
        public string datatype { get; set; }
        public string release { get; set; }
        public string implementation { get; set; }
        public string version { get; set; }
        public string software { get; set; }
        public string source { get; set; }
        public string parameters { get; set; }
    }

    public class Value
    {
        public int ival { get; set; }
        public double? fval { get; set; }
        public string binary { get; set; }
        public string sval { get; set; }
    }

    public class Prop
    {
        public Urn urn { get; set; }
        public Value value { get; set; }
    }

    public class Count
    {
        public int heavy_atom { get; set; }
        public int atom_chiral { get; set; }
        public int atom_chiral_def { get; set; }
        public int atom_chiral_undef { get; set; }
        public int bond_chiral { get; set; }
        public int bond_chiral_def { get; set; }
        public int bond_chiral_undef { get; set; }
        public int isotope_atom { get; set; }
        public int covalent_unit { get; set; }
        public int tautomers { get; set; }
    }

    public class PCCompound
    {
        public int cid
        {
            get { return id.id.cid; }
            set { }
        }
        public Id id { get; set; }
        public Atoms atoms { get; set; }
        public Bonds bonds { get; set; }
        public List<Coord> coords { get; set; }
        public int charge { get; set; }
        public List<Prop> props { get; set; }
        public Count count { get; set; }
    }

    public class CompoundData
    {
        public List<PCCompound> PC_Compounds { get; set; }
    }
}
