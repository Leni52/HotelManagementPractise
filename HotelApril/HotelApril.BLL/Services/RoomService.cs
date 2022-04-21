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
    public class RoomService : IRoomService
    {
        private readonly IRepository<Room> _roomRepository;
        public RoomService(IRepository<Room> roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task CreateRoom(Room room, User currentUser)
        {
            await _roomRepository.CreateOrUpdate(room);

        }

        public async Task DeleteRoom(Guid id)
        {
            var room = await _roomRepository.Get(id);
            if (room != null)
            {
                await _roomRepository.Remove(room);
            }
            else
                throw new ItemDoesNotExistException();
        }

        public async Task<List<Room>> GetAllRooms()
        {
           return await _roomRepository.All();
        }

        public async Task<Room> GetRoom(Guid id)
        {
            return await _roomRepository.Get(id);
        }

        public async Task<Room> UpdateRoom(Guid id, Room room, string currentUserId)
        {
            var roomToUpdate =await _roomRepository.Get(id);
            roomToUpdate.ChangeDate = DateTime.Now;
            roomToUpdate.UpdaterId = currentUserId;
            roomToUpdate.Description = room.Description;
            roomToUpdate.Available = room.Available;
            roomToUpdate.MaximumGuests = room.MaximumGuests;
            roomToUpdate.Number = room.Number;
            roomToUpdate.Price = room.Price;
            roomToUpdate.Type = room.Type;
            await _roomRepository.CreateOrUpdate(room);
            return room;
        }
    }
}
