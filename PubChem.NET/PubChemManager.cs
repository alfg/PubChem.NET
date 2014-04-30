using System;
using System.Collections.Generic;
using System.Linq;
using PubChem.NET.Compounds;
using PubChem.NET.Errors;
using ServiceStack;
using ServiceStack.Text;

namespace PubChem.NET
{
    public class PubChemManager
    {
        #region Fields and properties

        /// <summary>
        /// The HTTP endpoint for the API.
        /// See https://pubchem.ncbi.nlm.nih.gov/pug_rest/PUG_REST.html for more information
        /// </summary>
        private string _httpUrl = "http://pubchem.ncbi.nlm.nih.gov/rest/pug/{0}";

        #endregion

        #region Constructors

        // Default constructor
        public PubChemManager()
        {

        }
        #endregion

        #region API: Compound

        public CompoundData GetCompounds(int cid)
        {
            // Api action
            string apiAction = string.Format("compound/cid/{0}/json", cid);

            // Create arguments object
            object args = new
            {
                cid = cid
            };

            // Make call
            return MakeAPICall<CompoundData>(apiAction, args);
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

            //
            T results = default(T);

            try
            {
                //
                var resultString = fullUrl.PostJsonToUrl(args);
                results = resultString.Trim().FromJson<T>();
            }
            catch (Exception ex)
            {
                string errorBody = ex.GetResponseBody();
                
                //
                ApiError apiError = errorBody.FromJson<ApiError>();

                //
                throw new PubChemAPIException(apiError.Error, ex, apiError);
            }

            // Return the results
            return results;

        }

        #endregion
    }
}
