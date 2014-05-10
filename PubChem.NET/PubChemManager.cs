using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using PubChem.NET.Compounds;
using PubChem.NET.Errors;
using RestSharp;

namespace PubChem.NET
{
    public class PubChemManager
    {
        #region Fields and properties

        /// <summary>
        /// The HTTP endpoint for the API.
        /// See https://pubchem.ncbi.nlm.nih.gov/pug_rest/PUG_REST.html for more information
        /// </summary>
        private const string _httpUrl = "http://pubchem.ncbi.nlm.nih.gov/rest/pug/{0}";

        /// <summary>
        /// An array of available compound properties.
        /// Used in GetCompoundProperties() method.
        /// </summary>
        private static readonly string[] _properties = new string[]
        {
            "MolecularFormula",
            "MolecularWeight",
            "CanonicalSMILES",
            "IsomericSMILES",
            "InChI",
            "InChIKey",
            "IUPACName"
        };

        private static readonly string[] _extraProperties = new string[]
        {
            "XLogP",
            "ExactMass",
            "MonoisotopicMass",
            "TPSA",
            "Complexity",
            "Charge",
            "HBondDonorCount",
            "HBondAcceptorCount",
            "RotatableBondCount",
            "HeavyAtomCount",
            "IsotopeAtomCount",
            "AtomStereoCount",
            "DefinedAtomStereoCount",
            "UndefinedAtomStereoCount",
            "BondStereoCount",
            "DefinedBondStereoCount",
            "UndefinedBondStereoCount",
            "CovalentUnitCount",
            "Volume3D",
            "XStericQuadrupole3D",
            "YStericQuadrupole3D",
            "ZStericQuadrupole3D",
            "FeatureCount3D",
            "FeatureAcceptorCount3D",
            "FeatureDonorCount3D",
            "FeatureAnionCount3D",
            "FeatureCationCount3D",
            "FeatureRingCount3D",
            "FeatureHydrophobeCount3D",
            "ConformerModelRMSD3D",
            "EffectiveRotorCount3D",
            "ConformerCount3D"
        };

        #endregion

        #region Constructors

        // Default constructor
        public PubChemManager()
        {

        }
        #endregion

        #region API: Compound

        /// <summary>
        /// Gets Compound data by CID.
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public PCCompound GetCompound(int cid)
        {
            // Api action
            string apiAction = string.Format("compound/cid/{0}/json", cid);

            // Create arguments object
            object args = new
            {
                cid = cid
            };

            // Make call
            var request = MakeAPICall<CompoundData>(apiAction, args);
            return request.PC_Compounds[0];
        }

        /// <summary>
        /// Gets Compound data by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public PCCompound GetCompoundByName(string name)
        {
            // Api action
            string apiAction = string.Format("compound/name/{0}/json", name);

            // Create arguments object
            object args = new
            {
                name = name
            };

            // Make call
            var request = MakeAPICall<CompoundData>(apiAction, args);
            return request.PC_Compounds[0];
        }

        /// <summary>
        /// Gets Compound data by Inchikey (International Chemical Indentifier)
        /// </summary>
        /// <param name="inchikey"></param>
        /// <returns></returns>
        public PCCompound GetCompoundByInchikey(string inchikey)
        {
            // Api action
            string apiAction = string.Format("compound/inchikey/{0}/json", inchikey);

            // Create arguments object
            object args = new
            {
                inchikey = inchikey
            };

            // Make call
            var request = MakeAPICall<CompoundData>(apiAction, args);
            return request.PC_Compounds[0];
        }

        /// <summary>
        /// Gets Compound Description by CID.
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public Information GetCompoundDescription(int cid)
        {
            // Api action
            string apiAction = string.Format("compound/cid/{0}/description/json", cid);

            // Create arguments object
            object args = new
            {
                cid = cid
            };

            // Make call
            var request = MakeAPICall<CompoundDescription>(apiAction, args);
            return request.InformationList.Information[0];
        }

