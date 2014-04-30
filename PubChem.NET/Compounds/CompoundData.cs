using System.Runtime.Serialization;

namespace PubChem.NET.Compounds
{
    /// <summary>
    /// Compound details
    /// </summary>
    [DataContract]
    public class CompoundData
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// a display name for the account - empty first/last names will return the username
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "pc_compounds")]
        public string PC_Compounds { get; set; }
    }
}
