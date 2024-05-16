using System;

namespace LMS.Business.Models
{
    public class UserDetailDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int AcademyId { get; set; }
        public string RoleId { get; set; }
        //public List<RolesDto> Roles { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string RoleName { get; set; }
        //public List<CompanyDto> Companies { get; set; }
        public string Action { get; set; }
        public string UserId { get; set; }
        public bool IsActive { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public bool IsApproved { get; set; }
        public bool IsPresent { get; set; }
        public DateTime? AttendenceDate { get; set; }
    }
}
