using HotelApril.BLL.Services.Interfaces;
using HotelApril.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApril.WEB.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles="Admin,Regular")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService):base()
        {
            _userService = userService;
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(UserRequestDTO user)
        {

            bool result = await _userService.CreateUser(User.Identity.Name, user.UserName);

            if (result)
            {
                ExternalUser userFromDB = await _userService.GetUserByName(user.UserName);

                return CreatedAtAction("Get", "Users", new { id = userFromDB.Id }, null);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<UserResponseDTO> Get(string id)
        {
            var userFromDB = await _userService.GetUserById(id);
            return new UserResponseDTO()
            {
                UserName = userFromDB.Name,
                Id = userFromDB.ExternalUserId,
            };
        }

        [HttpGet]
        [Route("All")]
        public async Task<List<UserResponseDTO>> GetAll()
        {
            List<UserResponseDTO> users = new List<UserResponseDTO>();

            foreach (var user in await _userService.GetAll())
            {
                users.Add(new UserResponseDTO()
                {
                    Id = user.ExternalUserId,
                    CreatedAt = user.CreationDate,
                    UserName = user.Name
                });
            }

            return users;
        }

    }
}
