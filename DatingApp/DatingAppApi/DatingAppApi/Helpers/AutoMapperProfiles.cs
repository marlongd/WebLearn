using AutoMapper;
using DatingAppApi.Dtos;
using DatingAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAppApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>().ForMember(
                dest => dest.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.isMain).Url);
                }).ForMember(dest => dest.Age, opt =>
                {
                    opt.MapFrom(d => calculateAge(d.DateOfBirth));
                });
            CreateMap<User, UserForDetailDto>().ForMember(
                dest => dest.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.isMain).Url);
                }).ForMember(dest => dest.Age, opt =>
                {
                    opt.MapFrom(d => calculateAge(d.DateOfBirth));
                });
            CreateMap<Photo, PhotosForDetailDto>();

            CreateMap<UserForUpdateDto, User>();
        }
        private int calculateAge(DateTime date)
        {
            var age = DateTime.Today.Year - date.Year;
            if(date.AddYears(age) > DateTime.Today) { age--; }
            return age;
        }
    }
}
