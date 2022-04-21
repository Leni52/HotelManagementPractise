using HotelApril.BLL.Services.Interfaces;
using HotelApril.DAL.Entities;
using HotelApril.DTO.Requests;
using HotelApril.DTO.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApril.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IUserService _userService;
        public RoomController(IUserService userService, IRoomService roomService)
        {
            _roomService = roomService;
            _userService = userService;
        }
      
    }
}
