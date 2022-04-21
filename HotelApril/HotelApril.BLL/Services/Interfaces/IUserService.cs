using HotelApril.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApril.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUser(string externalUserId, string name);
        Task<List<ExternalUser>> GetAll();
        Task<ExternalUser> GetUserById(string id);
        Task<ExternalUser> GetUserByName(string name);

    }
}
