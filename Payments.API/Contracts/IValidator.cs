using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payments.API.Models;

namespace Payments.API.Contracts
{
    /// <summary>
    /// General contract for any validation
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Method for validating payment request
        /// </summary>
        /// <param name="request">Payment request to verify</param>
        /// <returns>result of validation or validation exception</returns>
        Task<bool> IsSatisfied(PaymentRequest request);
    }
}
