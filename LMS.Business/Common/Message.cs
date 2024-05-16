using System;

namespace LMS.Business.Common
{
  public  class Message
    {
        public Guid Id { get; set; }
        public string Slug { get; set; }
        public bool IsSuccess { get; set; }
        public string IsAddUpdate { get; set; }

    }
}
