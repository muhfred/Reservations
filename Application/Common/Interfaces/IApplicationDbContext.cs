using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Reservation> Reservations { get; set; }

        DbSet<Trip> Trips { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
