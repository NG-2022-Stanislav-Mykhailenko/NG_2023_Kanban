using NG_2023_Kanban.DataLayer.Service;
using NG_2023_Kanban.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace NG_2023_Kanban.BusinessLayer.Service
{
    public class BusinessService
    {
        private readonly DataService _service;
        public BusinessService(DataService service) 
        {
            _service = service;
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            return await _service.LoginAsync(username, password);
        }

        public async Task<User> RegisterAsync(string fullName, string username, string password)
        {
            User account = await _service.AddAsync(new User
            {
                FullName = fullName,
                Username = username,
                Password = password, // TODO: hashing
                IsAdmin = false
            });

            return account;
        }
    }
}
