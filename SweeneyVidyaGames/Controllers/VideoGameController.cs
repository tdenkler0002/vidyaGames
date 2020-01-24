using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SweeneyVidyaGames.Api.Extensions;
using SweeneyVidyaGames.Api.Interfaces;
using SweeneyVidyaGames.Api.Models;
using SweeneyVidyaGames.Api.Resources;

namespace SweeneyVidyaGames.Web.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Produces("application/json")]
    public class VideoGameController : ControllerBase
    {
        private readonly IVideoGameService videoGameService;
        private readonly IMapper mapper;

        public VideoGameController(IVideoGameService videoGameService, IMapper mapper)
        {
            this.videoGameService = videoGameService;
            this.mapper = mapper;

        }

        /// <summary>
        /// Lists all video games
        /// </summary>
        /// <returns>List of Video Games</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VideoGameResource>), 200)]
        public async Task<IEnumerable<VideoGameResource>> GetAllAsync()
        {
            var videoGames = await this.videoGameService.ListAsync();
            var resources = this.mapper.Map<IEnumerable<VideoGameDTO>, IEnumerable<VideoGameResource>>(videoGames);

            return resources;
        }

        /// <summary>
        /// Creates a new video game
        /// </summary>
        /// <param name="resource"></param>
        /// <returns>Response for the request</returns>
        [HttpPost]
        [ProducesResponseType(typeof(VideoGameResource), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveVideoGameResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var videoGame = this.mapper.Map<SaveVideoGameResource, VideoGameDTO>(resource);
            var result = await this.videoGameService.SaveAsync(videoGame);

            if (!result.Success)
                return BadRequest(result.Message);

            var videoGameResource = this.mapper.Map<VideoGameDTO, VideoGameResource>(result.Resource);
            return Ok(videoGameResource);
        }

        /// <summary>
        /// Updates an exisiting video game
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resource"></param>
        /// <returns>Updated video game resource</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(VideoGameResource), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveVideoGameResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var videoGame = this.mapper.Map<SaveVideoGameResource, VideoGameDTO>(resource);
            var result = await this.videoGameService.UpdateAsync(id, videoGame);

            if (!result.Success)
                return BadRequest(result.Message);

            var videoGameResource = this.mapper.Map<VideoGameDTO, VideoGameResource>(result.Resource);
            return Ok(videoGameResource);
        }

        /// <summary>
        /// Deletes a video game
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Response for the request</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(VideoGameResource), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await this.videoGameService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var videoGameResource = this.mapper.Map<VideoGameDTO, VideoGameResource>(result.Resource);
            return Ok(videoGameResource);
        }
    }
}