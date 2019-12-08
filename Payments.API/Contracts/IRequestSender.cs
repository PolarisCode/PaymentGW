using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.API.Contracts
{
    public interface IRequestSender<T>
    {
        Task<T> SendAsync(string url, string requestUri, string jsonString);
    }
}
