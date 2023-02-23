using System;
using AutoMapper;
using Shared;
using Shared.Dtos;
using ZmgBlogEngine.DataAccess.Models;
using ZmgBlogEngine.DataAccess.Repositories;

namespace ZmgBlogEngine.Services
{
    public class LoginService : ILoginService
    {
        IUserRepository _userRepository;
        IMapper _mapper;

        public LoginService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserDto GetUserByIdAndPassword(int userId, string password)
        {
            var user = _userRepository.GetUserByIdAndPassword(userId, password);

            return _mapper.Map<UserDto>(user);
        }
    }
}

