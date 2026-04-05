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

            this.CreateMap<UserDto, User>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));

            this.CreateMap<User, UserDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));
            // .ForAllMembers(opt=>opt.Ignore());;

            this.CreateMap<CommentDto, Comment>()
                .ForCtorParam("content", opt => opt.MapFrom(src => src.Content));


            this.CreateMap<Comment, CommentDto>()
                .ForCtorParam("content", opt => opt.MapFrom(src => src.Content));
                




            this.CreateMap<PostDto, Post>()
                .ForCtorParam("title", opt => opt.MapFrom(src => src.Title))
                .ForCtorParam("content", opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.Id, opt => opt.Ignore());



            this.CreateMap<Post, PostDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));





            this.CreateMap<TagDto, Tag>()
                .ForCtorParam("name", opt => opt.MapFrom(src => src.Name));






        }

    }
}
//.ForCtorParam("email", opt => opt.MapFrom(src => src.Email))
//           .ForCtorParam("password", opt => opt.MapFrom(src => src.Password));