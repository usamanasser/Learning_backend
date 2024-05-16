using System;

namespace LMS.Web.ViewModel
{
    public class RegisterVm
    {
        public string Id { get; set; }
        public string FirstNameInArabic { get; set; }
        public string MiddleNameInArabic { get; set; }
        public string LastNameInArabic { get; set; }
        public string FirstNameInEnglish { get; set; }
        public string MiddleNameInEnglish { get; set; }
        public string LastNameInEnglish { get; set; }
        public string FullName { get; set; }
        public decimal NationalId { get; set; }
        public DateTime Birthday { get; set; }

        public Guid? CityId { get; set; }
        public Guid? QualificationId { get; set; }
        public Guid? SpecialtyId { get; set; }

        public bool IsApproved { get; set; }
        public bool IsActive { get; set; }
        
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public string RoleName { get; set; }
    }
}
