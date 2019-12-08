using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payments.API.Models;

namespace Payments.API.Contracts
{
    public interface IValidator
    {
        Task<bool> IsSatisfied(PaymentRequest request);
    }
}
