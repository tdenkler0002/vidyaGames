using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SweeneyVidyaGames.Api.Models;

namespace SweeneyVidyaGames.Api.Domain.Repositories
{
    public interface IVideoGameRepository
    {
        Task<IEnumerable<VideoGameDTO>> ListAsync();
        Task AddAsync(VideoGameDTO videoGame);
        Task<VideoGameDTO> FindByIdAsync(int id);
        void Update(VideoGameDTO videoGame);
        void Remove(VideoGameDTO videoGame);
    }
}
