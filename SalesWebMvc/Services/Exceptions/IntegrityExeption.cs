﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services.Exceptions
{
    public class IntegrityExeption : ApplicationException
    {
        public IntegrityExeption(string message) : base(message)
        {
        }

    }
}
