﻿using AutoMapper;
using NG_2023_Kanban.BusinessLayer.Interfaces;
using NG_2023_Kanban.BusinessLayer.Models;
using NG_2023_Kanban.DataLayer.Repositories;
using NG_2023_Kanban.DataLayer.Entities;
using NG_2023_Kanban.DataLayer.Interfaces;

namespace NG_2023_Kanban.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserModel> GetAsync(int id)
        {
            return _mapper.Map<UserModel>(await _userRepository.GetAsync(id));
        }

        public async Task<ICollection<UserModel>> GetAllAsync()
        {
            return _mapper.Map<ICollection<UserModel>>(await _userRepository.GetAllAsync());
        }

        public async Task<UserModel?> LoginAsync(UserModel user)
        {
            var data = await _userRepository.FindAsync(x => x.Username == user.Username && x.Password == user.Password);
            if (data.Any())
                return _mapper.Map<ICollection<UserModel>>(data).First();
            else
                return null;
        }

        public async Task<UserModel> RegisterAsync(UserModel user)
        {
            var entity = _mapper.Map<User>(user);
            await _userRepository.CreateAsync(entity);
            return _mapper.Map<UserModel>(entity);
        }
    }
}
