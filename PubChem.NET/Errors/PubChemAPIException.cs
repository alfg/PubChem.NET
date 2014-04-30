using System;
using System.Runtime.Serialization;

namespace PubChem.NET.Errors
{
    /// <summary>
    /// PubChem API exception class
    /// </summary>
    class PubChemAPIException : Exception
    {
        public PubChemAPIException(string message, Exception internalException, ApiError apiError)
            : base(message)
        {
            this.InternalException = internalException;
            this.PubChemAPIError = apiError;
        }

        /// <summary>
        /// The PubChem API specific error information
        /// </summary>
        public ApiError PubChemAPIError
        {
            get;
            set;
        }

        /// <summary>
        /// The internal exception from within PubChem.NET error handling code
        /// </summary>
        public Exception InternalException
        {
            get;
            set;
        }
    }
}
