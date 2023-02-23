using System;
using Shared.Dtos;
using AutoMapper;
using ZmgBlogEngine.DataAccess.Models;

namespace ZmgBlogEngine.Services
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Rol, RolDto>();
            CreateMap<User, UserDto>();
            CreateMap<Post, PostDto>();
            CreateMap<Comment, CommentDto>();
        }
    }
}

