using System;

namespace LMS.Business.Exceptions
{
    public class InvalidVatReturnException : ApplicationException
    {
        public InvalidVatReturnException(string errorMessage) : base(errorMessage)
        {
            
        }
    }
}