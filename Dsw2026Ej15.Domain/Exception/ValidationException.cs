using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Api.Middleware
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {

        }
    }
}
