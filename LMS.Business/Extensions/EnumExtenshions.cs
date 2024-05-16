using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace LMS.Business.Extensions
{
   public static class EnumExtenshions
    {
        public static string GetDisplayName(this Enum eEnum)
        {
            return eEnum.GetType()
                .GetMember(eEnum.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                ?.GetName();
        }
    }
}
