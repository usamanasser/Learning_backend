using LMS.Business.Interface;
using LMS.Business.Models;
using LMS.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace LMS.Business.Components
{
    class UserComponent : IUserComponent
    {
        private Task<ApplicationUser> _user;

        private readonly IPrincipal _principal;
        private readonly IApplicationDbContext _context;
        private readonly ILogger<UserComponent> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserComponent(IApplicationDbContext context, IPrincipal principal,
            ILogger<UserComponent> logger, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _principal = principal;
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public Task DeleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public string GetDecoratedRoleName(string roleId)
        {
            throw new NotImplementedException();
        }

        public string GetUserFullName(string email)
        {
            throw new NotImplementedException();
        }

        public string GetUserId(string email)
        {
            throw new NotImplementedException();
        }

        public Guid GetCompanyId(string email)
        {
            throw new NotImplementedException();
        }

        public string GetUserProfileImage(string email)
        {
            throw new NotImplementedException();
        }

        public string GetUserProfileImages(string id, string email)
        {
            throw new NotImplementedException();
        }

        public ProfileDto GetProfile(string email)
        {
            throw new NotImplementedException();
        }

        public ProfileDto GetProfile(string id, string email)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProfile(ProfileDto dto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProfilePictureAsync(ProfileDto dto)
        {
            throw new NotImplementedException();
        }

        public UserDetailDto GetAllUserRoles()
        {
            throw new NotImplementedException();
        }

        public List<UserDetailDto> ListingUsers()
        {

            var users = _userManager.Users.ToList();
            var userList = new List<UserDetailDto>();

            foreach (var user in users)
            {
                var userDto = new UserDetailDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                };
                userList.Add(userDto);
            }

            return userList;
        }

        public Task<bool> UserNameExistsAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsTermsAndConditionsSigned(string email)
        {
            throw new NotImplementedException();
        }

        public Task TermsAndConditionsAccepted(string email)
        {
            throw new NotImplementedException();
        }

        public string GetCurrentUserName()
        {
            throw new NotImplementedException();
        }

        public UserDetailDto GetUserById(string Id)
        {
            if (Id != string.Empty)
            {
                _user = _userManager.FindByIdAsync(Id);

                var userDetail = new UserDetailDto
                {
                    Id = _user.Result.Id,
                    UserName = _user.Result.UserName,
                    //FirstName = _user.Result.FirstName,
                    //LastName = _user.Result.LastName,
                    Email = _user.Result.Email,
                    PhoneNumber = _user.Result.PhoneNumber,

                };

                return userDetail;
            }

            return null;
        }

        public IQueryable<IdentityRole> GetAllRoleList()
        {
            var role = _roleManager.Roles;
            return role;
        }

        public async Task<string> GetRoleByUser(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            /*//var role = _roleManager.Roles;
        //    _roleManager.FindByIdAsync()*/
            if (Id != String.Empty)
            {
                var role = await _userManager.GetRolesAsync(user);
                var rol = "";

                foreach (var r in role)
                {
                    if (!role.Contains(",")) { rol = r; }
                    else { rol = "," + r; }
                }
                return rol;
            }

            return null;
        }

        public async Task UpdateUserAndRole(UserDetailDto userDetailDto, bool changePassword)
        {
            var userData = await _userManager.FindByIdAsync(userDetailDto.Id);

            if (userData.Id != string.Empty)
            {
                userData.UserName = userDetailDto.UserName;
                //userData.FirstName = userDetailDto.FirstName;
                //userData.LastName = userDetailDto.LastName;
                userData.PhoneNumber = userDetailDto.PhoneNumber;
                userData.Email = userDetailDto.Email;
            }

            if (changePassword)
            {
                if (userDetailDto.Password != null)
                {
                    var isRemove = await _userManager.RemovePasswordAsync(userData);
                    var a = await _userManager.AddPasswordAsync(userData, userDetailDto.Password);
                }
            }

            await _userManager.UpdateAsync(userData);

            var role = await _userManager.GetRolesAsync(userData);

            var r1 = await _userManager.RemoveFromRoleAsync(userData, role[0]);

            var ret = await _userManager.AddToRoleAsync(userData, userDetailDto.RoleName);

            var result = ret;
        }

        public async Task<bool> DeleteUser(Guid Id)
        {
            var user = _userManager.Users.Where(x => x.Id == Id.ToString()).ToList();
            if (user[0] != null)
            {
                //Remove Claims
                var claims = await _userManager.GetClaimsAsync(user[0]);
                var c = await _userManager.RemoveClaimsAsync(user[0], claims);

                // Remover Role
                var role = await _userManager.GetRolesAsync(user[0]);
                var r1 = await _userManager.RemoveFromRoleAsync(user[0], role[0]);

                var u = await _userManager.DeleteAsync(user[0]);

                if (u.Succeeded && r1.Succeeded && c.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
