using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Payments.API.Adapters;
using Payments.API.Contracts;
using Payments.API.Models;
using Payments.API.Processors;
using Payments.API.Validators;

namespace Payments.API
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection RegisterAll(this IServiceCollection services)
        {
            services.AddScoped<IPaymentProcessor, PaymentProcessor>();
            services.AddScoped<IBillingAdapter, BillingAdapter>();
            services.AddScoped<IPaymentValidator, PaymentValidations>();
            services.AddSingleton<IRequestSender<PaymentResponse>, HttpRequestSender<PaymentResponse>>();


            return services;
        }
    }
}
