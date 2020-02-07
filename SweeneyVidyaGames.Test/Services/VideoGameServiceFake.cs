using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SweeneyVidyaGames.Api.Domain.Services.Communication;
using SweeneyVidyaGames.Api.Interfaces;
using SweeneyVidyaGames.Api.Models;
using SweeneyVidyaGames.Web.Models;

namespace SweeneyVidyaGames.Test.Services
{
    public class VideoGameServiceFake : IVideoGameService
    {
        private readonly IEnumerable<VideoGameDTO> _videoGames;
       
        public VideoGameServiceFake()
        {
            _videoGames = new List<VideoGameDTO>()
            {
                new VideoGameDTO() {
                Id = 100,
                Title = "Super Mario Bros 3",
                Platform = "Nintendo",
                DateAdded = new DateTime(2001, 01, 10),
                Released = new DateTime(1972, 09, 10),
                PlatformApplication = null,
                ImagePath = "http://fakeimg.com",
                Rating = 4.5F,
                Genre = EGenreType.PLATFORMER}
            };
        }

        public Task<VideoGameResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<VideoGameResponse> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VideoGameDTO>> ListAsync()
        {
            return Task.FromResult(_videoGames);
        }

        public Task<VideoGameResponse> SaveAsync(VideoGameDTO videoGame)
        {
            throw new NotImplementedException();
        }

        public Task<VideoGameResponse> UpdateAsync(int id, VideoGameDTO videoGame)
        {
            throw new NotImplementedException();
        }
    }
}
