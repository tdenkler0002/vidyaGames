using System;
using AutoMapper;
using SweeneyVidyaGames.Api.Models;
using SweeneyVidyaGames.Api.Resources;

namespace SweeneyVidyaGames.Api.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveVideoGameResource, VideoGameDTO> ();
        }
    }
}
