﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.API.Models
{
    public class ErrorResponse
    {
        public string ErrorCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}
