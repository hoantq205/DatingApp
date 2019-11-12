using System.Linq;
using AutoMapper;
using Dating.API.Dtos;
using Dating.API.Models;

namespace Dating.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(x => x.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url);
                })
                .ForMember(x => x.Age, opt => {
                    opt.ResolveUsing(x => x.DateOfBirth.CalculateAge());
                });

            CreateMap<User, UserForDetailDto>()
                .ForMember(x => x.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url);
                })
                .ForMember(x => x.Age, opt => {
                    opt.ResolveUsing(x => x.DateOfBirth.CalculateAge());
                });

            CreateMap<Photo, PhotosForDetailedDto>();

            CreateMap<UserForUpdateDto, User>();
        }
    }
}