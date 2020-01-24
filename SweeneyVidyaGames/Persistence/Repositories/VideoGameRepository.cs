using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SweeneyVidyaGames.Api.Persistence.Contexts;
using SweeneyVidyaGames.Api.Domain.Repositories;
using SweeneyVidyaGames.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace SweeneyVidyaGames.Api.Persistence.Repositories
{
    public class VideoGameRepository : BaseRepository, IVideoGameRepository
    {
        public VideoGameRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<VideoGameDTO>> ListAsync()
        {
            return await context.VideoGames.ToListAsync();
        }

        public async Task AddAsync(VideoGameDTO videoGame)
        {
            await context.VideoGames.AddAsync(videoGame);
        }

        public async Task<VideoGameDTO> FindByIdAsync(int id)
        {
            return await context.VideoGames.FindAsync(id);
        }

        public void Update(VideoGameDTO videoGame)
        {
            context.VideoGames.Update(videoGame);
        }

        public void Remove(VideoGameDTO videoGame)
        {
            context.VideoGames.Remove(videoGame);
        }
    }
}
