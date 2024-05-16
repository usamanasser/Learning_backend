using System;

namespace LMS.Business.Exceptions
{
    public class InvalidIncomeStatementException  : ApplicationException
    {
        public InvalidIncomeStatementException(string errorMessage) : base(errorMessage)
        {
            
        }
    }
}