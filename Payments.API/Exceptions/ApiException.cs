﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.API.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(string message) : base(message) { }
    }
}