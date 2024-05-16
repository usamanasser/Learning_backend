using System;

namespace LMS.Business.Exceptions
{
   public class InvalidParameterException: ApplicationException
    {
        public InvalidParameterException(string errorMessage) : base(errorMessage)
        {

        }
    }
}
