using HotelApril.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApril.BLL.Services.Interfaces
{
  public interface IRoomService
    {
        Task CreateRoom(Room room, ExternalUser currentUser);
        Task<List<Room>> GetAllRooms();
        Task<Room> GetRoom(Guid id);
        Task DeleteRoom(Guid id);
        Task<Room> UpdateRoom(Guid id, Room room, string currentUserId);
    }
}
