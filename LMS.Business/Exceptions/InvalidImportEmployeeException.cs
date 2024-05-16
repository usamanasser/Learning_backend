using System;

namespace LMS.Business.Exceptions
{
    public class InvalidImportEmployeeException : ApplicationException
    {
        public InvalidImportEmployeeException(string errorMessage) : base(errorMessage)
        {
            
        }
    }
}