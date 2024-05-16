using System;

namespace LMS.Business.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key)
               : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
}
