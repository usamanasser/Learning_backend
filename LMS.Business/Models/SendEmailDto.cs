using System;

namespace LMS.Business.Models
{
    public class SendEmailDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string EmailType { get; set; }
        public string EmailTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string YourEmail { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
