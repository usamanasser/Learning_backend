using System.Collections.Generic;

namespace LMS.Web.ViewModel
{
    public class MvcControllerInfoVm
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string AreaName { get; set; }
        public IEnumerable<MvcActionInfoVm> Actions { get; set; }
    }
}
