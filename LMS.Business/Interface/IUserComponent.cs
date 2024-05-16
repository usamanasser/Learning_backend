using LMS.Business.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Business.Interface
{
    public interface IUserComponent
    {
        //List<UsersDto> UserListing(string type);
        Task DeleteUser(string id);
        string GetDecoratedRoleName(string roleId);
        string GetUserFullName(string email);
        string GetUserId(string email);
        Guid GetCompanyId(string email);
        string GetUserProfileImage(string email);
        string GetUserProfileImages(string id, string email);
        ProfileDto GetProfile(string email);
        ProfileDto GetProfile(string id, string email);
        Task UpdateProfile(ProfileDto dto);
        Task UpdateProfilePictureAsync(ProfileDto dto);
        UserDetailDto GetAllUserRoles();
        List<UserDetailDto> ListingUsers();
        //ManageUserDto EditUserRole(string id);
        //Task UpdateRoleAsync(ManageUserDto dto);
        Task<bool> UserNameExistsAsync(string email);
        Task<bool> IsTermsAndConditionsSigned(string email);
        Task TermsAndConditionsAccepted(string email);
        string GetCurrentUserName();

        UserDetailDto GetUserById(string Id);
        Task<string> GetRoleByUser(string Id);
        IQueryable<IdentityRole> GetAllRoleList();

        Task UpdateUserAndRole(UserDetailDto userDetailDto,bool changePassword);
        Task<bool> DeleteUser(Guid Id);

    }
}
