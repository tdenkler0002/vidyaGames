using System;
using System.Threading.Tasks;

namespace SweeneyVidyaGames.Api.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
