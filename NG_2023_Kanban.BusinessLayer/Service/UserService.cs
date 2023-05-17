using NG_2023_Kanban.BusinessLayer.Interfaces;
using NG_2023_Kanban.DataLayer.Repositories;
using NG_2023_Kanban.DataLayer.Entities;
using NG_2023_Kanban.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NG_2023_Kanban.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> LoginAsync(User user)
        {
            var data = await _userRepository.FindAsync(x => x.Username == user.Username && x.Password == user.Password);
            if (data.Any())
                return data.First();
            else
                return null;
        }

        public async Task<User> RegisterAsync(User user)
        {
            await _userRepository.CreateAsync(user);
            return user;
        }
    }
}
