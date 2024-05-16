using System;
using LMS.Web.Utilities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;

namespace LMS.Web.ExtensionMethods
{
    public static class HtmlHelperExtensionMethods
    {
        public static string Translate(this IHtmlHelper helper, string key)
        {
            IServiceProvider services = helper.ViewContext.HttpContext.RequestServices;
            SharedViewLocalizer localizer = services.GetRequiredService<SharedViewLocalizer>();
            string result = localizer[key];
            return result;
        }
    }
}
