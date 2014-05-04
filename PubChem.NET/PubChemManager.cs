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

        public Property GetCompoundProperties(int cid)
        {
            // Api action
            string apiAction = string.Format("compound/cid/{0}/property/MolecularFormula,MolecularWeight,InChIKey/json", cid);

            // Create arguments object
            object args = new
            {
                cid = cid,
            };

            // Make call
            var request = MakeAPICall<CompoundProperty>(apiAction, args);
            return request.PropertyTable.Properties[0];
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
