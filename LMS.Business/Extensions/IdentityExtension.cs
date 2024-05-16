using System;
using System.Security.Claims;
using System.Security.Principal;

namespace LMS.Business.Extensions
{
    public static class IdentityExtension
    {
        public static string FullName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("FullName");
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string UserId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string Organization(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Organization");
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static Guid CompanyId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("CompanyId");
            return (claim != null) ? Guid.Parse(claim.Value) : Guid.Empty;
        }
        public static string Email(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Email");
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string CompanyLogo(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("CompanyLogo");
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string UserImagePath(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("UserImagePath");
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string RoleName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("RoleName");
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}