        /// <summary>
        /// Gets compound properties by CID.
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="extraPropertiesList"></param>
        /// <returns></returns>
        public Property GetCompoundProperties(int cid, List<string> extraPropertiesList = null)
        {
            string properties = string.Join(",", _properties);

            // Concatenate extra properties list if provided
            if (extraPropertiesList != null)
            {
                var concatProperties = _properties.Concat(extraPropertiesList.ToArray());
                properties = string.Join(",", concatProperties);
            }

            // Api action
            string apiAction = string.Format("compound/cid/{0}/property/{1}/json", cid, properties);

            // Create arguments object
            object args = new
            {
            };

            // Make call
            var request = MakeAPICall<CompoundProperty>(apiAction, args);
            return request.PropertyTable.Properties[0];
        }

        /// <summary>
        /// Returns a list of Compound Properties
        /// </summary>
        /// <param name="cidsList"></param>
        /// <param name="extraPropertiesList"></param>
        /// <returns></returns>
        public PropertyTable ListCompoundProperties(List<int> cidsList, List<string> extraPropertiesList = null)
        {
            string cids = string.Join(",", cidsList);
            string properties = string.Join(",", _properties);

            // Concatenate extra properties list if provided
            if (extraPropertiesList != null)
            {
                var concatProperties = _properties.Concat(extraPropertiesList.ToArray());
                properties = string.Join(",", concatProperties);
            }

            // Api action
            string apiAction = string.Format("compound/cid/{0}/property/{1}/json", cids, properties);

            // Create arguments object
            object args = new
            {
            };

            // Make call
            var request = MakeAPICall<CompoundProperty>(apiAction, args);
            return request.PropertyTable;
            
        }

        /// <summary>
        /// Gets Compound Description by CID.
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public Information GetCompoundSynonyms(int cid)
        {
            // Api action
            string apiAction = string.Format("compound/cid/{0}/synonyms/json", cid);

            // Create arguments object
            object args = new
            {
                cid = cid
            };

            // Make call
            var request = MakeAPICall<CompoundDescription>(apiAction, args);
            return request.InformationList.Information[0];
        }

        /// <summary>
        /// Gets Compound Description by Name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Information GetCompoundSynonymsByName(string name)
        {
            // Api action
            string apiAction = string.Format("compound/name/{0}/synonyms/json", name);

            // Create arguments object
            object args = new
            {
                name = name
            };

            // Make call
            var request = MakeAPICall<CompoundDescription>(apiAction, args);
            return request.InformationList.Information[0];
        }

        /// <summary>
        /// Gets Compound Description by SMILES.
        /// </summary>
        /// <param name="smiles"></param>
        /// <returns></returns>
        public Information GetCompoundSynonymsBySmiles(string smiles)
        {
            // Api action
            string apiAction = string.Format("compound/smiles/{0}/synonyms/json", smiles);

            // Create arguments object
            object args = new
            {
                smiles = smiles
            };

            // Make call
            var request = MakeAPICall<CompoundDescription>(apiAction, args);
            return request.InformationList.Information[0];
        }

        #endregion

        #region Generic API calling methods

        /// <summary>
        /// Generic API call. Expects to be abel to serialize the results
        /// to the specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiAction"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private T MakeAPICall<T>(string apiAction, object args)
        {
            // Create Url path and client
            string fullUrl = string.Format(_httpUrl, apiAction);
            var client = new RestClient(); 

            // Set default results
            T results = default(T);

            // Make POST request and deserialize json response
            var request = new RestRequest(fullUrl, Method.POST);
            var response = client.Execute(request);
            var content = response.Content;
            results = JsonConvert.DeserializeObject<T>(content);

            // Handle exception
            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.";
                var pubchemException = new ApplicationException(message, response.ErrorException);
                throw pubchemException;
            }

            // Return the results
            return results;

        }

        #endregion
    }
}
