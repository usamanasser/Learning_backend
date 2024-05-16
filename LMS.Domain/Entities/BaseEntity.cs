using System;
using LMS.Domain.Interface;

namespace LMS.Domain.Entities
{
    public abstract class BaseEntity:IBaseEntity
    {
        public Guid Id { get; set; }
    }
}
