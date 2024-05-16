using System.Collections.Generic;
using DynamicAuthorization.Mvc.Core;

namespace LMS.Business.Models
{
    public class MvcControllerInfo
    {
        public string Id => $"{AreaName}:{Name}";
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string AreaName { get; set; }
        public IEnumerable<MvcActionInfo> Actions { get; set; }
    }
}
