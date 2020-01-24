using System;
using System.Threading.Tasks;
using SweeneyVidyaGames.Api.Domain.Repositories;
using SweeneyVidyaGames.Api.Persistence.Contexts;

namespace SweeneyVidyaGames.Api.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
