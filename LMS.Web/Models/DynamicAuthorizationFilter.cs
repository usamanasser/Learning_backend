﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using DynamicAuthorization.Mvc.Core;
//using LMS.Persistence;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Authorization;
//using Microsoft.AspNetCore.Mvc.Controllers;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.EntityFrameworkCore;
//using Newtonsoft.Json;

//namespace LMS.Web.Models
//{
//    public class DynamicAuthorizationFilter : IAsyncAuthorizationFilter
//    {
//        private readonly ApplicationDbContext _dbContext;
     
//        public DynamicAuthorizationFilter(ApplicationDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
//        {
//            if (!IsProtectedAction(context))
//                return;

//            if (!IsUserAuthenticated(context))
//            {
//                context.Result = new UnauthorizedResult();
//                return;
//            }

//            var actionId = GetActionId(context);
//            var userName = context.HttpContext.User.Identity.Name;

//            var roles = await (
//                from user in _dbContext.Users
//                join userRole in _dbContext.UserRoles on user.Id equals userRole.UserId
//                join role in _dbContext.Roles on userRole.RoleId equals role.Id
//                where user.UserName == userName
//                select role
//            ).ToListAsync();

//            foreach (var role in roles)
//            {
//                var accessList =
//                    JsonConvert.DeserializeObject<IEnumerable<MvcControllerInfo>>(role.Access);
//                if (accessList.SelectMany(c => c.Actions).Any(a => a.Id == actionId))
//                    return;
//            }

//            context.Result = new ForbidResult();
//        }

//        private bool IsProtectedAction(AuthorizationFilterContext context)
//        {
//            try
//            {
//                if (context.Filters.Any(item => item is IAllowAnonymousFilter))
//                    return false;

//                var controllerActionDescriptor = (ControllerActionDescriptor)context.ActionDescriptor;
//                var controllerTypeInfo = controllerActionDescriptor.ControllerTypeInfo;
//                var actionMethodInfo = controllerActionDescriptor.MethodInfo;

//                var authorizeAttribute = controllerTypeInfo.GetCustomAttribute<AuthorizeAttribute>();
//                if (authorizeAttribute != null)
//                    return true;

//                authorizeAttribute = actionMethodInfo.GetCustomAttribute<AuthorizeAttribute>();
//                if (authorizeAttribute != null)
//                    return true;

//                return false;
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                return false;

//            }
//        }

//        private bool IsUserAuthenticated(AuthorizationFilterContext context)
//        {
//            return context.HttpContext.User.Identity.IsAuthenticated;
//        }

//        private string  GetActionId(AuthorizationFilterContext context)
//        {
//            var controllerActionDescriptor = (ControllerActionDescriptor)context.ActionDescriptor;
//            var area = controllerActionDescriptor.ControllerTypeInfo.
//                                 GetCustomAttribute<AreaAttribute>()?.RouteValue;
//            var controller = controllerActionDescriptor.ControllerName;
//            var action = controllerActionDescriptor.ActionName;
//            var claims = new List<Claim>
//            {
//                new Claim("Action", $"{area}:{controller}:{action}")
           
//            };
         
//            return $"{area}:{controller}:{action}";
//        }
//    }
//}
