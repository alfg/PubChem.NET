﻿using System;
using System.Runtime.Serialization;

namespace PubChem.NET.Errors
{
    [DataContract]
    public class ApiError
    {
         [DataMember(Name = "status")]
        public string Status
        {
            get;
            set;
        }

        [DataMember(Name = "code")]
        public string Code
        {
            get;
            set;
        }

        [DataMember(Name = "name")]
        public string Name
        {
            get;
            set;
        }

        [DataMember(Name = "error")]
        public string Error
        {
            get;
            set;
        }
    }
}
