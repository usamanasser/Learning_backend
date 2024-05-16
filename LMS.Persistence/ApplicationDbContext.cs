using LMS.Domain.Entities;
using LMS.Domain.Interface;
using LMS.Persistence.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using LMS.Business.Interface;
using ModelBuilder = Microsoft.EntityFrameworkCore.ModelBuilder;
namespace LMS.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>,IApplicationDbContext
    {
        private readonly IUserHttpContextProvider _httpContextProvider;
      
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IUserHttpContextProvider httpContext)
            : base(options)
        {
            _httpContextProvider = httpContext;
        }

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
         modelBuilder.Seed();
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        public bool DisableTenantFilter { get; set; }
        
    }
}
