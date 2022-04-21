using HotelApril.BLL.Services.Interfaces;
using HotelApril.DAL.Entities;
using HotelApril.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApril.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<ExternalUser> _userRepository;
        public UserService(IRepository<ExternalUser> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CreateUser(string externalUserId, string name)
        {
            if (_userRepository.Get(u => u.ExternalUserId==externalUserId || u.Name == name) != null)
            {
                return false;
            }
            ExternalUser user = new ExternalUser()
            {
                ExternalUserId = externalUserId
            };
            _userRepository.CreateOrUpdate(user);
            return true;
        }

        public async Task<List<ExternalUser>> GetAll()
        {
            return await _userRepository.AllAsync();
        }

        public async Task<ExternalUser> GetUserById(string externalId)
        {
            return await _userRepository.GetAsync(u => u.ExternalUserId == externalId);
        }

        public async Task<ExternalUser> GetUserByName(string name)
        {
            return await _userRepository.GetAsync(u => u.Name == name);
        }
    }
}
