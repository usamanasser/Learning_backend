using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace LMS.Domain.Interface
{
    public interface IUserHttpContextProvider
    {
        Guid? GetUserId();
        string GetUserName();
        string GetUserFullName();
        bool DisableTenantFilter { get; set; }
    }

    public class UserHttpContextProvider : IUserHttpContextProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public UserHttpContextProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public Guid? GetUserId()
        {

            var claimsIdentity = (ClaimsIdentity)_contextAccessor.HttpContext.User.Identity;
            var userIdClaim = claimsIdentity.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return userIdClaim != null ? new Guid(userIdClaim?.Value) : (Guid?)null;

        }

        public string GetUserName()
        {
            if (_contextAccessor.HttpContext == null) return "Anonymous";

            var claimsIdentity = (ClaimsIdentity)_contextAccessor.HttpContext.User.Identity;
            var userIdClaim = claimsIdentity.Claims.SingleOrDefault(c => c.Type == "Email");
            return userIdClaim?.Value;
        }

        public string GetUserFullName()
        {
            if (_contextAccessor.HttpContext == null) return "Anonymous";

            var claimsIdentity = (ClaimsIdentity)_contextAccessor.HttpContext.User.Identity;
            var userIdClaim = claimsIdentity.Claims.SingleOrDefault(c => c.Type == "FullName");
            return userIdClaim?.Value;
        }


        

        public bool DisableTenantFilter { get; set; }
    }
}
