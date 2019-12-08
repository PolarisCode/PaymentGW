using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Payments.API.Contracts;
using Payments.API.Processors;

namespace Payments.API
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection RegisterAll(this IServiceCollection services)
        {
            services.AddScoped<IPaymentProcessor, PaymentProcessor>();

            return services;
        }
    }
}
