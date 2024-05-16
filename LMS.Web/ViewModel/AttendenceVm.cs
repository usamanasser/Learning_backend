using System;

namespace LMS.Web.ViewModel
{
    public class AttendenceVm
    {
        public Guid  StudentId { get; set; }
        public DateTime  Date { get; set; }
        public bool IsPresent { get; set; }
    }
}
