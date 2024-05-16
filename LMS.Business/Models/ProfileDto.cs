using System.ComponentModel.DataAnnotations;

namespace LMS.Business.Models
{
    public class ProfileDto
    {
        [Display(Name = "id")]
        public string ProfileId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Display(Name = "Birth Date")]
        public string DOB { get; set; }
        public string ImagePath { get; set; }
    }
}
