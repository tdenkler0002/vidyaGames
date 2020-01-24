using System;
using AutoMapper;
using SweeneyVidyaGames.Api.Extensions;
using SweeneyVidyaGames.Api.Models;
using SweeneyVidyaGames.Api.Resources;

namespace SweeneyVidyaGames.Api.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<VideoGameDTO, VideoGameResource>()
                .ForMember(src => src.Genre,
                    opt => opt.MapFrom(src => src.Genre.ToDescriptionString()));
        }
    }
}
