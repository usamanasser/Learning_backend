using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LMS.Web.ViewModel;

namespace LMS.Web.Models
{
    public class RoleViewModel
    {
        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Name { get; set; }

        public IEnumerable<MvcControllerInfoVm> SelectedControllers { get; set; }
    }
}
