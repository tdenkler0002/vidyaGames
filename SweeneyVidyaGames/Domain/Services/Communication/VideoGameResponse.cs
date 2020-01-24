using System;
using SweeneyVidyaGames.Api.Models;

namespace SweeneyVidyaGames.Api.Domain.Services.Communication
{
    public class VideoGameResponse : BaseResponse<VideoGameDTO>
    {
        public VideoGameResponse(VideoGameDTO videoGame) : base(videoGame) { }
    
        public VideoGameResponse(string message) : base(message) { }
    }
}
