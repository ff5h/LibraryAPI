using Library.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository.Interfaces
{
    public interface IAppDBContext
    {
        public DbSet<Book> Books { get; }
        public DbSet<Client> Clients { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
