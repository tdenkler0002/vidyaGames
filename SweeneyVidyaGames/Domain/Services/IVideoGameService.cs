using System.Collections.Generic;
using System.Threading.Tasks;
using SweeneyVidyaGames.Api.Domain.Services.Communication;
using SweeneyVidyaGames.Api.Models;

namespace SweeneyVidyaGames.Api.Interfaces
{
    public interface IVideoGameService
    {
        Task<IEnumerable<VideoGameDTO>> ListAsync();
        Task<VideoGameResponse> SaveAsync(VideoGameDTO videoGame);
        Task<VideoGameResponse> UpdateAsync(int id, VideoGameDTO videoGame);
        Task<VideoGameResponse> DeleteAsync(int id);
    }
}