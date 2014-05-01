﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubChem.NET.Compounds
{
    public class Information
    {
        public int CID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DescriptionSourceName { get; set; }
        public string DescriptionURL { get; set; }
    }

    public class InformationList
    {
        public List<Information> Information { get; set; }
    }

    public class CompoundDescription
    {
        public InformationList InformationList { get; set; }
    }
}
