using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SweeneyVidyaGames.Api.Domain.Repositories;
using SweeneyVidyaGames.Api.Domain.Services.Communication;
using SweeneyVidyaGames.Api.Interfaces;
using SweeneyVidyaGames.Api.Models;

namespace SweeneyVidyaGames.Api.Core.Services
{
    public class VideoGameService : IVideoGameService
    {
        private readonly IVideoGameRepository videoGameRepository;
        private readonly IUnitOfWork unitOfWork;

        public VideoGameService(IVideoGameRepository videoGameRepository, IUnitOfWork unitOfWork)
        {
            this.videoGameRepository = videoGameRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<VideoGameDTO>> ListAsync()
        {
            return await videoGameRepository.ListAsync();
        }

        public async Task<VideoGameResponse> SaveAsync(VideoGameDTO videoGame)
        {
            try
            {
                await videoGameRepository.AddAsync(videoGame);
                await unitOfWork.CompleteAsync();

                return new VideoGameResponse(videoGame);
            }
            catch (Exception ex)
            {
                return new VideoGameResponse($"An error occured when saving the video game: {ex.Message}");
            }
        }

        public async Task<VideoGameResponse> UpdateAsync(int id, VideoGameDTO videoGame)
        {
            var exisitingVideoGame = await videoGameRepository.FindByIdAsync(id);

            if (exisitingVideoGame == null)
                return new VideoGameResponse("Video Game not found.");

            exisitingVideoGame.Title = videoGame.Title;

            try
            {
                videoGameRepository.Update(exisitingVideoGame);
                await unitOfWork.CompleteAsync();

                return new VideoGameResponse(exisitingVideoGame);
            }
            catch (Exception ex)
            {
                return new VideoGameResponse($"An error occured when updating the video game: {ex.Message}");
            }
        }

        public async Task<VideoGameResponse> DeleteAsync(int id)
        {
            var exisitingVideoGame = await videoGameRepository.FindByIdAsync(id);

            if (exisitingVideoGame == null)
                return new VideoGameResponse("Video game not found.");

            try
            {
                videoGameRepository.Remove(exisitingVideoGame);
                await unitOfWork.CompleteAsync();

                return new VideoGameResponse(exisitingVideoGame);
            }
            catch (Exception ex)
            {
                return new VideoGameResponse($"An error occurred when deleting the video game: {ex.Message}");
            }
        }

    }
}
