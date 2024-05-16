using LMS.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;

namespace LMS.Persistence.Extensions
{
    public static class ModelBuilder
    {
        public static void Seed(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "0D936989-6267-4436-B3A1-FC32A5F78D77",
                UserName = "admin",
                Email = "admin@mailinator.com",
                NormalizedEmail = "ADMIN@MAILINATOR.COM",
                EmailConfirmed = true,
                NormalizedUserName = "ADMIN",
                PasswordHash = "AQAAAAEAACcQAAAAEIKFyVQH30i6JPByMhnnqX2sjy7JzPthdE7XlrAx+KF7HlopP4EYZbicgoRnYok5Rg==",
                SecurityStamp = "HDM6TKME4T5DISZCHW3MHD6YLQFNSWC2",
                ConcurrencyStamp = "117c7248-5202-44d5-a7eb-8f2717eba7e9",
                PhoneNumber = "03464114840",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "52E0A954-7039-483B-9224-99990743636D",
                Name = "Super Admin",
                NormalizedName = "SUPER ADMIN",
                ConcurrencyStamp = "0590a33c-cd2d-4c93-9e17-fce12bc2bd9d",
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "4E8A0E17-3C04-425A-BFBB-CCCD9A871D33",
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "C3D29792-8579-43F1-8CB4-C25A0EDC49F5",
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "CEA36602-E3BD-4CF6-B186-5D8A3E558A04",
                Name = "Instructor",
                NormalizedName = "INSTRUCTOR",
                ConcurrencyStamp = "0590a33c-cd2d-4d93-9e17-fce19bc2bd9d",
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "967BF027-3315-441E-BA7C-7AAF150C1C15",
                Name = "Admission admin",
                NormalizedName = "ADMISSION ADMIN",
                ConcurrencyStamp = "50CB4043-39C3-4A27-8AA4-53CB40687380",
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "E5480E8E-A150-4C80-82AB-62B5A8EBFD1B",
                Name = "Trainee",
                NormalizedName = "TRAINEE",
                ConcurrencyStamp = "1590a33c-cd2d-4c93-9e17-fce19bc2bd9d",
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "52E0A954-7039-483B-9224-99990743636D",
                UserId = "0D936989-6267-4436-B3A1-FC32A5F78D77"
            });
            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(
                new IdentityUserClaim<string>
                {
                    Id = 1,
                    UserId = "0D936989-6267-4436-B3A1-FC32A5F78D77",
                    ClaimType = "UserName",
                    ClaimValue = "admin"
                },
                new IdentityUserClaim<string>
                {
                    Id = 2,
                    UserId = "0D936989-6267-4436-B3A1-FC32A5F78D77",
                    ClaimType = "Email",
                    ClaimValue = "admin@mailinator.com"
                },
            new IdentityUserClaim<string>
            {
                Id = 3,
                UserId = "0D936989-6267-4436-B3A1-FC32A5F78D77",
                ClaimType = "FullName",
                ClaimValue = "Learning Management System"

            },
            new IdentityUserClaim<string>
            {
                Id = 4,
                UserId = "0D936989-6267-4436-B3A1-FC32A5F78D77",
                ClaimType = "RoleName",
                ClaimValue = "Super Admin"

            });

            
        }


    }
}