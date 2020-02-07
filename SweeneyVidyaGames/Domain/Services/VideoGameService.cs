using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using SweeneyVidyaGames.Api.Domain.Repositories;
using SweeneyVidyaGames.Api.Domain.Services.Communication;
using SweeneyVidyaGames.Api.Infrastructure;
using SweeneyVidyaGames.Api.Interfaces;
using SweeneyVidyaGames.Api.Models;

namespace SweeneyVidyaGames.Api.Core.Services
{
    public class VideoGameService : IVideoGameService
    {
        private readonly IVideoGameRepository _videoGameRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;

        public VideoGameService(IVideoGameRepository videoGameRepository, IUnitOfWork unitOfWork, IMemoryCache cache)
        {
            _videoGameRepository = videoGameRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<IEnumerable<VideoGameDTO>> ListAsync()
        {
            // Get list of video games from cache if exits
            // No data in cache - return list from repo
            var videoGames = await _cache.GetOrCreateAsync(CacheKeys.VideoGameList, (entry) =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                return _videoGameRepository.ListAsync();
            });

            return videoGames;
        }

        public async Task<VideoGameResponse> FindByIdAsync(int id)
        {
            var videoGame = await _videoGameRepository.FindByIdAsync(id);

            return videoGame == null ?
                new VideoGameResponse("Video Game not found.") :
                new VideoGameResponse(videoGame);
        }

        public async Task<VideoGameResponse> SaveAsync(VideoGameDTO videoGame)
        {
            try
            {
                await _videoGameRepository.AddAsync(videoGame);
                await _unitOfWork.CompleteAsync();

                return new VideoGameResponse(videoGame);
            }
            catch (Exception ex)
            {
                return new VideoGameResponse($"An error occured when saving the video game: {ex.Message}");
            }
        }

        public async Task<VideoGameResponse> UpdateAsync(int id, VideoGameDTO videoGame)
        {
            var exisitingVideoGame = await _videoGameRepository.FindByIdAsync(id);

            if (exisitingVideoGame == null)
                return new VideoGameResponse("Video Game not found.");

            exisitingVideoGame.Title = videoGame.Title;

            try
            {
                _videoGameRepository.Update(exisitingVideoGame);
                await _unitOfWork.CompleteAsync();

                return new VideoGameResponse(exisitingVideoGame);
            }
            catch (Exception ex)
            {
                return new VideoGameResponse($"An error occured when updating the video game: {ex.Message}");
            }
        }

        public async Task<VideoGameResponse> DeleteAsync(int id)
        {
            var exisitingVideoGame = await _videoGameRepository.FindByIdAsync(id);

            if (exisitingVideoGame == null)
                return new VideoGameResponse("Video game not found.");

            try
            {
                _videoGameRepository.Remove(exisitingVideoGame);
                await _unitOfWork.CompleteAsync();

                return new VideoGameResponse(exisitingVideoGame);
            }
            catch (Exception ex)
            {
                return new VideoGameResponse($"An error occurred when deleting the video game: {ex.Message}");
            }
        }

        private string GetCacheKeyForVideoGameId(int? videoGameId)
        {
            string key = CacheKeys.VideoGameList.ToString();

            if (videoGameId.HasValue && videoGameId > 0)
                key = string.Concat(key, videoGameId.Value);

            return key;
        }

    }
}
