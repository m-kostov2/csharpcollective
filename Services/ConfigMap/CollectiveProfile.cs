using AutoMapper;
using CSharpCollective.Services.DtoModels;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ConfigMap
{
    public class CollectiveProfile : Profile
    {
        public CollectiveProfile()
        {

            this.CreateMap<UserDto, User>();
            this.CreateMap<User, UserDto>();

            this.CreateMap<CommentDto, Comment>()
                .ForCtorParam("content", opt => opt.MapFrom(src => src.Content))
                .ForCtorParam("content", opt => opt.MapFrom(src => src.Content));



            this.CreateMap<PostDto, Post>()
                .ForCtorParam("title", opt => opt.MapFrom(src => src.Title))
                .ForCtorParam("content", opt => opt.MapFrom(src => src.Content));




            this.CreateMap<TagDto, Tag>()
                .ForCtorParam("name", opt => opt.MapFrom(src => src.Name));
           





        }

    }
}
     //.ForCtorParam("email", opt => opt.MapFrom(src => src.Email))
     //           .ForCtorParam("password", opt => opt.MapFrom(src => src.Password));