﻿using System.Threading.Tasks;
using Payments.API.Models;

namespace Payments.API.Contracts
{
    public interface IPaymentValidator
    {
        Task<bool> Validate(PaymentRequest request);
    }
}