using System;

namespace LMS.Business.Exceptions
{
    public class ObjectAlreadyExistsException : ApplicationException
    {
        public ObjectAlreadyExistsException(string errorMessage) : base(errorMessage)
        {

        }
    }
}