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

        public PCCompound GetCompoundsByCID(int cid)
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
            //
            string fullUrl = string.Format(_httpUrl, apiAction);
            var client = new RestClient(); 

            //
            T results = default(T);

            var request = new RestRequest(fullUrl, Method.POST);
            var response = client.Execute(request);
            var content = response.Content;
            results = JsonConvert.DeserializeObject<T>(content);

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
