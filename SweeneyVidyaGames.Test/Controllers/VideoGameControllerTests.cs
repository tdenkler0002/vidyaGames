using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SweeneyVidyaGames.Api.Domain.Services.Communication;
using SweeneyVidyaGames.Api.Interfaces;
using SweeneyVidyaGames.Api.Mapping;
using SweeneyVidyaGames.Api.Models;
using SweeneyVidyaGames.Api.Resources;
using SweeneyVidyaGames.Test.Services;
using SweeneyVidyaGames.Web.Controllers;
using Xunit;

namespace SweeneyVidyaGames.Test.Controllers
{
    public class VideoGameControllerTests
    {
        VideoGameController _videoGameController;
        IVideoGameService _videoGameService;
        IMapper _mapper;

        public VideoGameControllerTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToResourceProfile());
                cfg.AddProfile(new ResourceToModelProfile());
            });

            _mapper = config.CreateMapper();
            _videoGameService = new VideoGameServiceFake();
            _videoGameController = new VideoGameController(_videoGameService, _mapper);
        }

        [Fact]
        public async Task VideoGames_GetAllAsync_ReturnsOkResult()
        {
            // Act
            var result = await _videoGameController.GetAllAsync();
            var okResult = new OkObjectResult(result);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.IsType<List<VideoGameResource>>(okResult.Value);
        }
    }
}
