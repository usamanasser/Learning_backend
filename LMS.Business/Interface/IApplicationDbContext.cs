using LMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace LMS.Business.Interface
{
    public interface IApplicationDbContext
    {
       
        bool DisableTenantFilter { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    }
}
